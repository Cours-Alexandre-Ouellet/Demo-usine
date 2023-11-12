using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/// <summary>
/// Gère une zone de bris sur le convoyeur
/// </summary>
public class ZoneBris : MonoBehaviour
{
    // Événement de mécanicien qui entre dans la zone
    public UnityEvent onEntrerZone;

    // Événement de mécanicien qui sort de la zone
    public UnityEvent onSortirZone;

    /// <summary>
    /// Champs qui affiche la progression de la réparation au joueur
    /// </summary>
    [SerializeField]
    private Image imageProgression;

    /// <summary>
    /// Active la zone de bris (barre de réparation et effet de particule)
    /// </summary>
    public void Activer()
    {
        imageProgression.fillAmount = 0.0f;
        if(TryGetComponent(out ParticleSystem systeme))
        {
            systeme.Play();
        }
    }

    /// <summary>
    /// Modifie la progression de la réparation.
    /// </summary>
    /// <param name="progression">Le % de réparation complété</param>
    public void SetProgression(float progression)
    {
        imageProgression.fillAmount = progression;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Mecanicien"))
        {
            onEntrerZone.Invoke();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Mecanicien"))
        {
            onSortirZone.Invoke();
        }
    }
}
