using System.Collections.Generic;

namespace Common
{
    public class Constants
    {
        public class Scenes
        {
            public const string INITIAL_SCENE = "InitialScene";
            public const string MAIN_MENU_SCENE = "MainMenuScene";
            public const string GAME_LEVEL_SCENE_1 = "GameLevel 1";
            public const string GAME_LEVEL_SCENE_2 = "GameLevel 2";
            public const string GAME_LEVEL_SCENE_3 = "GameLevel 3";
            public const string GAME_LEVEL_SCENE_4 = "GameLevel 4";
            public const string GAME_LEVEL_SCENE_5 = "GameLevel 5";
            public readonly List<string> GAME_LEVEL_SCENES = new() { GAME_LEVEL_SCENE_1 , GAME_LEVEL_SCENE_2 , GAME_LEVEL_SCENE_3, GAME_LEVEL_SCENE_4, GAME_LEVEL_SCENE_5 };
        }
    }
}