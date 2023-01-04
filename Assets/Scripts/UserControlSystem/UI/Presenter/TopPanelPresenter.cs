using System;
using Abstractions;
using Core;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UserControlSystem.UI.Presenter
{
    public sealed class TopPanelPresenter : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _inputField;
        [SerializeField] private Button _menuButton;
        [SerializeField] private GameObject _menuGo;

        [Inject] private PauseModel _pauseModel;

        [Inject]
        private void Init(ITimeModel timeModel)
        {
            timeModel.GameTime.Subscribe(seconds =>
            {
                var t = TimeSpan.FromSeconds(seconds);
                _inputField.text = $"{t.Minutes:D2}:{t.Seconds:D2}";
            });

            _menuButton.OnClickAsObservable().Subscribe(_ => MenuGo());
        }

        private void MenuGo()
        {
            _menuGo.SetActive(true);
            _pauseModel.SetPause(true);
        }
    }
}