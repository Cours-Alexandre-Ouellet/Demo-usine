using UnityEngine;

/// <summary>
/// Fabrique des objets dans le jeu en remplaçant leur Mesh par un autre Mesh
/// </summary>
[RequireComponent(typeof(BoxCollider))]
public class Fabricateur : MonoBehaviour
{
    [SerializeField, Tooltip("Le mesh qui remplace le Mesh entrant")]
    private Mesh formeFabriquee;

    [SerializeField, Tooltip("Convoyeur qui traverse ce fabricateur")]
    private Convoyeur convoyeur;

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

        // Lancer l'animation
        Animator controleurAnimation = GetComponent<Animator>();
        controleurAnimation.SetTrigger("ObjetEntre");
        // Demande au convoyeur d'attendre
        convoyeur.Attendre(2.0f);   
    }
}
