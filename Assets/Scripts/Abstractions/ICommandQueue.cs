using Abstractions.Commands;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public interface ICommandQueue
{
    ReactiveCollection<CommandQueueTask> Value { get; }
}
