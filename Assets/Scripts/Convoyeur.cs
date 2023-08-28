using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Convoyeur : MonoBehaviour
{
    [SerializeField]
    private float vitesse = 2.0f;

    [SerializeField]
    private Vector3 direction;

    private void Awake()
    {
        direction.Normalize();
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
