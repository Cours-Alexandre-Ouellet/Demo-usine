using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Objet de jeu qui peut changer la couleur des objets
/// </summary>
public class Peintureur : MonoBehaviour
{
    [SerializeField]
    private ModeleObjetCouleur modeleAAppliquer;

    /// <summary>
    /// Accesseur et mutateur de la couleur utilisée
    /// </summary>
    public ModeleObjetCouleur ModeleAAppliquer { 
        get { return modeleAAppliquer; } 
        set { modeleAAppliquer = value; }
    }

    public void OnTriggerEnter(Collider other)
    {
        // On interragit pas avec les objets du layer immuable
        if(other.gameObject.layer == LayerMask.NameToLayer("Immuable"))
        {
            return;
        }

        
        other.GetComponent<MeshRenderer>().materials = modeleAAppliquer.Couleurs;
    }
}
