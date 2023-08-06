using UnityEngine;
using Core.Pause;

public class GameProcess : MonoBehaviour, ICleanUp, IPauseHandler
{
    public string SceneName => throw new System.NotImplementedException();

    public void Cleanup()
    {
        //TODO: cleaning up all data in game process scene
    }

    public void SetPaused(bool isPaused)
    {
        //TODO: set game on pause
    }
}
