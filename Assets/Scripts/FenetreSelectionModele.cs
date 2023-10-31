using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Spécialisation de FenetreContextuelle en une fenêtre de sélection de modèles
/// </summary>
public class FenetreSelectionModele : FenetreContextuelle
{
    [SerializeField, Tooltip("Zone où afficher les modèles à construire")]
    private GameObject zoneModeles;

    [SerializeField, Tooltip("Prototype d'item à afficher")]
    private ItemSelectionModele prototypeItemSelection;

    public override void Ouvrir()
    {
        base.Ouvrir();
        AfficherModeles();
    }

    /// <summary>
    /// Affiche la liste des modèles dans la fenêtre
    /// </summary>
    private void AfficherModeles()
    {
        ReinitialiserAffichage();

        foreach(ModeleObjet modele in ControleurJeu.Instance.ModelesDisponibles)
        {
            ItemSelectionModele itemSelection = Instantiate(prototypeItemSelection, zoneModeles.transform);
            itemSelection.Afficher(modele);
        }
    }

    /// <summary>
    /// Retire les modèles existants de la fenêtre
    /// </summary>
    private void ReinitialiserAffichage()
    {
        foreach(Transform enfant in zoneModeles.transform)
        {
            Destroy(enfant.gameObject);
        }
    }
}
