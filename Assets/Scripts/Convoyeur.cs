using UnityEngine;

/// <summary>
/// Gère un convoyeur d'objets
/// </summary>
public class Convoyeur : MonoBehaviour
{
    [SerializeField, Tooltip("Vitesse à laquelle l'objet est transporté.")]
    private float vitesse = 2.0f;

    [SerializeField]
    private float vitesseMinimal = 0.0f;

    [SerializeField]
    private float vitesseMaximale = 5.0f;

    [SerializeField, Tooltip("Direction dans laquelle l'objet est envoyé.")]
    private Vector3 direction;

    /// <summary>
    /// Indique si le convoyeur est actuellement à l'arrêt
    /// </summary>
    public bool EstArrete { get; set; }

    /// <summary>
    /// Indique si le convoyeur est actuellement brisé
    /// </summary>
    public bool EstBrise { get; set; }

    [SerializeField, Tooltip("Probabilité évaluée que le convoyeur brise à chaque frame")]
    private float probabiliteBris;
    public float ProbabiliteBris => probabiliteBris;

    /// <summary>
    /// Etat du convoyeur à la frame actuelle.
    /// Mise à jour dans UPDATE
    /// </summary>
    private Etat etat;

    /// <summary>
    /// État du convoyeur à la frame précédente.
    /// Mise à jour dans UPDATE
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
    /// donné.
    /// </summary>
    /// <param name="pourcentageVitesse">Le pourcentage avec vitesse à utiliser.</param>
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
