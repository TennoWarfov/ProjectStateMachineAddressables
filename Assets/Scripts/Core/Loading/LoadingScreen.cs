using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Loading
{
    public class LoadingScreen : MonoBehaviour
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private Animator _crossFadeAnimator;
        [SerializeField] private Slider _progressFill;
        [SerializeField] private TextMeshProUGUI _loadingInfo;
        [SerializeField] private float _barSpeed;

        private readonly int _screenFadeDuration = 1000;
        //private readonly int _crossFadeStartParamenterID = Animator.StringToHash("Start");
        private readonly int _crossFadeEndParamenterID = Animator.StringToHash("End");
        private float _targetProgress;

        public async UniTask Load(Queue<ILoadingOperation> loadingOperations)
        {
            _canvas.enabled = true;

            await UniTask.Delay(_screenFadeDuration);

            StartCoroutine(UpdateProgressBar());
            
            foreach (var operation in loadingOperations)
            {
                ResetFill();
                _loadingInfo.text = operation.Description;

                await operation.Load(OnProgress);
                await WaitForBarFill();
            }
            
            _crossFadeAnimator.SetTrigger(_crossFadeEndParamenterID);
            await UniTask.Delay(_screenFadeDuration);

            _canvas.enabled = false;
        }

        private void ResetFill()
        {
            _progressFill.value = 0;
            _targetProgress = 0;
        }

        private void OnProgress(float progress)
        {
            _targetProgress = progress;
        }

        private async UniTask WaitForBarFill()
        {
            while (_progressFill.value < _targetProgress)
            {
                await UniTask.Delay(1);
            }
            
            await UniTask.Delay(TimeSpan.FromSeconds(0.15f));
        }

        private IEnumerator UpdateProgressBar()
        {
            while (_canvas.enabled)
            {
                if(_progressFill.value < _targetProgress)
                    _progressFill.value += Time.deltaTime * _barSpeed;
                yield return null;
            }
        }
    }
}