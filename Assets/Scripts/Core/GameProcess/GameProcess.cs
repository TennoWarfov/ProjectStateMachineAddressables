using UnityEngine;
using Core.Pause;

public class GameProcess : MonoBehaviour, ICleanUp, IPauseHandler
{
    public string SceneName { get => _sceneName; set => _sceneName = value; }

    private string _sceneName;

    public void Initialize()
    {
        //TODO: initialize scene components
    }

    public void Cleanup()
    {
        //TODO: cleaning up all data in game process scene
    }

    public void SetPaused(bool isPaused)
    {
        //TODO: set game on pause
    }
}
