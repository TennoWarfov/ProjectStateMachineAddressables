using Loading;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SceneChanger : MonoBehaviour
{
    [SerializeField] private GameLevelConfiguration _levelConfiguration;

    [HideInInspector, SerializeField] private Button _button;

    private void Awake()
    {
        _button.onClick.AddListener(ChangeScene);
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveListener(ChangeScene);
    }

    private async void ChangeScene()
    {
        var operations = new Queue<ILoadingOperation>();
        operations.Enqueue(new GameLoadingOperation(_levelConfiguration));
        await ProjectContext.I.LoadingScreenProvider.LoadAndDestroy(operations);
    }

    private void OnValidate()
    {
        if (_button != null)
            return;

        _button = GetComponent<Button>();
    }
}
