using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Spécialisation de FenetreContextuelle en une fenêtre de sélection de modèles
/// </summary>
public class FenetreSelectionModele : FenetreContextuelle
{
    [SerializeField, Tooltip("Zone où afficher les modèles à construire")]
    private GameObject zoneModeles;

    [SerializeField, Tooltip("Zone où afficher les couleurs à appliquer")]
    private GameObject zoneCouleurs;

    [SerializeField, Tooltip("Prototype d'item à afficher")]
    private ItemSelectionModele prototypeItemSelection;

    /// <inheritdoc/>
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
    /// Affiche les couleurs disponibles pour un modèle
    /// </summary>
    /// <param name="modele">Le modèle pour lequel afficher les couleurs disponibles</param>
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
    /// Retire les modèles existants de la fenêtre
    /// </summary>
    private void ReinitialiserAffichageModele()
    {
        foreach(Transform enfant in zoneModeles.transform)
        {
            Destroy(enfant.gameObject);
        }
    }

    /// <summary>
    /// Réaction de la fenêtre au changement de sélection d'un modèle
    /// </summary>
    /// <param name="affichable">L'item affichable sélectionné</param>
    public void ChangementModele(ISelectionAffichable affichable)
    {
        if(affichable is ModeleObjet modele)
        {
            ControleurJeu.Instance.ChangerModeleProduit(modele);
           
            // Pour chaque enfant on vérifie si son contenu est celui du contrôleur
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
            Debug.LogError("L'item sélectionné n'est pas un modèle");
        }
    }         
   

    /// <summary>
    /// Réaction de la fenêtre au changement de sélection de la couleur
    /// </summary>
    /// <param name="affichable">L'item affichable sélectionné</param>
    public void ChangementCouleur(ISelectionAffichable affichable)
    {
        if(affichable is ModeleObjetCouleur couleur)
        {
            ControleurJeu.Instance.ChangerCouleurProduit(couleur);

            // Pour chaque enfant on vérifie si son contenu est celui du contrôleur
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
            Debug.LogError("L'item sélectionné n'est pas un modèle");
        }
    }
}
