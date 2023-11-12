using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

// Représente le sol dans le jeu
public class Sol : MonoBehaviour, IPointerClickHandler
{
    // Lorsque l'on clic sur le sol
    public UnityEvent<Vector3> onClicSol;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log($"Deplacement vers {eventData.pointerCurrentRaycast.worldPosition}.");
        onClicSol.Invoke(eventData.pointerCurrentRaycast.worldPosition);
    }
}
