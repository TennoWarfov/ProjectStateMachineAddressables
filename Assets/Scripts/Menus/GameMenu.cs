using Loading;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    [SerializeField] private GameProcess _gameProcess;
    [SerializeField] private Button _quickGameBtn;

    private SceneInstance _environment;

    public string SceneName => throw new NotImplementedException();

    private void Start()
    {
        _quickGameBtn.onClick.AddListener(OnGameButtonClicked);
    }

    private async void OnGameButtonClicked()
    {
        var operations = new Queue<ILoadingOperation>();
        operations.Enqueue(new ClearGameOperation(_gameProcess));
        //ProjectContext.I.AssetProvider.UnloadAdditiveScene(_environment).Forget();
        //ProjectContext.I.LoadingScreenProvider.LoadAndDestroy(operations).Forget();
    }
}
