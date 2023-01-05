
using Abstractions.Commands;

public interface ICommandQueueController
{
    void AppendCommand(CommandQueueTask commandQueueTask);
    void ResetQueue();
    void CommandComplete();
}
