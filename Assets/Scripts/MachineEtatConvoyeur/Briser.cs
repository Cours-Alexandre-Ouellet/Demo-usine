using UnityEngine;

/// <summary>
/// Gère l'état brisée du convoyeur. L'état brisé empêche le convoyeur d'avancer tant qu'il n'est pas réparé 
/// avec le contrôle adéquat.
/// </summary>
public class Briser : Etat
{
    public override void EntrerEtat(Convoyeur convoyeur, Etat etatPrecedent)
    {
        base.EntrerEtat(convoyeur, etatPrecedent);
        convoyeur.EstArrete = true;
        convoyeur.EstBrise = true;
        convoyeur.ReparationCompletee = false;      // Passe à l'état Briser
                                                    // (après le cours j'ai réalisé que tout pouvait se gérer avec EstBrise...)

    }

    public override Etat Executer(Convoyeur convoyeur)
    {
        // On appuie sur R
        if(Input.GetKeyDown(KeyCode.R))
        {
            convoyeur.DemarrerCompteurReparation();
        }
        
        // On relâche R
        if(Input.GetKeyUp(KeyCode.R))
        {
            convoyeur.ArreterReparation();
        }

        // Réparation complété = changement état
        if(convoyeur.ReparationCompletee)
        {
            return new Avancer();
        }

        return this;
    }

    public override void SortirEtat(Convoyeur convoyeur, Etat etatSuivant)
    {
        base.SortirEtat(convoyeur, etatSuivant);
        convoyeur.EstBrise = false;
    }
}
