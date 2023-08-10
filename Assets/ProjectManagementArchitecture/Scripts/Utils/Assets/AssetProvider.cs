using System;
using Cysharp.Threading.Tasks;
using Loading;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace Utils.Assets
{
    public class AssetProvider : ILoadingOperation
    {
        public string Description => "Assets Initialization...";

        private bool _isReady;

        private async UniTask WaitUntilReady()
        {
            while (_isReady == false)
            {
                await UniTask.Yield();
            }
        }

        public async UniTask<SceneInstance> LoadSceneAdditive(string sceneId)
        {
            await WaitUntilReady();
            var operation = Addressables.LoadSceneAsync(sceneId, LoadSceneMode.Additive);
            return await operation.Task;
        }

        public async UniTask UnloadAdditiveScene(SceneInstance scene)
        {
            await WaitUntilReady();
            var operation = Addressables.UnloadSceneAsync(scene);
            await operation.Task;
        }


        public async UniTask Load(Action<float> onProgress)
        {
            var operation = Addressables.InitializeAsync();
            await operation.Task;
            _isReady = true;
        }
    }
}