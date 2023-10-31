using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Composant graphique pour gestion des objets sélectionnés
/// </summary>
public class ItemSelectionModele : MonoBehaviour, IPointerClickHandler
{
    [SerializeField, Tooltip("Référence sur l'icône affichée.")]
    private Image icone;

    [SerializeField, Tooltip("Permet d'afficher le nom du modèle")]
    private TextMeshProUGUI nomModele;

    /// <summary>
    /// Modèle qui est affiché par cet ItemSelection
    /// </summary>
    private ModeleObjet modele;

    public void Afficher(ModeleObjet modele)
    {
        this.modele = modele;
        //icone.sprite = 
        nomModele.text = modele.Nom;
    }

    // Implémentaiton de l'interface IPointerClickHandler
    public void OnPointerClick(PointerEventData eventData)
    {
        ControleurJeu.Instance.ChangerModeleProduit(modele);
    }
}
