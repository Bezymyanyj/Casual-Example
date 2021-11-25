using System;
using DefaultNamespace.EventHadlers;
using EventBusSystem.LeopotamGroup.Events;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class Card : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer cardImage;


        private EventBus bus;
        public void SetImage(Sprite sprite)
        {
            cardImage.sprite = sprite;
        }

        public void SetBus(EventBus bus)
        {
            this.bus = bus;
        }


        public void Move(Vector2 position)
        {
            transform.localPosition += new Vector3(position.x , 0, 0);
        }


        private void Update()
        {
            if (transform.position.x > 3 || transform.position.x < -3)
            {
                bus.Publish(new LaunchFabricHandler());
                Destroy(this.gameObject);
            }
        }
    }
}