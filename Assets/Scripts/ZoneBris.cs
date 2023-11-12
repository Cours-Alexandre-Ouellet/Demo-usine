using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/// <summary>
/// G�re une zone de bris sur le convoyeur
/// </summary>
public class ZoneBris : MonoBehaviour
{
    // �v�nement de m�canicien qui entre dans la zone
    public UnityEvent onEntrerZone;

    // �v�nement de m�canicien qui sort de la zone
    public UnityEvent onSortirZone;

    /// <summary>
    /// Champs qui affiche la progression de la r�paration au joueur
    /// </summary>
    [SerializeField]
    private Image imageProgression;

    /// <summary>
    /// Active la zone de bris (barre de r�paration et effet de particule)
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
    /// Modifie la progression de la r�paration.
    /// </summary>
    /// <param name="progression">Le % de r�paration compl�t�</param>
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
