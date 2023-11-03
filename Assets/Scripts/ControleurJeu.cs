using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Objet responsable du contr�le g�n�ral du jeu
/// </summary>
public class ControleurJeu : MonoBehaviour
{
    /// <summary>
    /// Instance unique du contr�leur de jeu
    /// </summary>
    public static ControleurJeu Instance {get; private set;}

    /// <summary>
    /// Liste des mod�les disponibles dans le jeu
    /// </summary>
    private ModeleObjet[] modelesDisponibles;
    public ModeleObjet[] ModelesDisponibles => modelesDisponibles;

    /// <summary>
    /// R�f�rence sur le fabricateur
    /// </summary>
    [SerializeField]
    private Fabricateur fabricateur;

    /// <summary>
    /// Retourne le mod�le s�lectionn�
    /// </summary>
    public ModeleObjet ModeleSelectionne => fabricateur != null ? fabricateur.Modele : null;

    [SerializeField]
    private Peintureur peintureur;

    /// <summary>
    /// Retourne la couleur s�lectionn�e
    /// </summary>
    public ModeleObjetCouleur CouleurSelectionnee => peintureur != null ? peintureur.ModeleAAppliquer : null;

    private void Awake()
    {
        // Pseudo-singleton
        if(Instance == null)
        {
            Instance = this;

            // Charge automatiquement les Assets Modeles du dossier Resources/Modeles
            modelesDisponibles = Resources.LoadAll<ModeleObjet>("Modeles");
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Change le mod�le affecter � un fabricateutr
    /// </summary>
    /// <param name="modeleObjet">Le nouveau mod�le d'objet � utiliser.</param>
    public void ChangerModeleProduit(ModeleObjet modeleObjet)
    {
        fabricateur.Modele = modeleObjet;
    }

    /// <summary>
    /// Change la couleur � affecter � un mod�le lorsqu'il traverse un peintureur
    /// </summary>
    /// <param name="couleur">La nouvelle couleur � utiliser.</param>
    public void ChangerCouleurProduit(ModeleObjetCouleur couleur)
    {
        peintureur.ModeleAAppliquer = couleur;
    }
}
