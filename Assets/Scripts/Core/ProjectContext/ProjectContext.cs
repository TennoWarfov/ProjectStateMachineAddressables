using Core.Pause;
using UnityEngine;
using Utils.Assets;

public class ProjectContext : MonoBehaviour
{
    public LoadingScreenProvider LoadingScreenProvider { get; private set; }
    public AssetProvider AssetProvider { get; private set; }
    public PauseManager PauseManager { get; private set; }

    public static ProjectContext I { get; private set; }

    private void Awake()
    {
        I = this;
        DontDestroyOnLoad(this);
    }

    public void Initialize()
    {
        LoadingScreenProvider = new LoadingScreenProvider();
        AssetProvider = new AssetProvider();
        PauseManager = new PauseManager();
    }
}