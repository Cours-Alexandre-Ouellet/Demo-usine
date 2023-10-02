using UnityEngine;

/// <summary>
/// G�re l'�tat bris�e du convoyeur. L'�tat bris� emp�che le convoyeur d'avancer tant qu'il n'est pas r�par� 
/// avec le contr�le ad�quat.
/// </summary>
public class Briser : Etat
{
    public override void EntrerEtat(Convoyeur convoyeur, Etat etatPrecedent)
    {
        base.EntrerEtat(convoyeur, etatPrecedent);
        convoyeur.EstArrete = true;
        convoyeur.EstBrise = true;
        convoyeur.ReparationCompletee = false;      // Passe � l'�tat Briser
                                                    // (apr�s le cours j'ai r�alis� que tout pouvait se g�rer avec EstBrise...)

    }

    public override Etat Executer(Convoyeur convoyeur)
    {
        // On appuie sur R
        if(Input.GetKeyDown(KeyCode.R))
        {
            convoyeur.DemarrerCompteurReparation();
        }
        
        // On rel�che R
        if(Input.GetKeyUp(KeyCode.R))
        {
            convoyeur.ArreterReparation();
        }

        // R�paration compl�t� = changement �tat
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
