using System;
using Abstractions;
using UniRx;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Core
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(NavMeshAgent))]
    public class MainUnit : MonoBehaviour, ISelectable, IAttackable
    {
        public float Health => _health;
        public float MaxHealth => _maxHealth;
        public Transform PivotPoint => _pivotPoint;
        public Sprite Icon => _icon;

        [SerializeField] private float _maxHealth = 100;
        [SerializeField] private Sprite _icon;
        [SerializeField] private Transform _pivotPoint;

        private float _health = 100;
        
        [Inject] private PauseModel _pauseModel;
        private IDisposable _pauseModelSubsciber;
        private Animator _animator;
        private NavMeshAgent _navMeshAgent;
        private Vector3 _LatestAgentVelocity = Vector3.zero;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        private void Start()
        {
            _pauseModelSubsciber = _pauseModel.pause.Subscribe(value => OnPauseChanged(value));
        }

        private void OnPauseChanged(bool value)
        {
            if (value)
            {
                _animator.enabled = false;
                _LatestAgentVelocity = _navMeshAgent.velocity;
                _navMeshAgent.velocity = Vector3.zero;
                _navMeshAgent.isStopped = true;
            }
            else
            {
                _animator.enabled = true;
                _navMeshAgent.isStopped = false;
                _navMeshAgent.velocity = _LatestAgentVelocity;
            }
        }

        private void OnDestroy()
        {
            _pauseModelSubsciber?.Dispose();
        }
    }
}