using Abstractions;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using System.Threading.Tasks;
using UnityEngine;

public sealed class MainBuilding : CommandExecutorBase<IProduceUnitCommand>, ISelectable
{
    private const int PRODUCE_TIME = 1000;
    public float Health => _health;
    public float MaxHealth => _maxHealth;
    public Transform PivotPoint => _pivotPoint;
    public Sprite Icon => _icon;

    [SerializeField] private Transform _unitsParent;

    [SerializeField] private float _maxHealth = 1000;
    [SerializeField] private Sprite _icon;
    [SerializeField] private Transform _pivotPoint;

    private float _health = 1000;

    public override void ExecuteSpecificCommand(IProduceUnitCommand command)
    {
        base.ExecuteSpecificCommand(command);

        Produce(command);
    }

    private async void Produce(IProduceUnitCommand command)
    {
        Debug.Log("Start produce...");
        await Task.Delay(PRODUCE_TIME);

        Instantiate(command.UnitPrefab,
            new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)),
            Quaternion.identity,
            _unitsParent);

        Debug.Log("Produce complete/");
    }
}