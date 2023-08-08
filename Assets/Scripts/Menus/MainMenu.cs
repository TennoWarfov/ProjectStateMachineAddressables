using Loading;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using static Common.Constants;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button[] _gameLevelButton;

    private Dictionary<Button, string> _gameLevels = new();

    private void Start()
    {
        for (int i = 0; i < _gameLevelButton.Length; i++)
            _gameLevelButton[i].onClick.AddListener(OnGameButtonClicked);

        List<string> _gameLevelNames = new() { Scenes.GAME_LEVEL_SCENE_1, Scenes.GAME_LEVEL_SCENE_2, 
            Scenes.GAME_LEVEL_SCENE_3, Scenes.GAME_LEVEL_SCENE_4, Scenes.GAME_LEVEL_SCENE_5 };

        for (int i = 0; i < _gameLevelButton.Length; i++)
            _gameLevels.Add(_gameLevelButton[i], _gameLevelNames[i]);
    }

    private async void OnGameButtonClicked()
    {
        var operations = new Queue<ILoadingOperation>();
        //operations.Enqueue(new GameLoadingOperation());
        await ProjectContext.I.LoadingScreenProvider.LoadAndDestroy(operations);
    }
}
