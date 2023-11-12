using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Mécanicien responsable du bon fonctionnement de l'usine
/// </summary>
public class Mecanicien : MonoBehaviour
{
    // Référence sur l'agent 
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>(); 
    }

    /// <summary>
    /// Déplace le mécanicien vers la position indiquée s'il peut l'atteindre
    /// </summary>
    /// <param name="position">La position que l'on souhaite atteindre</param>
    public void Deplacer(Vector3 position)
    {
        NavMeshPath chemin = new();
        agent.CalculatePath(position, chemin);

        if (chemin.status == NavMeshPathStatus.PathComplete)
        {
            agent.SetDestination(position);
        }
    }
}
