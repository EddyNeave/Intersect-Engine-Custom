using MessagePack;

namespace Intersect.Network.Packets.Client;

[MessagePackObject(AllowPrivate = true)]
public partial class CloseCraftingPacket : IntersectPacket
{

}
