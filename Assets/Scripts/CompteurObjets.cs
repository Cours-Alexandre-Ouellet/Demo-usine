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

    /// <summary>
    /// Ajoute un nombre d'objets créés au compteur.
    /// </summary>
    /// <param name="nombreCrees">Le nombre d'objets qui ont été créés.</param>
    public void AjouterCrees(int nombreCrees = 1)
    {
        this.nombreCrees += nombreCrees;
        Debug.Log($"Nombre de crees {this.nombreCrees}.");
    }

    /// <summary>
    /// Ajoute un nombre d'objets détruits au compteur.
    /// </summary>
    /// <param name="nombreDetruits">Le nombre d'objets qui ont été détruits.</param>
    public void AjouterDetruits(int nombreDetruits = 1)
    {
        this.nombreDetruits += nombreDetruits;
        Debug.Log($"Nombre de detruits {this.nombreDetruits}.");
    }
}
