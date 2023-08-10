using Loading;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    private LoadingScreenProvider LoadingProvider => ProjectContext.I.LoadingScreenProvider;

    private async void Start()
    {
        ProjectContext.I.Initialize();

        var loadingOperations = new Queue<ILoadingOperation>();
        loadingOperations.Enqueue(ProjectContext.I.AssetProvider);
        loadingOperations.Enqueue(new MenuLoadingOperation());

        await LoadingProvider.LoadAndDestroy(loadingOperations);
    }
}