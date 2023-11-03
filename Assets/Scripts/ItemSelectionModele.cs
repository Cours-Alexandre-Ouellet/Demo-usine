using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Composant graphique pour gestion des objets sélectionnés
/// </summary>
public class ItemSelectionModele : MonoBehaviour, IPointerClickHandler
{
    [SerializeField, Tooltip("Couleur de fond de base")]
    private Color couleurReguliere = Color.gray;

    [SerializeField, Tooltip("Couleur de fond lorsque sélectionné")]
    private Color couleurSelectionne = Color.cyan;

    [SerializeField, Tooltip("Référence sur l'icône affichée.")]
    private Image icone;

    [SerializeField, Tooltip("Permet d'afficher le nom du modèle")]
    private TextMeshProUGUI nomModele;

    public UnityEvent<ISelectionAffichable> onModeleChange;

    /// <summary>
    /// Modèle qui est affiché par cet ItemSelection
    /// </summary>
    private ISelectionAffichable affichable;

    /// <summary>
    /// Accesseur de l'objet affiché
    /// </summary>
    public ISelectionAffichable Affichable => affichable;

    /// <summary>
    /// Affiche le contenu d'affichable dans la fenêter
    /// </summary>
    /// <param name="affichable">L'item à afficher</param>
    public void Afficher(ISelectionAffichable affichable)
    {
        this.affichable = affichable;
        icone.sprite = affichable.Icone;
        nomModele.text = affichable.Nom;
    }

    // Implémentaiton de l'interface IPointerClickHandler
    public void OnPointerClick(PointerEventData eventData)
    {
        onModeleChange?.Invoke(affichable);
    }

    /// <summary>
    /// Change la couleur de fond selon si l'objet est sélectionné ou non
    /// </summary>
    /// <param name="selectionne">Déterminer si l'objet est sélectionné</param>
    public void AfficherCommeSelectionne(bool selectionne)
    {
        if(selectionne)
        {
            GetComponent<Image>().color = couleurSelectionne;
        }
        else
        {
            GetComponent<Image>().color = couleurReguliere;
        }
    }
}
