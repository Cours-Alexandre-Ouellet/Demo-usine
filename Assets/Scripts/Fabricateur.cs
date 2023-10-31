using UnityEngine;

/// <summary>
/// Fabrique des objets dans le jeu en remplaçant leur Mesh par un autre Mesh
/// </summary>
[RequireComponent(typeof(BoxCollider))]
public class Fabricateur : MonoBehaviour
{
    [SerializeField, Tooltip("Le modèle de l'objet fabriqué")]
    private ModeleObjet modele;

    public ModeleObjet Modele { get { return modele; } set {  modele = value; } }

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
        meshARemplacer.mesh = modele.Mesh;

        // Changer la taille du collider
        BoxCollider colliderARedimensionner = objetATransformer.GetComponent<BoxCollider>();
        colliderARedimensionner.size = modele.Mesh.bounds.size;
        colliderARedimensionner.center = modele.Mesh.bounds.center;

        // Lancer l'animation
        Animator controleurAnimation = GetComponent<Animator>();
        controleurAnimation.SetTrigger("ObjetEntre");
        GetComponent<AudioSource>().Play();
        // Demande au convoyeur d'attendre
        convoyeur.Attendre(2.0f);   
    }
}
