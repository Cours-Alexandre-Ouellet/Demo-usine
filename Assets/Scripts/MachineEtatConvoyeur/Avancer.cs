using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Gère l'état avancer du convoyeur, qui correspond à l'état normal où les objets progressent sur le convoyeur.
/// </summary>
public class Avancer : Etat
{
    public override void EntrerEtat(Convoyeur convoyeur, Etat etatPrecedent)
    {
        base.EntrerEtat(convoyeur, etatPrecedent);
        convoyeur.EstArrete = false;
    }

    public override Etat Executer(Convoyeur convoyeur)
    {
        if(Random.value < convoyeur.ProbabiliteBris)
        {
            return new Briser();
        }
        if(convoyeur.TempsFabrication > 0.0f)
        {
            Fabriquer prochainEtat = new Fabriquer(convoyeur.TempsFabrication);
            convoyeur.TempsFabrication = 0.0f;
            return prochainEtat;
        }
        if(Input.GetKeyDown(KeyCode.K))
        {
            return new Attendre();
        }

        return this;
    }
}
