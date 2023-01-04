using System;
using Abstractions;
using UniRx;
using UnityEngine;
using Zenject;

namespace Core
{
    public sealed class TimeModel : ITimeModel, ITickable
    {
        public IObservable<int> GameTime => _gameTime.Select(f => (int)f);
        private readonly ReactiveProperty<float> _gameTime = new ReactiveProperty<float>();
        [Inject] private PauseModel _pauseModel;
        
        public void Tick()
        {
            if (!_pauseModel.IsPause)
                _gameTime.Value += Time.deltaTime;
        }
    }
}