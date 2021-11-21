using UnityEngine;
using UnityEngine.EventSystems;

namespace DefaultNamespace
{
    public class PlayerInput : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public void OnBeginDrag(PointerEventData eventData)
        {
            
            Debug.Log($"'Start drag {eventData.clickCount}");
        }

        public void OnDrag(PointerEventData eventData)
        {
            Debug.Log($" drag");
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            Debug.Log($"End drag");
        }
    }
}