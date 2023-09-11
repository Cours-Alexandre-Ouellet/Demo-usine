using UnityEngine;
using TMPro;

/// <summary>
/// Formatte le texte d'un TextMeshPro pour y inclure une valeur entière
/// </summary>
[RequireComponent(typeof(TextMeshProUGUI))]
public class FormatteurTexte : MonoBehaviour
{
    /// <summary>
    /// Modèle de texte qui doit être utilisé pour la substitution
    /// </summary>
    private string modeleTexte;

    [SerializeField]
    private ChangeurValeur conteneurEntier;

    void Awake()
    {
        // Récupère le modèle de texte du composant
        modeleTexte = GetComponent<TextMeshProUGUI>().text;
    }

    private void Start()
    {
        //conteneurEntier.OnChangementValeur += ChangerValeur;
    }

    /// <summary>
    /// Modifie la valeur du champ par l'entier indiqué.
    /// </summary>
    /// <param name="valeur">La valeur qui est à insérer dans zone</param>
    public void ChangerValeur(int valeur)
    {
        GetComponent<TextMeshProUGUI>().text = modeleTexte.Replace("##", valeur.ToString());
    }
}
