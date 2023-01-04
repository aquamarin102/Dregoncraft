using Core;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UserControlSystem.UI.Presenter
{
    public class MenuPresenter : MonoBehaviour
    {
        [SerializeField] private Button _backButton;
        [SerializeField] private Button _exitButton;
        
        [Inject] private PauseModel _pauseModel;

        private void Start()
        {
            _backButton.OnClickAsObservable().Subscribe(_ => CloseMenu());
            _exitButton.OnClickAsObservable().Subscribe(_ => Application.Quit());
        }

        private void CloseMenu()
        {
            gameObject.SetActive(false);
            _pauseModel.SetPause(false);
        }
    }
}