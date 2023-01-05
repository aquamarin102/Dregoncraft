using System;
using UnityEngine;
using UnityEngine.AI;
using Utils;

namespace Core
{
    public class UnitMovementStop : MonoBehaviour, IAwaitable<AsyncExtensions.Void>
    {
        public event Action OnStop;

        [SerializeField] private NavMeshAgent _agent;

        private float _timeZeroMove = 0;

        private void Update()
        {
            if (!_agent.pathPending)
            {
                if (_agent.remainingDistance <= _agent.stoppingDistance)
                {
                    if (!_agent.hasPath || _agent.velocity.sqrMagnitude == 0f)
                    {
                        OnStop?.Invoke();
                    }
                }
                else
                {
                    if (_agent.velocity.sqrMagnitude < 0.1f)
                        _timeZeroMove += Time.deltaTime;
                    else
                        _timeZeroMove = 0;

                    if (_timeZeroMove >= 2f)
                    {
                        _agent.isStopped = true;
                        _agent.velocity = Vector3.zero;
                        OnStop?.Invoke();
                        _timeZeroMove = 0f;
                    }
                }
            }

        }

        public IAwaiter<AsyncExtensions.Void> GetAwaiter() => new StopAwaiter(this);
    }
}