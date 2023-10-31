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
}
