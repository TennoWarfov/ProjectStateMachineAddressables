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

        private string _gameSceneLevel;

        public GameLoadingOperation(string gameSceneLevel)
        {
            _gameSceneLevel = gameSceneLevel;
        }

        
        public async UniTask Load(Action<float> onProgress)
        {
            onProgress?.Invoke(0.5f);
            var loadOp = SceneManager.LoadSceneAsync(_gameSceneLevel, LoadSceneMode.Single);
            while (loadOp.isDone == false)
                await UniTask.Yield();
            
            onProgress?.Invoke(0.7f);
            
            var scene = SceneManager.GetSceneByName(Constants.Scenes.GAME_LEVEL_SCENE_1);
            var gameProcess = scene.GetRoot<GameProcess>();
            onProgress?.Invoke(0.85f);

            var environment = await ProjectContext.I.AssetProvider.LoadSceneAdditive("Environment");
            onProgress?.Invoke(1.0f);

            gameProcess.Initialize();
        }
    }
}