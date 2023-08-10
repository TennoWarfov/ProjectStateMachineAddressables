using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Loading;
using UnityEngine;
using Utils.Assets;
using static Common.Constants;

public class LoadingScreenProvider : LocalAssetLoader
{
    private Transform _projectContextTransform;

    public async UniTask LoadAndDestroy(Queue<ILoadingOperation> loadingOperations)
    {
        var loadingScreen = await Load<LoadingScreen>(AssetsConstants.LoadingScreen, CachedProjectContextTransform());
        await loadingScreen.Load(loadingOperations);
        Unload();
    }

    private Transform CachedProjectContextTransform()
    {
        if (_projectContextTransform != null)
            return _projectContextTransform;

        _projectContextTransform = ProjectContext.I.transform;
        return _projectContextTransform;
    }

    /*public async UniTask LoadAndDisable(Queue<ILoadingOperation> loadingOperations)
        {
            if(_cachedLoadingScreen == null)
            {
                Debug.Log("Loading screen cached");
                _cachedLoadingScreen = await Load<LoadingScreen>(AssetsConstants.LoadingScreen, ProjectContext.I.transform);
            }

            await _cachedLoadingScreen.Load(loadingOperations);
            //Unload();
        }*/
}
