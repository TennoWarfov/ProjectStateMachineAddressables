using Loading;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _quickGameBtn;

    private void Start()
    {
        _quickGameBtn.onClick.AddListener(OnGameButtonClicked);
    }

    private void OnGameButtonClicked()
    {
        var operations = new Queue<ILoadingOperation>();
        operations.Enqueue(new GameLoadingOperation());
        _ = ProjectContext.I.LoadingScreenProvider.LoadAndDestroy(operations);
    }
}
