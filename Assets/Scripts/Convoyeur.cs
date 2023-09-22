using UnityEngine;

/// <summary>
/// G�re un convoyeur d'objets
/// </summary>
public class Convoyeur : MonoBehaviour
{
    [SerializeField, Tooltip("Vitesse � laquelle l'objet est transport�.")]
    private float vitesse = 2.0f;

    [SerializeField]
    private float vitesseMinimal = 0.0f;

    [SerializeField]
    private float vitesseMaximale = 5.0f;

    [SerializeField, Tooltip("Direction dans laquelle l'objet est envoy�.")]
    private Vector3 direction;

    /// <summary>
    /// Indique si le convoyeur est actuellement � l'arr�t
    /// </summary>
    public bool EstArrete { get; set; }

    /// <summary>
    /// Indique si le convoyeur est actuellement bris�
    /// </summary>
    public bool EstBrise { get; set; }

    [SerializeField, Tooltip("Probabilit� �valu�e que le convoyeur brise � chaque frame")]
    private float probabiliteBris;
    public float ProbabiliteBris => probabiliteBris;

    /// <summary>
    /// Etat du convoyeur � la frame actuelle.
    /// Mise � jour dans UPDATE
    /// </summary>
    private Etat etat;

    /// <summary>
    /// �tat du convoyeur � la frame pr�c�dente.
    /// Mise � jour dans UPDATE
    /// </summary>
    private Etat etatPrecedent;

    private void Awake()
    {
        direction.Normalize();
        etat = new Avancer();
        etatPrecedent = null;
        EstArrete = false;
        EstBrise = false;
    }

    private void Update()
    {
        if(etat != null)
        {
            if(etat != etatPrecedent)
            {
                etat.EntrerEtat(this, etatPrecedent);
            }

            etatPrecedent = etat;
            etat = etat.Executer(this);

            if(etat != etatPrecedent)
            {
                etatPrecedent.SortirEtat(this, etat);
            }
        }
    }

    /// <summary>
    /// Permet de faire le changement de vitesse entre une vitesse minimale et maximale, selon un pourcentage
    /// donn�.
    /// </summary>
    /// <param name="pourcentageVitesse">Le pourcentage avec vitesse � utiliser.</param>
    public void ChangerVitesse(float pourcentageVitesse)
    {
        vitesse = Mathf.Lerp(vitesseMinimal, vitesseMaximale, pourcentageVitesse);
    }

    private void OnCollisionStay(Collision collision)
    {
        if(!EstArrete)
        {
            collision.rigidbody.transform.position += vitesse * Time.deltaTime * direction;
        }
        else
        {
            collision.rigidbody.transform.position += vitesse * 0.0001f * Time.deltaTime * direction;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        Rigidbody rigidbodyCollision = collision.rigidbody;
        rigidbodyCollision.AddForce(vitesse * direction, ForceMode.Impulse);
    }
}
