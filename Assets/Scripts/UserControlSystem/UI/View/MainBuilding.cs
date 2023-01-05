using Abstractions;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using UserControlSystem;
using UserControlSystem.CommandsRealization;

public sealed class MainBuilding : MonoBehaviour, ISelectable, IWayPointHolder
{
    public float Health => _health;
    public float MaxHealth => _maxHealth;
    public Transform PivotPoint => _pivotPoint;
    public Sprite Icon => _icon;

    [SerializeField] private float _maxHealth = 1000;
    [SerializeField] private Sprite _icon;
    [SerializeField] private Transform _pivotPoint;

    private float _health = 1000;

    public Transform WayPoint;

    public void SentUnitToWayPoint(GameObject go)
    {
        CommandExecutorBase<IMoveCommand> moveExecutor = go.GetComponentInChildren<CommandExecutorBase<IMoveCommand>>();
        if (moveExecutor == null)
            return;

        MoveCommandCommandCreator commandCreator = new MoveCommandCommandCreator();
        moveExecutor.ExecuteCommand(commandCreator.CreateCommand(WayPoint.position));
    }

}