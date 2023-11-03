using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Composant graphique pour gestion des objets s�lectionn�s
/// </summary>
public class ItemSelectionModele : MonoBehaviour, IPointerClickHandler
{
    [SerializeField, Tooltip("Couleur de fond de base")]
    private Color couleurReguliere = Color.gray;

    [SerializeField, Tooltip("Couleur de fond lorsque s�lectionn�")]
    private Color couleurSelectionne = Color.cyan;

    [SerializeField, Tooltip("R�f�rence sur l'ic�ne affich�e.")]
    private Image icone;

    [SerializeField, Tooltip("Permet d'afficher le nom du mod�le")]
    private TextMeshProUGUI nomModele;

    public UnityEvent<ISelectionAffichable> onModeleChange;

    /// <summary>
    /// Mod�le qui est affich� par cet ItemSelection
    /// </summary>
    private ISelectionAffichable affichable;

    /// <summary>
    /// Accesseur de l'objet affich�
    /// </summary>
    public ISelectionAffichable Affichable => affichable;

    /// <summary>
    /// Affiche le contenu d'affichable dans la fen�ter
    /// </summary>
    /// <param name="affichable">L'item � afficher</param>
    public void Afficher(ISelectionAffichable affichable)
    {
        this.affichable = affichable;
        icone.sprite = affichable.Icone;
        nomModele.text = affichable.Nom;
    }

    // Impl�mentaiton de l'interface IPointerClickHandler
    public void OnPointerClick(PointerEventData eventData)
    {
        onModeleChange?.Invoke(affichable);
    }

    /// <summary>
    /// Change la couleur de fond selon si l'objet est s�lectionn� ou non
    /// </summary>
    /// <param name="selectionne">D�terminer si l'objet est s�lectionn�</param>
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
