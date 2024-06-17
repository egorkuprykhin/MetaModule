using Infrastructure.Services;

namespace Core.Services
{
    public interface IGameFinisherService : IInitializableService
    {
        public void FinishGame();
    }
}