using System;
using EventBusSystem;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace DefaultNamespace
{
    public class LoaderSettings : MonoBehaviour
    {
        [SerializeField] private AssetReference gameSettings;

        [SerializeField] private UnityEventBus unityEventBus;

        private void Awake()
        {
            Addressables.LoadAssetAsync<TextAsset>(gameSettings).Completed += handle =>
            {
                if (handle.Status == AsyncOperationStatus.Succeeded)
                {
                    var textAsset = handle.Result;
                    var text = textAsset.text;

                    var a = new GameSettings(text);
                }
            };
        }
    }
}