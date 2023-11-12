using UnityEngine;

/// <summary>
/// Contrôleur de caméra qui suit un gameObject dans le monde
/// </summary>
public class ControleurCamera : MonoBehaviour
{
    [SerializeField, Tooltip("Cible suivie par la caméra")]
    private GameObject cible;

    [SerializeField, Tooltip("Touche pour la rotation horaire de la caméra")]
    private KeyCode rotationHoraire = KeyCode.Q;

    [SerializeField, Tooltip("Touche pour la rotation anti-horaire de la caméra")]
    private KeyCode rotationAntiHoraire = KeyCode.E;

    [SerializeField, Tooltip("Angle parcouru à chaque rotation")]
    private float distanceRotation = 45f;

    // Vecteur de décalage entre la caméra et le personnage
    private Vector3 decalage;

    private void Start()
    {
        decalage = transform.position - cible.transform.position;
    }

    private void Update()
    {
        // Déplace la caméra
        transform.position = cible.transform.position + decalage; 
    
        // Touches de rotation
        if(Input.GetKeyDown(rotationAntiHoraire))
        {
            decalage = Quaternion.Euler(0.0f, -distanceRotation, 0.0f) * decalage;
            transform.Rotate(Vector3.up * -distanceRotation, Space.World);
        }
        if (Input.GetKeyDown(rotationHoraire))
        {
            decalage = Quaternion.Euler(0.0f, distanceRotation, 0.0f) * decalage;
            transform.Rotate(Vector3.up * distanceRotation, Space.World);
        }
    }


}
