using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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

    /// <summary>
    /// Indique que la r�paration du convoyeur est compl�t�e
    /// </summary>
    public bool ReparationCompletee { get; set; }

    /// <summary>
    /// R�f�rence sur la coroutine qui effectue la r�paration
    /// </summary>
    private Coroutine coroutineReparation;

    /// <summary>
    /// Temps n�cessaire pour r�parer le convoyeur
    /// </summary>
    [SerializeField]
    private float tempsReparation;

    /// <summary>
    /// Image pour afficher la progression de la r�paration
    /// </summary>
    [SerializeField]
    private Image progressionReparation;

    private void Awake()
    {
        direction.Normalize();
        etat = new Avancer();
        etatPrecedent = null;
        EstArrete = false;
        EstBrise = false;
        ReparationCompletee = false;
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

    /// <summary>
    /// D�marre le compteur de r�paration
    /// </summary>
    public void DemarrerCompteurReparation()
    {
        coroutineReparation = StartCoroutine("CompterTempsReparation");
    }

    /// <summary>
    /// Interrompt la r�paration
    /// </summary>
    public void ArreterReparation()
    {
        StopCoroutine(coroutineReparation);
        progressionReparation.gameObject.SetActive(false);
    }

    /// <summary>
    /// Coroutine qui compte le temps pass� � r�parer le convoyeur et met � jour l'affichage
    /// du compteur en cons�quent
    /// </summary>
    /// <returns></returns>
    private IEnumerator CompterTempsReparation()
    {
        float tempsEcoule = 0.0f;       // Compteur accumul� par frame
        progressionReparation.gameObject.SetActive(true);       // Affiche le compteur

        // Ex�cuter la boucle tant que la r�paration n'est pas compl�t�e
        while(tempsEcoule < tempsReparation)
        {
            tempsEcoule += Time.deltaTime;
            // Remplit l'image (mode filled)
            progressionReparation.fillAmount = tempsEcoule / tempsReparation;
            
            // Instruction indiquant � Unity d'attendre le prochain passage de la boucle de jeu 
            // avant de continuer l'ex�cution de la m�thode
            yield return null;
        }

        // Op�rations ex�cut�es apr�s la compl�tion de la r�paration
        ReparationCompletee = true;
        progressionReparation.gameObject.SetActive(false);
    }

    /// <summary>
    /// Commence le compte du d�lai de gr�ce sur le convoyeur.
    /// </summary>
    public void CommencerDelaiGrace()
    {
        StartCoroutine("CoroutineDelaiGrace");
    }

    /// <summary>
    /// D�lai pendant lequel le convoyeur ne peut pas briser
    /// </summary>
    [SerializeField]
    private float delaiGrace = 3.0f;

    /// <summary>
    /// Coroutine qui affecte � 0.0 la probabilit� le temps 
    /// du d�lai de gr�ce.
    /// </summary>
    /// <returns></returns>
    private IEnumerator CoroutineDelaiGrace()
    {
        float probabiliteBris = ProbabiliteBris;
        this.probabiliteBris = 0.0f;

        // Attend ce nombre de secondes dans le jeu (�chelle du temps de jeu)
        yield return new WaitForSeconds(delaiGrace);

        this.probabiliteBris = probabiliteBris;
    }
}
