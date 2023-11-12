using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Fenêtre contextuelle qui s'anime lors de son ouverture et sa fermeture
/// </summary>
[RequireComponent(typeof(Animator))]
public class FenetreContextuelle : MonoBehaviour
{
    public virtual void Ouvrir()
    {
        GetComponent<Animator>().SetBool("EstOuvert", true);
    }

    public void Fermer()
    {
        GetComponent<Animator>().SetBool("EstOuvert", false);
    }
}
