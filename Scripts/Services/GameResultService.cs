using Core.Sfx;
using Infrastructure.Data;
using Infrastructure.Settings;

namespace Infrastructure.Services
{
    public class GameResultService : IInitializableService
    {
        private ConfigurationService _configurationService;
        private CommonSettings _commonSettings;
        private SfxSettings _sfxSettings;

        public void Initialize()
        {
            _configurationService = ServiceLocator.GetService<ConfigurationService>();
            _commonSettings = _configurationService.GetSettings<CommonSettings>();
            _sfxSettings = _configurationService.GetSettings<SfxSettings>();
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
            GameResult.Win => _sfxSettings.WinGame,
            GameResult.Lose => _sfxSettings.LoseGame,
            _ => _sfxSettings.WinGame
        };
    }
}