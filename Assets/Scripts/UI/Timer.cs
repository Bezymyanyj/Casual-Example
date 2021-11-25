using System;
using DefaultNamespace.EventHadlers;
using EventBusSystem;
using EventBusSystem.LeopotamGroup.Events;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private UnityEventBus unityEventBus;
        
        [SerializeField] private TextMeshProUGUI timerText;
        [SerializeField] private Image magicCircle;
        [SerializeField] private Slider slider;

        private EventBus bus;

        private int timerClock;
        private int baseTimerValue = 10;

        private float timer;
        private void Start()
        {
            bus = unityEventBus.eventBus;

            slider.maxValue = baseTimerValue;
            
            bus.Subscribe<PositiveAnswer>(OnPositiveAnswer);
            bus.Subscribe<NegativeAnswer>(OnNegativeAnswer);
        }


        private void Update()
        {
            timer += Time.deltaTime;
            slider.value -= Time.deltaTime;
            if (timer >= 1)
            {
                timer = 0;
                timerClock--;
                if (timerClock <= 1)
                {
                    bus.Publish(new NegativeAnswer());
                }
            }
        }

        private void OnPositiveAnswer(PositiveAnswer answer)
        {
            reloadTimer();
        }

        private void OnNegativeAnswer(NegativeAnswer answer)
        {
            reloadTimer();
        }

        private void reloadTimer()
        {
            timer = 0;
            timerClock = baseTimerValue;
            slider.value = baseTimerValue;
            timerText.text = timerClock.ToString();
        }
    }
}