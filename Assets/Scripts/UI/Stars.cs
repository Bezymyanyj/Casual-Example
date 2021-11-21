using DefaultNamespace.EventHadlers;
using EventBusSystem;
using EventBusSystem.LeopotamGroup.Events;
using TMPro;
using UnityEngine;

namespace UI
{
    public class Stars : MonoBehaviour
    {
        [SerializeField] private UnityEventBus unityEventBus;
        [SerializeField] private TextMeshProUGUI stars;

        private int starsAmount;
        
        private EventBus bus;
        private void Start()
        {
            bus = unityEventBus.eventBus;
            
            bus.Subscribe<PositiveAnswer>(OnPositiveAnswer);
        }

        private void OnDestroy()
        {
            bus.Unsubscribe<PositiveAnswer>(OnPositiveAnswer);
        }

        private void OnPositiveAnswer(PositiveAnswer answer)
        {
            starsAmount++;
            stars.text = starsAmount.ToString();
        }
    }
}