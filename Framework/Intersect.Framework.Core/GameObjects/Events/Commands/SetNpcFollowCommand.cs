namespace Intersect.Framework.Core.GameObjects.Events.Commands;

public partial class StartNpcFollowCommand : EventCommand
{
    public override EventCommandType Type { get; } = EventCommandType.StartNpcFollow;
}

public partial class StopNpcFollowCommand : EventCommand
{
    public override EventCommandType Type { get; } = EventCommandType.StopNpcFollow;
}