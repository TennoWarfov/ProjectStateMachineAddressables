using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "GameLevel 1", menuName = "CustomTools/GameLevelConfiguration")]
public class GameLevelConfiguration : ScriptableObject
{
    public SceneAsset SceneAsset => _sceneAsset;

    [SerializeField] private SceneAsset _sceneAsset;
}
