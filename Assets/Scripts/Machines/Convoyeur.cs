using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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

    /// <summary>
    /// Indique que la réparation du convoyeur est complétée
    /// </summary>
    public bool ReparationCompletee { get; set; }

    /// <summary>
    /// Référence sur la coroutine qui effectue la réparation
    /// </summary>
    private Coroutine coroutineReparation;

    /// <summary>
    /// Temps nécessaire pour réparer le convoyeur
    /// </summary>
    [SerializeField]
    private float tempsReparation;

    /// <summary>
    /// Temps demandé pour fabriquer un objet
    /// </summary>
    public float TempsFabrication { get; set; }

    /// <summary>
    /// Zones qui représentent un bris
    /// </summary>
    [SerializeField]
    private ZoneBris[] zonesBris;

    /// <summary>
    /// Zones qui représentent un bris
    /// </summary>
    private ZoneBris zoneBrisActive;


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
    /// Demande au convoyeur d'attendre pour un temps de fabrication
    /// </summary>
    /// <param name="temps">Le temps de fabrication de l'oibjet</param>
    public void Attendre(float temps)
    {
        TempsFabrication = temps;   
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
        Debug.Log($"Call collision stay : {EstArrete}");

        if(!EstArrete)
        {
            collision.rigidbody.transform.position += vitesse * Time.deltaTime * direction;
        }
        else
        {
            collision.rigidbody.transform.position += 0.0001f * Time.deltaTime * direction;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        Rigidbody rigidbodyCollision = collision.rigidbody;
        rigidbodyCollision.AddForce(vitesse * direction, ForceMode.Impulse);
    }

    /// <summary>
    /// Démarre le compteur de réparation
    /// </summary>
    public void DemarrerCompteurReparation()
    {
        coroutineReparation = StartCoroutine("CompterTempsReparation");
    }

    /// <summary>
    /// Interrompt la réparation
    /// </summary>
    public void ArreterReparation()
    {
        StopCoroutine(coroutineReparation);
        if(zoneBrisActive != null)
        {
            zoneBrisActive.SetProgression(0);
        }
    }

    /// <summary>
    /// Coroutine qui compte le temps passé à réparer le convoyeur et met à jour l'affichage
    /// du compteur en conséquent
    /// </summary>
    /// <returns></returns>
    private IEnumerator CompterTempsReparation()
    {
        float tempsEcoule = 0.0f;       // Compteur accumulé par frame

        // Exécuter la boucle tant que la réparation n'est pas complétée
        while(tempsEcoule < tempsReparation)
        {
            tempsEcoule += Time.deltaTime;
            // Remplit l'image (mode filled)
            zoneBrisActive.SetProgression(tempsEcoule / tempsReparation);
            
            // Instruction indiquant à Unity d'attendre le prochain passage de la boucle de jeu 
            // avant de continuer l'exécution de la méthode
            yield return null;
        }

        // Opérations exécutées après la complétion de la réparation
        ReparationCompletee = true;
    }

    /// <summary>
    /// Commence le compte du délai de grâce sur le convoyeur.
    /// </summary>
    public void CommencerDelaiGrace()
    {
        StartCoroutine("CoroutineDelaiGrace");
    }

    /// <summary>
    /// Délai pendant lequel le convoyeur ne peut pas briser
    /// </summary>
    [SerializeField]
    private float delaiGrace = 3.0f;

    /// <summary>
    /// Coroutine qui affecte à 0.0 la probabilité le temps 
    /// du délai de grâce.
    /// </summary>
    /// <returns></returns>
    private IEnumerator CoroutineDelaiGrace()
    {
        float probabiliteBris = ProbabiliteBris;
        this.probabiliteBris = 0.0f;

        // Attend ce nombre de secondes dans le jeu (échelle du temps de jeu)
        yield return new WaitForSeconds(delaiGrace);

        this.probabiliteBris = probabiliteBris;
    }

    /// <summary>
    /// Affiche l'une des zones de bris
    /// </summary>
    public void AfficherZoneBris()
    {
        if(zoneBrisActive == null)
        {
            zoneBrisActive = zonesBris[Random.Range(0, zonesBris.Length)];
            zoneBrisActive.gameObject.SetActive(true);
            zoneBrisActive.Activer();
        }
    }

    /// <summary>
    /// Masque la zone de bris active
    /// </summary>
    public void MasquerZoneBris()
    {
        if(zoneBrisActive != null)
        {
            zoneBrisActive.gameObject.SetActive(false);
            zoneBrisActive = null;
        }
    }
}
