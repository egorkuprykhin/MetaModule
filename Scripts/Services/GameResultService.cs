using Core.Sfx;
using Infrastructure.Data;
using Infrastructure.Settings;

namespace Infrastructure.Services
{
    public class GameResultService : IInitializableService
    {
        private ConfigurationService _configurationService;
        private CommonSettings _commonSettings;
        private CommonSfxSettings _commonSfxSettings;

        public void Initialize()
        {
            _configurationService = ServiceLocator.GetService<ConfigurationService>();
            _commonSettings = _configurationService.GetSettings<CommonSettings>();
        }

        public GameResultData GameResultData { get; private set; } = new GameResultData();

        public void CalculateGameResult()
        {
            GameResultData.Result = GameResult.Win;
            GameResultData.Stars = 3;
        }

        public void ResetGameResult()
        {
            GameResultData = new GameResultData();
        }

        public string ResultText() => GameResultData.Result switch
        {
            GameResult.Win => _commonSettings.WinText,
            GameResult.Lose => _commonSettings.LoseText,
            _ => _commonSettings.WinText
        };

        public SfxType ResultSfx() => GameResultData.Result switch
        {
            GameResult.Win => _commonSfxSettings.WinGame,
            GameResult.Lose => _commonSfxSettings.LoseGame,
            _ => _commonSfxSettings.WinGame
        };
    }
}