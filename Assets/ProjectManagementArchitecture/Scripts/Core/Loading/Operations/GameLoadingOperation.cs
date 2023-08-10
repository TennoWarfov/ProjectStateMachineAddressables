using System;
using Common;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;
using Utils.Extensions;

namespace Loading
{
    public class GameLoadingOperation : ILoadingOperation
    {
        public string Description => "Game loading...";

        private readonly GameLevelConfiguration _gameSceneLevel;

        public GameLoadingOperation(GameLevelConfiguration gameSceneLevel)
        {
            _gameSceneLevel = gameSceneLevel;
        }
        
        public async UniTask Load(Action<float> onProgress)
        {
            onProgress?.Invoke(0.5f);
            var loadOp = SceneManager.LoadSceneAsync(_gameSceneLevel.SceneAsset.name, LoadSceneMode.Single);
            while (loadOp.isDone == false)
                await UniTask.Yield();
            
            onProgress?.Invoke(0.7f);
            
            var scene = SceneManager.GetSceneByName(_gameSceneLevel.SceneAsset.name);
            var gameProcess = scene.GetRoot<GameProcess>();
            onProgress?.Invoke(0.85f);

            var environment = await ProjectContext.I.AssetProvider.LoadSceneAdditive(Constants.Scenes.ENVIRONMENT_SCENE);

            gameProcess.Initialize(environment, _gameSceneLevel.SceneAsset.name);
            gameProcess.BeginNewGame();
            onProgress?.Invoke(1.0f);
        }
    }
}