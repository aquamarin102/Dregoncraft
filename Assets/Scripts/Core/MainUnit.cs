using Abstractions;
using Abstractions.Commands;
using UniRx;
using UnityEngine;

namespace Core
{
    public class MainUnit : MonoBehaviour, ISelectable, IAttackable, ICommandQueue
    {
        public float Health => _health;
        public float MaxHealth => _maxHealth;
        public Transform PivotPoint => _pivotPoint;
        public Sprite Icon => _icon;

        [SerializeField] private float _maxHealth = 100;
        [SerializeField] private Sprite _icon;
        [SerializeField] private Transform _pivotPoint;

        private float _health = 100;

        private ReactiveCollection<CommandQueueTask> _commandQueue = new ReactiveCollection<CommandQueueTask>();

        ReactiveCollection<CommandQueueTask> ICommandQueue.Value => _commandQueue;
    }
}