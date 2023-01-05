namespace Abstractions.Commands
{
    public interface ICommandExecutor
    {
        void ExecuteCommand(object command);

        bool AppendCommand(object command);

        void ResetQueue();
    }
}