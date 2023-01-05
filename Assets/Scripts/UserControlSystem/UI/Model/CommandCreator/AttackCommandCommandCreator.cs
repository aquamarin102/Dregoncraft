using Abstractions.Commands.CommandsInterfaces;

namespace UserControlSystem
{
    public sealed class AttackCommandCommandCreator : CancellableCommandCreatorBase<IAttackCommand, IAttackable>
    {
        public override IAttackCommand CreateCommand(IAttackable argument) => new AttackCommand(argument);
    }
}