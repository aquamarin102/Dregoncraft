using System.Threading.Tasks;
using UnityEngine;

namespace Abstractions.Commands
{
    public abstract class CommandExecutorBase<T> : MonoBehaviour, ICommandExecutor where T : ICommand
    {
        private ICommandQueueController _commandQueueController;
        private bool _commandControllerFound = false;
        public ICommandQueueController CommandQueueController 
        { get
            {
                if (_commandControllerFound)
                {
                    return _commandQueueController;
                }
                else
                {
                    _commandControllerFound = true;
                    _commandQueueController = GetComponentInParent<ICommandQueueController>();
                    return _commandQueueController;
                }
            }
        }
        public async void ExecuteCommand(object command)
        {
            T specificCommand = (T)command;
            await ExecuteSpecificCommand(specificCommand);
            CommandQueueController?.CommandComplete();
        }

        public void ResetQueue()
        {
            CommandQueueController?.ResetQueue();
        }

        public abstract Task ExecuteSpecificCommand(T command);

        public bool AppendCommand(object command) => AppendSpecificCommand((T)command);
        public virtual bool AppendSpecificCommand(T command)
        {
            if (CommandQueueController == null)
            {
                return false;
            }
            else
            {
                CommandQueueController.AppendCommand(new CommandQueueTask(command, this));
                return true;
            }
            
        }
    }
}