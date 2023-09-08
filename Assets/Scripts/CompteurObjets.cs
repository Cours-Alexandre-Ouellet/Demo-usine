using UnityEngine;

/// <summary>
/// Compte les objets présentant dans le jeu
/// </summary>
public class CompteurObjets : MonoBehaviour
{
    /// <summary>
    /// Instance unique pour le pseudo-singleton
    /// </summary>
    public static CompteurObjets Instance { get; private set; }

    /// <summary>
    /// Nombre d'objets qui ont été créés
    /// </summary>
    private int nombreCrees;

    /// <summary>
    /// Nombre d'objets qui ont été détruits
    /// </summary>
    private int nombreDetruits;

    [SerializeField, Tooltip("Référence à l'objet qui affiche le nombre de créés.")]
    private FormatteurTexte compteurCrees;

    [SerializeField, Tooltip("Référence à l'objet qui affiche le nombre de détruits.")]
    private FormatteurTexte compteurDetruits;

    [SerializeField, Tooltip("Référence à l'objet qui affiche le nombre de créés et de détruits.")]
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
    /// Ajoute un nombre d'objets créés au compteur.
    /// </summary>
    /// <param name="nombreCrees">Le nombre d'objets qui ont été créés.</param>
    public void AjouterCrees(int nombreCrees = 1)
    {
        this.nombreCrees += nombreCrees;
        compteurCrees.ChangerValeur(this.nombreCrees);
        afficheurComplet.FormatterValeurs(this.nombreCrees, nombreDetruits);
    }

    /// <summary>
    /// Ajoute un nombre d'objets détruits au compteur.
    /// </summary>
    /// <param name="nombreDetruits">Le nombre d'objets qui ont été détruits.</param>
    public void AjouterDetruits(int nombreDetruits = 1)
    {
        this.nombreDetruits += nombreDetruits;
        compteurDetruits.ChangerValeur(this.nombreDetruits);
        afficheurComplet.FormatterValeurs(nombreCrees, this.nombreDetruits);
    }
}
