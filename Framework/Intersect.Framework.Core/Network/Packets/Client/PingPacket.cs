using MessagePack;

namespace Intersect.Network.Packets.Client;

[MessagePackObject(AllowPrivate = true)]
public partial class PingPacket : AbstractTimedPacket
{
    [Key(3)]
    public bool Responding { get; set; }
}
