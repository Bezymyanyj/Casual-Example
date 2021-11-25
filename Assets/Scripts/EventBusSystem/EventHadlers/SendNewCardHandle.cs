using UnityEngine;

namespace DefaultNamespace.EventHadlers
{
    public class SendNewCardHandle
    {
        public Card Card;
        public Vector3 StartPosition;
        public SendNewCardHandle(Card card, Vector3 position)
        {
            Card = card;
            StartPosition = position;
        }
    }
}