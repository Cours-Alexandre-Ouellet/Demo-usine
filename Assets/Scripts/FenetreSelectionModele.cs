using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Sp�cialisation de FenetreContextuelle en une fen�tre de s�lection de mod�les
/// </summary>
public class FenetreSelectionModele : FenetreContextuelle
{
    [SerializeField, Tooltip("Zone o� afficher les mod�les � construire")]
    private GameObject zoneModeles;

    [SerializeField, Tooltip("Prototype d'item � afficher")]
    private ItemSelectionModele prototypeItemSelection;

    public override void Ouvrir()
    {
        base.Ouvrir();
        AfficherModeles();
    }

    /// <summary>
    /// Affiche la liste des mod�les dans la fen�tre
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
    /// Retire les mod�les existants de la fen�tre
    /// </summary>
    private void ReinitialiserAffichage()
    {
        foreach(Transform enfant in zoneModeles.transform)
        {
            Destroy(enfant.gameObject);
        }
    }
}
