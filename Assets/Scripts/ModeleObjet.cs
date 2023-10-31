using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Modele objet", menuName = "Usine/Modele objet")]
public class ModeleObjet : ScriptableObject
{
    [SerializeField]
    private Mesh mesh;
    public Mesh Mesh => mesh;

    [SerializeField]
    private string nom;
    public string Nom => nom;
}
