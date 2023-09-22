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
    }

    public override Etat Executer(Convoyeur convoyeur)
    {
        if(Input.GetKey(KeyCode.R))
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
