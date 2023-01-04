using Abstractions.Commands.CommandsInterfaces;
using Core;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;
using Utils;

namespace Abstractions.Commands.CommandExecutors
{
    public class PatrolCommandExecutor : CommandExecutorBase<IPatrolCommand>
    {
        [SerializeField] private UnitMovementStop _stop;
        [SerializeField] private Animator _animator;
        private static readonly int Walk = Animator.StringToHash("Walk");
        private static readonly int Idle = Animator.StringToHash("Idle");
        private CancellationTokenSource _ctSource;

        public override async void ExecuteSpecificCommand(IPatrolCommand command)
        {
            base.ExecuteSpecificCommand(command);

            await Patrolling(command);
        }

        public override void CancelCommand()
        {
            if (_ctSource != null)
            {
                _ctSource.Cancel();
                _ctSource.Dispose();
                _ctSource = null;
            }
        }

        public async Task Patrolling(IPatrolCommand command)
        {
            _ctSource = new CancellationTokenSource();

            var navMeshAgent = GetComponent<NavMeshAgent>();

            try
            {
                for (; ; )
                {
                    _animator.SetTrigger(Walk);
                    navMeshAgent.destination = command.To;
                    await _stop.WithCancellation(_ctSource.Token);
                    navMeshAgent.destination = command.From;
                    await _stop.WithCancellation(_ctSource.Token);
                }
            }
            catch
            {
                _animator.SetTrigger(Idle);
            }
        }
    }
}