using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Formatte plusieurs valeurs selon une chaîne déterminée. Les éléments à substituer sont indiqué par {x} ou x est un nombre plus grand ou égal à 1
/// </summary>
[RequireComponent(typeof(TextMeshProUGUI))]
public class FormatteurTexteComplet : MonoBehaviour
{
    /// <summary>
    /// Modèle de texte qui doit être utilisé pour la substitution
    /// </summary>
    private string modeleTexte;

    [SerializeField]
    private ChangeurValeur conteneurValeurs;

    private void Awake()
    {
        modeleTexte = GetComponent<TextMeshProUGUI>().text;
    }

    private void Start()
    {
        conteneurValeurs.OnChangementValeur += FormatterValeurs;
        FormatterValeurs(conteneurValeurs.GetValeurs());
    }

    /// <summary>
    /// Modifie le texte affiché pour substituer toutes les occurences de {x} par la valeur dans le tableau. Les valeurs doivent être consécutives
    /// </summary>
    /// <param name="valeurs">Les valeurs à substituer dans la chaine.</param>
    public void FormatterValeurs(params object[] valeurs)
    {
        int index = 0;
        string chaine = modeleTexte;

        while(index < valeurs.Length && Substituer(valeurs[index], index + 1, ref chaine))
        {
            index++;
        }

        GetComponent<TextMeshProUGUI>().text = chaine;
    }

    /// <summary>
    /// Remplace la séquence {indice} dans chaîne par la valeur indiquée et retourne vrai si la substitution a eu lieu
    /// </summary>
    /// <param name="valeur">La valeur à remplacer</param>
    /// <param name="indice">L'indice auquel faire le remplacement</param>
    /// <param name="chaine">La chaîne dans laquelle faire la substitution</param>
    /// <returns>True si la substitution a eu lieu, false autrement</returns>
    private bool Substituer(object valeur, int indice, ref string chaine)
    {
        string valeurChaine = valeur.ToString();
 
        chaine = chaine.Replace($"{{{indice}}}", valeurChaine);
        return true;
    }
}
