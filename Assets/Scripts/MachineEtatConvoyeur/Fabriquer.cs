using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �tat du convoyeur pendant lequel il fabrique un objet sur la ligne de montage. Le convoyeur ne bouge pas durant ce temps
/// et ne peut pas briser.
/// </summary>
public class Fabriquer : Etat
{
    /// <summary>
    /// Temps requis pour fabriquer un objet (temps d'arr�t de la ligne)
    /// </summary>
    private float tempsFabrication;

    /// <summary>
    /// Temps �coul� depuis le d�but de la fabrication
    /// </summary>
    private float tempsEcoule;

    /// <summary>
    /// Construit un nouvel �tat de fabrication avec le temps n�cessaire d'indiquer
    /// </summary>
    /// <param name="tempsFabrication">Le temps n�cessaire pour fabriquer l'objet</param>
    public Fabriquer(float tempsFabrication)
    {
        this.tempsFabrication = tempsFabrication;
        tempsEcoule = 0.0f;
    }

    /// <inheritdoc/>
    public override void EntrerEtat(Convoyeur convoyeur, Etat etatPrecedent)
    {
        base.EntrerEtat(convoyeur, etatPrecedent);
        convoyeur.EstArrete = true;
    }

    /// <inheritdoc/>
    public override Etat Executer(Convoyeur convoyeur)
    {
        if(tempsEcoule > tempsFabrication)
        {
            return new Avancer();
        }
        else
        {
            tempsEcoule += Time.deltaTime;
        }

        return this;
    }

    /// <inheritdoc/>
    public override void SortirEtat(Convoyeur convoyeur, Etat etatSuivant)
    {
        base.SortirEtat(convoyeur, etatSuivant);
        convoyeur.EstArrete = false;
    }
}
