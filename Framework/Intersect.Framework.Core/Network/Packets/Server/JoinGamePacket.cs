using MessagePack;

namespace Intersect.Network.Packets.Server;

[MessagePackObject(AllowPrivate = true)]
public partial class JoinGamePacket : AbstractTimedPacket
{

}
