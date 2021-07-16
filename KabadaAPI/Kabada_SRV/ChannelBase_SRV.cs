using KabadaAPI;
namespace Kabada {
    partial class ChannelBase
    {
        internal virtual void fill(Tertex tvo)
        {
            id = tvo.me.Id;
            name = tvo.me.Value;
        }
    }
}
