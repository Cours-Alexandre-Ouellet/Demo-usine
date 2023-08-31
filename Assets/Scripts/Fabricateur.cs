using UnityEngine;

/// <summary>
/// Fabrique des objets dans le jeu en remplaçant leur Mesh par un autre Mesh
/// </summary>
[RequireComponent(typeof(BoxCollider))]
public class Fabricateur : MonoBehaviour
{
    [SerializeField, Tooltip("Le mesh qui remplace le Mesh entrant")]
    private Mesh formeFabriquee;

    private void OnTriggerEnter(Collider other)
    {
        // On interragit pas avec les objets du layer immuable
        if(other.gameObject.layer == LayerMask.NameToLayer("Immuable"))
        {
            return;
        }

        // Objet à transformer
        GameObject objetATransformer = other.gameObject;

        // Remplacement du Mesh
        MeshFilter meshARemplacer = objetATransformer.GetComponent<MeshFilter>();
        meshARemplacer.mesh = formeFabriquee;

        // Changer la taille du collider
        BoxCollider colliderARedimensionner = objetATransformer.GetComponent<BoxCollider>();
        colliderARedimensionner.size = formeFabriquee.bounds.size;
        colliderARedimensionner.center = formeFabriquee.bounds.center;
    }
}
