using MessagePack;

namespace Intersect.Network.Packets.Client;

[MessagePackObject(AllowPrivate = true)]
public class FadeCompletePacket : IntersectPacket
{
    public FadeCompletePacket()
    {
    }
}
