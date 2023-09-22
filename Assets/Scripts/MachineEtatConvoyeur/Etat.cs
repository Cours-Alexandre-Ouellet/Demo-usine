using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe abstraite d'�tats possibles pour le convoyeur
/// </summary>
public abstract class Etat
{
    /// <summary>
    /// Traitement effectu� lorsque le convoyeur entre dans l'�tat
    /// </summary>
    /// <param name="convoyeur">Le convoyeur g�r�</param>
    /// <param name="etatPrecedent">L'�tat dans lequel le convoyeur �tait � la frame pr�c�dente</param>
    public virtual void EntrerEtat(Convoyeur convoyeur, Etat etatPrecedent)
    {
        Debug.Log($"Entrer dans l'�tat {GetType().Name}");
    }

    /// <summary>
    /// Effectue le traitement du convoyeur pendant une frame durant laquelle le convoyeur est dans l'�tat.
    /// Cette m�thode est appel�e � chaque frame.
    /// </summary>
    /// <param name="convoyeur">Le convoyeur g�r�</param>
    /// <returns></returns>
    public abstract Etat Executer(Convoyeur convoyeur);

    /// <summary>
    /// Traitement effectu� lorsque le convoyeur quitte l'�tat
    /// </summary>
    /// <param name="convoyeur">Le convoyeur g�r�</param>
    /// <param name="etatSuivant">L'�tat dans lequel le convoyeur sera � la frame suivante</param>
    public virtual void SortirEtat(Convoyeur convoyeur, Etat etatSuivant)
    {
        Debug.Log($"Sortie de l'�tat {GetType().Name}");
    }

}
