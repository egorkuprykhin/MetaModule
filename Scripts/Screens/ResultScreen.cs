using Infrastructure.ButtonActions;
using Infrastructure.Data;
using Infrastructure.Services;
using Infrastructure.Views;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure.Screens
{
    public class ResultScreen : ScreenBase, IInitializableScreen
    {
        [SerializeField] private Button NextLevelButton;
        [SerializeField] private Button TryAgainButton;
        [SerializeField] private TMP_Text ScoresText;
        [SerializeField] private TMP_Text ResultText;
        [SerializeField] private TimerView TimerView;
        [SerializeField] private GameObject ViewWhenLose;
        [SerializeField] private StarsView StarsView;

        private LevelsService _levelsService;
        private ScoresService _scoresService;
        private SfxService _sfxService;
        private GameResultService _gameResultService;
        private TimerService _timerService;

        public void Initialize()
        {
            _levelsService = ServiceLocator.GetService<LevelsService>();
            _scoresService = ServiceLocator.GetService<ScoresService>();
            _sfxService = ServiceLocator.GetService<SfxService>();
            _gameResultService = ServiceLocator.GetService<GameResultService>();
            _timerService = ServiceLocator.GetService<TimerService>();
            
            TimerView.Initialize();
        }

        protected override void OnShow()
        {
            StarsView.ShowAnimation();
            ShowResults();
        }

        private void ShowResults()
        {
            GameResultData gameResultData = _gameResultService.GameResultData;
            bool hasNextLevel = _levelsService.HasNextLevel() && gameResultData.IsWin();

            if (NextLevelButton)
                NextLevelButton.gameObject.SetActive(hasNextLevel);

            if (TryAgainButton)
                TryAgainButton.gameObject.SetActive(!hasNextLevel);
            
            if (ViewWhenLose)
                ViewWhenLose.SetActive(gameResultData.IsLose());

            if (ScoresText)
                ScoresText.text = _scoresService.Scores.ToString();

            if (ResultText)
                ResultText.text = _gameResultService.ResultText();
            
            SetTimerText();
            
            _sfxService.PlaySfx( _gameResultService.ResultSfx());
        }
        
        private void SetTimerText()
        {
            if (TimerView) 
                TimerView.SetCurrentTime();
        }
    }
}