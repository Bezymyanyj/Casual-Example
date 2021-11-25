
using DefaultNamespace;
using DefaultNamespace.EventHadlers;
using EventBusSystem.LeopotamGroup.Events;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Random = UnityEngine.Random;

namespace EventBusSystem
{
    public class CardsFabric : MonoBehaviour
    {
        [SerializeField] private AssetReferenceGameObject baseCard;
        [SerializeField] private AssetReferenceSprite[] cardImages;

        [SerializeField] private UnityEventBus unityEventBus;
        
        private EventBus bus;
        private int imageIndex;
        private Card newCard;
        private Transform parent;

        private void Awake()
        {
            cardImages = Shuffle(cardImages);
        }

        private void Start()
        {
            bus = unityEventBus.eventBus;
            
            bus.Subscribe<LaunchFabricHandler>(OnLaunchFabric);
            GetNewCard();
        }

        private void OnLaunchFabric(LaunchFabricHandler data)
        {
            GetNewCard();
        }

        public void GetNewCard()
        {
            if (imageIndex >= cardImages.Length)
            {
                //eng game
            }
            Addressables.LoadAssetAsync<GameObject>(baseCard).Completed += obj =>
            {
                if (obj.Status == AsyncOperationStatus.Succeeded)
                {
                    var loadedObject = obj.Result;
                    var instantiatedObject = Instantiate(loadedObject, transform);
                    newCard = instantiatedObject.GetComponent<Card>();
                    bus.Publish(new SendNewCardHandle(newCard, newCard.transform.position));
                    Addressables.LoadAssetAsync<Sprite>(cardImages[imageIndex++]).Completed += handle =>
                    {
                        if (handle.Status == AsyncOperationStatus.Succeeded)
                        {
                            var loadedSprite = handle.Result;
                            newCard.SetImage(loadedSprite);
                            newCard.SetBus(bus);
                        }
                    };
                }
            };
        }
        private AssetReferenceSprite[] Shuffle(AssetReferenceSprite[]  sequence)
        {
            var n = sequence.Length;
            while (n > 1)
            {
                n--;
                var k = Random.Range(0, n + 1);
                (sequence[k], sequence[n]) = (sequence[n], sequence[k]);
            }
            return sequence;
        }
    }
}