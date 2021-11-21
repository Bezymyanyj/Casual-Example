using System;
using DefaultNamespace.EventHadlers;
using EventBusSystem;
using EventBusSystem.LeopotamGroup.Events;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Hearts : MonoBehaviour
    {
        [SerializeField] private UnityEventBus unityEventBus;
        [SerializeField] private Image[] hearts;

        private int life;
        
        private EventBus bus;
        private void Start()
        {
            bus = unityEventBus.eventBus;
            
            bus.Subscribe<NegativeAnswer>(OnNegativeAnswer);
        }

        private void OnDestroy()
        {
            bus.Unsubscribe<NegativeAnswer>(OnNegativeAnswer);
        }


        private void OnNegativeAnswer(NegativeAnswer answer)
        {
            life--;
        }
    }
}