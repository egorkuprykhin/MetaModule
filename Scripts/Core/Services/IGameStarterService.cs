using Infrastructure.Services;

namespace Core.Services
{
    public interface IGameStarterService : IInitializableService
    {
        public void StartGame();
    }
}