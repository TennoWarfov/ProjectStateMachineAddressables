using Core.Pause;
using Cysharp.Threading.Tasks;
using GameResult;
using Loading;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.ResourceManagement.ResourceProviders;
using Core.UI;

public class GameProcess : MonoBehaviour, ICleanUp, IPauseHandler
{
    public string SceneName => _sceneName;

    [SerializeField] private Hud _hud;
    [SerializeField] private GameResultWindow _gameResultWindow; // show this when game finished

    private SceneInstance _environment;
    private string _sceneName;

    public void Initialize(SceneInstance environment, string sceneName)
    {
        _sceneName = sceneName;
        _environment = environment;

        ProjectContext.I.PauseManager.Register(this);
    }

    public void BeginNewGame()
    {
        Cleanup();
        _hud.QuitGame += GoToMainMenu;
    }

    public void Cleanup()
    {
        _hud.QuitGame -= GoToMainMenu;
    }

    private void GoToMainMenu()
    {
        var operations = new Queue<ILoadingOperation>();
        operations.Enqueue(new ClearGameOperation(this));
        ProjectContext.I.AssetProvider.UnloadAdditiveScene(_environment).Forget();
        ProjectContext.I.LoadingScreenProvider.LoadAndDestroy(operations).Forget();
    }

    public void SetPaused(bool isPaused)
    {
        //TODO: set scene creatures to paused mode
    }
}
