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
        [SerializeField] private TMP_Text ResultText;
        [SerializeField] private TimerView TimerView;
        [SerializeField] private GameObject ViewWhenLose;
        [SerializeField] private StarsView StarsView;
        [SerializeField] private ScoresView ScoresView;
        [SerializeField] private CurrentLevelView LevelView;

        private LevelsService _levelsService;
        private SfxService _sfxService;
        private GameResultService _gameResultService;

        public void Initialize()
        {
            _levelsService = ServiceLocator.GetService<LevelsService>();
            _sfxService = ServiceLocator.GetService<SfxService>();
            _gameResultService = ServiceLocator.GetService<GameResultService>();
            
            if (TimerView)
                TimerView.Initialize();
            
            if (StarsView)
                StarsView.Initialize();
            
            if (ScoresView)
                ScoresView.Initialize();
            
            if (LevelView)
                LevelView.Initialize();
        }

        protected override void OnShow()
        {
            if (StarsView)
                StarsView.Show();
            if (ScoresView)
                ScoresView.Show();
            if (LevelView)
                LevelView.Show();
            
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

            if (ResultText)
                ResultText.text = _gameResultService.ResultText();
            
            SetTimerText();
            
            _sfxService.PlaySfx( _gameResultService.ResultSfx());
        }
        
        private void SetTimerText()
        {
            if (TimerView) 
                TimerView.UpdateView();
        }
    }
}