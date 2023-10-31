using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
