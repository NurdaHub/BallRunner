using UnityEngine;
using UnityEngine.EventSystems;

public class EventDetector : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        PlayerController.Instance.OnPointerStateChanged(eventData, true);
    }
    
    public void OnPointerUp(PointerEventData eventData)
    {
        PlayerController.Instance.OnPointerStateChanged(null, false);
    }
}
