using UnityEngine;

/// <summary>
/// Génère un objet à chaque fois que la touche est pressée.
/// </summary>
public class Generateur : MonoBehaviour
{
    [SerializeField, Tooltip("Modèle d'objet à cloner.")]
    private GameObject prototype;

    [SerializeField, Tooltip("Génère un objet à chaque fois que cette touche est pressée.")]
    private KeyCode toucheGeneration = KeyCode.Space;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(toucheGeneration))
        {
            GameObject nouvelleInstance = Instantiate(prototype, transform);
            CompteurObjets.Instance.AjouterCrees();
        }
    }
}
