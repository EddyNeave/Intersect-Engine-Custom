using MessagePack;

namespace Intersect.Network.Packets.Unconnected.Server;

[MessagePackObject(AllowPrivate = true)]
public partial class ServerStatusResponsePacket : UnconnectedResponsePacket
{
    [Key(1)]
    public NetworkStatus Status { get; set; }
}