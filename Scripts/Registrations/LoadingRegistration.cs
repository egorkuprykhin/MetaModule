using Infrastructure.Core;
using Infrastructure.Services;

namespace Registrations
{
    public class LoadingRegistration : RegistrationBase
    {
        protected override void RegisterServices(IRegistrar registrar)
        {
            registrar.Register<ScreensService>();
            registrar.Register<ScoresService>();
            registrar.Register<GameLifecycleService>();
            registrar.Register<PlayerDataService>();
            registrar.Register<LevelsService>();
            registrar.Register<GameFinisherService>();
            registrar.Register<TimerService>();
            registrar.Register<GameStarterService>();
            registrar.Register<GameResultService>();
            registrar.Register<StartLevelService>();
            registrar.Register<ExitGameService>();
        }
    }
}