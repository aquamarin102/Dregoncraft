using Abstractions.Commands;

namespace UserControlSystem.ModelCommand
{
    public sealed class ModelOnCommandAccepted
    {
        
        public ICommandExecutor commandExecutor;

        public ModelOnCommandAccepted(ICommandExecutor commandExecutor)
        {
            this.commandExecutor = commandExecutor;
        }
    }
}