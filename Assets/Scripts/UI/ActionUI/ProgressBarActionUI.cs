using DVUnityUtilities.Other.UI.ProgressBar;
using UnityEngine;

namespace Assets.Scripts.UI.ActionUI
{
    internal class ProgressBarActionUI : MonoBehaviour
    {
        [SerializeField]
        private ProgressBarUI _progressBar;

        private float _valueToAdd;

        private void Awake()
        {
            _progressBar.gameObject.SetActive(false);
        }

        private void Update()
        {
            _progressBar.SetValue(_progressBar.GetValue() + (_valueToAdd * Time.deltaTime));

            if (_progressBar.GetValue() <= 0f)
            {
                enabled = false;
                _progressBar.gameObject.SetActive(false);
            }
        }

        public void AnimateDowngradeProcess(float zeroReachSecondsTime)
        {
            enabled = true;
            _progressBar.gameObject.SetActive(true);

            _progressBar.SetValue(1f);
            _valueToAdd = -(1f / zeroReachSecondsTime);
        }
    }
}