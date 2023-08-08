using Common;
using Cysharp.Threading.Tasks;
using Loading;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitialState : IState<Bootstrap>, IEnterable
{
    public Bootstrap Initializer { get; }
    public InitialState(Bootstrap initializer) => Initializer = initializer;

    private LoadingScreenProvider LoadingProvider => ProjectContext.I.LoadingScreenProvider;
    private AsyncOperation _sceneLoadOperation;

    public async void OnEnter()
    {
        _sceneLoadOperation = SceneManager.LoadSceneAsync(Constants.Scenes.INITIAL_SCENE);
        while(!_sceneLoadOperation.isDone)
            await UniTask.Yield();

        await InitializeProjectContext();
    }

    private async Task InitializeProjectContext()
    {
        ProjectContext.I.Initialize();

        var loadingOperations = new Queue<ILoadingOperation>();
        loadingOperations.Enqueue(ProjectContext.I.AssetProvider);
        loadingOperations.Enqueue(new MenuLoadingOperation());
        await LoadingProvider.LoadAndDestroy(loadingOperations);
    }
}