using UnityEngine;

/// <summary>
/// G�re un convoyeur d'objets
/// </summary>
public class Convoyeur : MonoBehaviour
{
    [SerializeField, Tooltip("Vitesse � laquelle l'objet est transport�.")]
    private float vitesse = 2.0f;

    [SerializeField]
    private float vitesseMinimal = 0.0f;

    [SerializeField]
    private float vitesseMaximale = 5.0f;

    [SerializeField, Tooltip("Direction dans laquelle l'objet est envoy�.")]
    private Vector3 direction;

    private void Awake()
    {
        direction.Normalize();
    }

    public void ChangerVitesse(float pourcentageVitesse)
    {
        vitesse = Mathf.Lerp(vitesseMinimal, vitesseMaximale, pourcentageVitesse);
    }

    private void OnCollisionStay(Collision collision)
    {
        collision.rigidbody.transform.position += vitesse * Time.deltaTime * direction;
    }

    private void OnCollisionExit(Collision collision)
    {
        Rigidbody rigidbodyCollision = collision.rigidbody;
        rigidbodyCollision.AddForce(vitesse * direction, ForceMode.Impulse);
    }
}
