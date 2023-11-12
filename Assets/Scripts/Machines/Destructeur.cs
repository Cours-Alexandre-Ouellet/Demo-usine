using UnityEngine;

/// <summary>
/// Détruit un objet qui entre dans sa zone
/// </summary>
public class Destructeur : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // N'interragit pas avec les objets du layer immuable
        if(other.gameObject.layer != LayerMask.NameToLayer("Immuable"))
        {
            Destroy(other.gameObject);
            CompteurObjets.Instance.AjouterDetruits();
        }
    }
}
