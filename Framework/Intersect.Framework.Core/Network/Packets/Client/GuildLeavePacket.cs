using MessagePack;

namespace Intersect.Network.Packets.Client;

[MessagePackObject(AllowPrivate = true)]
public partial class GuildLeavePacket : IntersectPacket
{
    /// <summary>
    /// Parameterless Constructor for MessagePack
    /// </summary>
    public GuildLeavePacket()
    {

    }
}
