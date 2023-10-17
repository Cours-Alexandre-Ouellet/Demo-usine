using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// G�re l'�tat d'attente (arr�t volontaire) du convoyeur
/// </summary>
public class Attendre : Etat
{
    public override void EntrerEtat(Convoyeur convoyeur, Etat etatPrecedent)
    {
        base.EntrerEtat(convoyeur, etatPrecedent);
        convoyeur.EstArrete = true;
    }

    public override Etat Executer(Convoyeur convoyeur)
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            return new Avancer();
        }

        return this;
    }

    public override void SortirEtat(Convoyeur convoyeur, Etat etatSuivant)
    {
        base.SortirEtat(convoyeur, etatSuivant);
        convoyeur.EstArrete=false;
    }
}
