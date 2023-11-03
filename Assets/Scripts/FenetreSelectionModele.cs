using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Sp�cialisation de FenetreContextuelle en une fen�tre de s�lection de mod�les
/// </summary>
public class FenetreSelectionModele : FenetreContextuelle
{
    [SerializeField, Tooltip("Zone o� afficher les mod�les � construire")]
    private GameObject zoneModeles;

    [SerializeField, Tooltip("Zone o� afficher les couleurs � appliquer")]
    private GameObject zoneCouleurs;

    [SerializeField, Tooltip("Prototype d'item � afficher")]
    private ItemSelectionModele prototypeItemSelection;

    /// <inheritdoc/>
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
        ReinitialiserAffichageModele();

        foreach(ModeleObjet modele in ControleurJeu.Instance.ModelesDisponibles)
        {
            ItemSelectionModele itemSelection = Instantiate(prototypeItemSelection, zoneModeles.transform);
            itemSelection.Afficher(modele);
            itemSelection.AfficherCommeSelectionne(modele == ControleurJeu.Instance.ModeleSelectionne);
            itemSelection.onModeleChange.AddListener(ChangementModele);
        }
    }


    /// <summary>
    /// Affiche les couleurs disponibles pour un mod�le
    /// </summary>
    /// <param name="modele">Le mod�le pour lequel afficher les couleurs disponibles</param>
    private void AfficherCouleurs(ModeleObjet modele)
    {
        ReinitialiserAffichageCouleurs();

        foreach(ModeleObjetCouleur couleur in modele.CouleursPossibles)
        {
            ItemSelectionModele itemSelection = Instantiate(prototypeItemSelection, zoneCouleurs.transform);
            itemSelection.Afficher(couleur);
            itemSelection.AfficherCommeSelectionne(couleur == ControleurJeu.Instance.CouleurSelectionnee);
            itemSelection.onModeleChange.AddListener(ChangementCouleur);
        }
    }

    /// <summary>
    /// Efface toutes les couleurs de l'interface
    /// </summary>
    private void ReinitialiserAffichageCouleurs()
    {
        foreach(Transform enfant in zoneCouleurs.transform)
        {
            Destroy(enfant.gameObject);
        }
    }

    /// <summary>
    /// Retire les mod�les existants de la fen�tre
    /// </summary>
    private void ReinitialiserAffichageModele()
    {
        foreach(Transform enfant in zoneModeles.transform)
        {
            Destroy(enfant.gameObject);
        }
    }

    /// <summary>
    /// R�action de la fen�tre au changement de s�lection d'un mod�le
    /// </summary>
    /// <param name="affichable">L'item affichable s�lectionn�</param>
    public void ChangementModele(ISelectionAffichable affichable)
    {
        if(affichable is ModeleObjet modele)
        {
            ControleurJeu.Instance.ChangerModeleProduit(modele);
           
            // Pour chaque enfant on v�rifie si son contenu est celui du contr�leur
            foreach(Transform enfant in zoneModeles.transform)
            {
                if(enfant.TryGetComponent<ItemSelectionModele>(out var itemSelection))
                {
                    itemSelection.AfficherCommeSelectionne(
                        itemSelection.Affichable as ModeleObjet == ControleurJeu.Instance.ModeleSelectionne
                        );
                }
            }

            AfficherCouleurs(modele);
        }
        else
        {
            Debug.LogError("L'item s�lectionn� n'est pas un mod�le");
        }
    }         
   

    /// <summary>
    /// R�action de la fen�tre au changement de s�lection de la couleur
    /// </summary>
    /// <param name="affichable">L'item affichable s�lectionn�</param>
    public void ChangementCouleur(ISelectionAffichable affichable)
    {
        if(affichable is ModeleObjetCouleur couleur)
        {
            ControleurJeu.Instance.ChangerCouleurProduit(couleur);

            // Pour chaque enfant on v�rifie si son contenu est celui du contr�leur
            foreach(Transform enfant in zoneCouleurs.transform)
            {
                if(enfant.TryGetComponent<ItemSelectionModele>(out var itemSelection))
                {
                    itemSelection.AfficherCommeSelectionne(
                        itemSelection.Affichable as ModeleObjetCouleur == ControleurJeu.Instance.CouleurSelectionnee
                        );
                }
            }
        }

        else
        {
            Debug.LogError("L'item s�lectionn� n'est pas un mod�le");
        }
    }
}
