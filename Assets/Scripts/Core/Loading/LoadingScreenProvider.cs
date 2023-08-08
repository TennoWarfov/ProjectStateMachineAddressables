using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Loading;
using UnityEngine;
using Utils.Assets;

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
        Debug.Log("Project context transform cached.");
        return _projectContextTransform;
    }
}
