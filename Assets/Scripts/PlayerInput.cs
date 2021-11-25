using System;
using DefaultNamespace.EventHadlers;
using EventBusSystem;
using EventBusSystem.LeopotamGroup.Events;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DefaultNamespace
{
    public class PlayerInput : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {

        [SerializeField] private UnityEventBus unityEventBus;
        
        private Card card;
        private Vector3 startPosition;
        
        private EventBus bus;
        private void Start()
        {
            bus = unityEventBus.eventBus;

            bus.Subscribe<SendNewCardHandle>(OnNewCardCreated);
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            //select card
            Debug.Log($"'Start drag {eventData.clickCount}");
        }

        public void OnDrag(PointerEventData eventData)
        {
            Vector3 screenCenter = 
                new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, -Camera.main.transform.position.z);
            Vector3 screenTouch = screenCenter + new Vector3(eventData.delta.x, eventData.delta.y, 0);
            
            Vector3 worldCenterPosition = Camera.main.ScreenToWorldPoint(screenCenter);
            Vector3 worldTouchPosition = Camera.main.ScreenToWorldPoint(screenTouch);

            Vector3 delta = worldTouchPosition - worldCenterPosition;
            card.Move(delta);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            card.transform.position = startPosition;
            //unselect card
            //retern to start position
            Debug.Log($"End drag");
        }

        private void OnNewCardCreated(SendNewCardHandle data)
        {
            card = data.Card;
            startPosition = data.StartPosition;
        }
    }
}