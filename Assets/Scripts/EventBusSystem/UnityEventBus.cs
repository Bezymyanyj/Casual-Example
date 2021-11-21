using System;
using EventBusSystem.LeopotamGroup.Events;
using UnityEngine;

namespace EventBusSystem
{
    public class UnityEventBus : MonoBehaviour
    {
        public EventBus eventBus { get; private set; }

        private void Awake()
        {
            eventBus = new EventBus();
        }
    }
}