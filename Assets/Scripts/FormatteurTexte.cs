using UnityEngine;
using TMPro;

/// <summary>
/// Formatte le texte d'un TextMeshPro pour y inclure une valeur enti�re
/// </summary>
[RequireComponent(typeof(TextMeshProUGUI))]
public class FormatteurTexte : MonoBehaviour
{
    /// <summary>
    /// Mod�le de texte qui doit �tre utilis� pour la substitution
    /// </summary>
    private string modeleTexte;

    
    void Awake()
    {
        // R�cup�re le mod�le de texte du composant
        modeleTexte = GetComponent<TextMeshProUGUI>().text;
    }

    /// <summary>
    /// Modifie la valeur du champ par l'entier indiqu�.
    /// </summary>
    /// <param name="valeur">La valeur qui est � ins�rer dans zone</param>
    public void ChangerValeur(int valeur)
    {
        GetComponent<TextMeshProUGUI>().text = modeleTexte.Replace("##", valeur.ToString());
    }
}
