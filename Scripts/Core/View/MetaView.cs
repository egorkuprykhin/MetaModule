using System.Threading.Tasks;

namespace Infrastructure.Core
{
    public abstract class MetaView : MetaViewBase
    {
        public abstract void Show();
    }
    
    public abstract class MetaViewAsync : MetaViewBase
    {
        public abstract Task Show();
    }

    public abstract class MetaView<TPayload> : MetaViewBase
    {
        public abstract void Show(TPayload payload);
    }
    
    public abstract class MetaViewAsync<TPayload> : MetaViewBase
    {
        public abstract Task Show(TPayload payload);
    }
}