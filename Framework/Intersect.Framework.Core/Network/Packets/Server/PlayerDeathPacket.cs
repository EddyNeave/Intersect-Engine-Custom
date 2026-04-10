using MessagePack;

namespace Intersect.Network.Packets.Server;

[MessagePackObject(AllowPrivate = true)]
public partial class PlayerDeathPacket : IntersectPacket
{
    //Parameterless Constructor for MessagePack
    public PlayerDeathPacket()
    {
    }

    public PlayerDeathPacket(Guid playerId)
    {
        PlayerId = playerId;
    }

    [Key(0)]
    public Guid PlayerId { get; set; }

}
