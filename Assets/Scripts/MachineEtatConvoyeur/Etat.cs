using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe abstraite d'états possibles pour le convoyeur
/// </summary>
public abstract class Etat
{
    /// <summary>
    /// Traitement effectué lorsque le convoyeur entre dans l'état
    /// </summary>
    /// <param name="convoyeur">Le convoyeur géré</param>
    /// <param name="etatPrecedent">L'état dans lequel le convoyeur était à la frame précédente</param>
    public virtual void EntrerEtat(Convoyeur convoyeur, Etat etatPrecedent)
    {
        Debug.Log($"Entrer dans l'état {GetType().Name}");
    }

    /// <summary>
    /// Effectue le traitement du convoyeur pendant une frame durant laquelle le convoyeur est dans l'état.
    /// Cette méthode est appelée à chaque frame.
    /// </summary>
    /// <param name="convoyeur">Le convoyeur géré</param>
    /// <returns></returns>
    public abstract Etat Executer(Convoyeur convoyeur);

    /// <summary>
    /// Traitement effectué lorsque le convoyeur quitte l'état
    /// </summary>
    /// <param name="convoyeur">Le convoyeur géré</param>
    /// <param name="etatSuivant">L'état dans lequel le convoyeur sera à la frame suivante</param>
    public virtual void SortirEtat(Convoyeur convoyeur, Etat etatSuivant)
    {
        Debug.Log($"Sortie de l'état {GetType().Name}");
    }

}
