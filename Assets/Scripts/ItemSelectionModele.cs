using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Composant graphique pour gestion des objets s�lectionn�s
/// </summary>
public class ItemSelectionModele : MonoBehaviour, IPointerClickHandler
{
    [SerializeField, Tooltip("R�f�rence sur l'ic�ne affich�e.")]
    private Image icone;

    [SerializeField, Tooltip("Permet d'afficher le nom du mod�le")]
    private TextMeshProUGUI nomModele;

    /// <summary>
    /// Mod�le qui est affich� par cet ItemSelection
    /// </summary>
    private ModeleObjet modele;

    public void Afficher(ModeleObjet modele)
    {
        this.modele = modele;
        //icone.sprite = 
        nomModele.text = modele.Nom;
    }

    // Impl�mentaiton de l'interface IPointerClickHandler
    public void OnPointerClick(PointerEventData eventData)
    {
        ControleurJeu.Instance.ChangerModeleProduit(modele);
    }
}
