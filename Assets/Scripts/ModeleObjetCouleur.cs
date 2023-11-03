using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Patron de couleur qui peut êter appliqué à un objet 
/// </summary>
[CreateAssetMenu(fileName = "Modele objet couleur", menuName = "Usine/Modele objet couleur")]
public class ModeleObjetCouleur : ScriptableObject, ISelectionAffichable
{
    [SerializeField]
    private Material[] couleurs;
    public Material[] Couleurs => couleurs;

    [SerializeField]
    private string nomCouleur;
    public string Nom => nomCouleur;

    [SerializeField]
    private Sprite icone;
    public Sprite Icone => icone;
}
