using MessagePack;

namespace Intersect.Network.Packets.Client;

[MessagePackObject(AllowPrivate = true)]
public partial class GuildInviteDeclinePacket : IntersectPacket
{
    /// <summary>
    /// Parameterless Constructor for MessagePack
    /// </summary>
    public GuildInviteDeclinePacket()
    {

    }
}
