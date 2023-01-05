using Abstractions.Commands;

public class CommandQueueTask
{
    public ICommand command;
    public ICommandExecutor commandExecutor;

    public CommandQueueTask(ICommand command, ICommandExecutor commandExecutor)
    {
        this.command = command;
        this.commandExecutor = commandExecutor;
    }
}
