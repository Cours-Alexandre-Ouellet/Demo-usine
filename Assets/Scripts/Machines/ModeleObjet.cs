using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Modèle d'objet qui peut être fabriqué
/// </summary>
[CreateAssetMenu(fileName = "Modele objet", menuName = "Usine/Modele objet")]
public class ModeleObjet : ScriptableObject, ISelectionAffichable
{
    [SerializeField]
    private Mesh mesh;
    public Mesh Mesh => mesh;

    [SerializeField]
    private string nom;
    public string Nom => nom;

    [SerializeField]
    private Sprite icone;
    public Sprite Icone => icone;

    [SerializeField]
    private ModeleObjetCouleur[] couleursPossibles;

    public ModeleObjetCouleur[] CouleursPossibles => couleursPossibles;
}
