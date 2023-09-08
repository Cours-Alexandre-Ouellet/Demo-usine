using UnityEngine;

/// <summary>
/// Compte les objets pr�sentant dans le jeu
/// </summary>
public class CompteurObjets : MonoBehaviour
{
    /// <summary>
    /// Instance unique pour le pseudo-singleton
    /// </summary>
    public static CompteurObjets Instance { get; private set; }

    /// <summary>
    /// Nombre d'objets qui ont �t� cr��s
    /// </summary>
    private int nombreCrees;

    /// <summary>
    /// Nombre d'objets qui ont �t� d�truits
    /// </summary>
    private int nombreDetruits;

    [SerializeField, Tooltip("R�f�rence � l'objet qui affiche le nombre de cr��s.")]
    private FormatteurTexte compteurCrees;

    [SerializeField, Tooltip("R�f�rence � l'objet qui affiche le nombre de d�truits.")]
    private FormatteurTexte compteurDetruits;

    [SerializeField, Tooltip("R�f�rence � l'objet qui affiche le nombre de cr��s et de d�truits.")]
    private FormatteurTexteComplet afficheurComplet;

    private void Awake()
    {

        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        nombreCrees = 0;
        nombreDetruits = 0;
    }

    private void Start()
    {
        compteurCrees.ChangerValeur(nombreCrees);
        compteurDetruits.ChangerValeur(nombreDetruits);
        afficheurComplet.FormatterValeurs(nombreCrees, nombreDetruits);
    }

    /// <summary>
    /// Ajoute un nombre d'objets cr��s au compteur.
    /// </summary>
    /// <param name="nombreCrees">Le nombre d'objets qui ont �t� cr��s.</param>
    public void AjouterCrees(int nombreCrees = 1)
    {
        this.nombreCrees += nombreCrees;
        compteurCrees.ChangerValeur(this.nombreCrees);
        afficheurComplet.FormatterValeurs(this.nombreCrees, nombreDetruits);
    }

    /// <summary>
    /// Ajoute un nombre d'objets d�truits au compteur.
    /// </summary>
    /// <param name="nombreDetruits">Le nombre d'objets qui ont �t� d�truits.</param>
    public void AjouterDetruits(int nombreDetruits = 1)
    {
        this.nombreDetruits += nombreDetruits;
        compteurDetruits.ChangerValeur(this.nombreDetruits);
        afficheurComplet.FormatterValeurs(nombreCrees, this.nombreDetruits);
    }
}
