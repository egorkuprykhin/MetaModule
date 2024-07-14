using Infrastructure.Data;
using Infrastructure.Settings;

namespace Infrastructure.Services
{
    public class GameResultService : IInitializableService
    {
        private ConfigurationService _configurationService;
        private CommonSettings _commonSettings;
        private TimerService _timerService;

        public void Initialize()
        {
            _configurationService = ServiceLocator.GetService<ConfigurationService>();
            _timerService = ServiceLocator.GetService<TimerService>();
            _commonSettings = _configurationService?.GetSettings<CommonSettings>();
        }

        public GameResultData GameResultData { get; private set; } = new GameResultData();

        public void CalculateGameResult(GameResult gameResult)
        {
            GameResultData.Result = gameResult;
            GameResultData.FinishTime = _timerService.CurrentTime;
            GameResultData.Stars = CalculateStars();
        }

        public void ResetGameResult()
        {
            GameResultData = new GameResultData();
        }
        
        private int CalculateStars()
        {
            if (_commonSettings.AlwaysThreeStars)
                return 3;
            
            if (GameResultData.FinishTime <= _commonSettings.Time3Stars)
                return 3;
            
            if (GameResultData.FinishTime <= _commonSettings.Time2Stars)
                return 2;

            return 1;
        }
    }
}