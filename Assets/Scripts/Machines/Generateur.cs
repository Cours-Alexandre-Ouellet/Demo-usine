using UnityEngine;

/// <summary>
/// G�n�re un objet � chaque fois que la touche est press�e.
/// </summary>
public class Generateur : MonoBehaviour
{
    [SerializeField, Tooltip("Mod�le d'objet � cloner.")]
    private GameObject prototype;

    [SerializeField, Tooltip("G�n�re un objet � chaque fois que cette touche est press�e.")]
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
