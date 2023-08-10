using System;
using Common;
using UnityEngine;
using UnityEngine.UI;
using Utils.Assets;
using static Common.Constants;

namespace Core.UI
{
    public class Hud : MonoBehaviour
    {
        [SerializeField] private ToggleWithSpriteSwap _pauseToggle;
        [SerializeField] private Button _quitButton;
        public event Action QuitGame;

        private void Awake()
        {
            _pauseToggle.ValueChanged += OnPauseClicked;
            _quitButton.onClick.AddListener(OnQuitButtonClicked);
        }

        private async void OnQuitButtonClicked()
        {
            OnPauseClicked(true);
            var assetLoader = new LocalAssetLoader();
            var popup = await assetLoader.Load<AlertPopup>(AssetsConstants.AlertPopup);
            var isConfirmed = await popup.AwaitForDecision("Are you sure to quit?");
            OnPauseClicked(false);
            if(isConfirmed)
                QuitGame?.Invoke();
            assetLoader.Unload();
        }
        
        private void OnPauseClicked(bool isPaused)
        {
            ProjectContext.I.PauseManager.SetPaused(isPaused);
        }
        
        private void OnDestroy()
        {
            _pauseToggle.ValueChanged -= OnPauseClicked;
        }
    }
}