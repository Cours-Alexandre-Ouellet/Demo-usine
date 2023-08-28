using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompteurObjet : MonoBehaviour
{
    public static CompteurObjet Instance { get; private set; }

    private int nombreCrees;

    private int nombreDetruits;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        nombreCrees = 0;
        nombreDetruits = 0;
    }

    public void AjouterCree(int nombreCrees = 1)
    {
        this.nombreCrees += nombreCrees;
        Debug.Log($"Nombre de crees {this.nombreCrees}.");
    }

    public void AjouterDetruits(int nombreDetruits = 1)
    {
        this.nombreDetruits += nombreDetruits;
        Debug.Log($"Nombre de detruits {this.nombreDetruits}.");
    }
}
