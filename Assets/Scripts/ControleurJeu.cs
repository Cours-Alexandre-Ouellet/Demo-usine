using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Objet responsable du contrôle général du jeu
/// </summary>
public class ControleurJeu : MonoBehaviour
{
    /// <summary>
    /// Instance unique du contrôleur de jeu
    /// </summary>
    public static ControleurJeu Instance {get; private set;}

    /// <summary>
    /// Liste des modèles disponibles dans le jeu
    /// </summary>
    private ModeleObjet[] modelesDisponibles;
    public ModeleObjet[] ModelesDisponibles => modelesDisponibles;

    /// <summary>
    /// Référence sur le fabricateur
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
    /// Change le modèle affecter à un fabricateutr
    /// </summary>
    /// <param name="modeleObjet">Le nouveau modèle d'objet à utiliser.</param>
    public void ChangerModeleProduit(ModeleObjet modeleObjet)
    {
        fabricateur.Modele = modeleObjet;
    }
}
