using Abstractions.Commands;
using UnityEngine;

public class CommandQueueController : MonoBehaviour, ICommandQueueController
{
    private ICommandQueue commandQueue;
    private bool _isCommandInProcess;

    private void Awake()
    {
        commandQueue = GetComponentInParent<ICommandQueue>();
        _isCommandInProcess = false;
    }

    public void AppendCommand(CommandQueueTask commandQueueTask)
    {
        Debug.Log("AppendCommand");
        commandQueue.Value.Add(commandQueueTask);
        ExecuteNextCommand();
    }

    public void ResetQueue()
    {
        commandQueue.Value.Clear();
        _isCommandInProcess = false;
    }

    public void CommandComplete()
    {
        if (commandQueue.Value.Count > 0)
            commandQueue.Value.RemoveAt(0);
        _isCommandInProcess = false;
        Debug.Log("CommandComplete");
        ExecuteNextCommand();
    }

    public void ExecuteNextCommand()
    {
        if (commandQueue.Value.Count == 0)
        {
            _isCommandInProcess = false;
            return;
        }
        if (_isCommandInProcess)
            return;

        var commandTask = commandQueue.Value[0];
        commandTask.commandExecutor.ExecuteCommand(commandTask.command);
        _isCommandInProcess = true;
    }
}
