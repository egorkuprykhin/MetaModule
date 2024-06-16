using Infrastructure.Settings;

namespace Infrastructure.Services
{
    public class TimerService : IInitializableService, IUpdatableService
    {
        private float _startTime;

        private ConfigurationService _configurationService;
        private GameLifecycleService _lifecycleService;
        private GameFinisherService _gameFinisherService;

        private CommonSettings _commonSettings;

        public bool Enabled { get; private set; }

        public float CurrentTime { get; private set; }
        
        public float TimeLeftPercent => CurrentTime / _startTime;
        
        public void Initialize()
        {
            _configurationService = ServiceLocator.GetService<ConfigurationService>();
            _lifecycleService = ServiceLocator.GetService<GameLifecycleService>();
            _gameFinisherService = ServiceLocator.GetService<GameFinisherService>();

            _commonSettings = _configurationService.GetSettings<CommonSettings>();
        }

        public void StartTimer()
        {
            _startTime = _commonSettings.TimerFromZero
                ? 0
                : _commonSettings.InitialLevelTime;
            
            CurrentTime = _startTime;
            Enabled = true;
        }

        public void UpdateService(float deltaTime)
        {
            if (Enabled && _lifecycleService.GameIsActive)
            {
                UpdateTimer(deltaTime);

                if (IsTimeUp())
                {
                    CurrentTime = 0;
                    Enabled = false;
                    
                    TimeIsUp();
                }
            }
        }

        private void UpdateTimer(float deltaTime)
        {
            if (_commonSettings.TimerFromZero)
                CurrentTime += deltaTime;
            else
                CurrentTime -= deltaTime;
        }

        private bool IsTimeUp()
        {
            return CurrentTime <= 0;
        }

        private void TimeIsUp()
        {
            _gameFinisherService.FinishGame();
        }
    }
}