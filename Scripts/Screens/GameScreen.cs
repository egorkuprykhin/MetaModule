using Infrastructure.ButtonActions;
using Infrastructure.Services;
using Infrastructure.Views;
using TMPro;
using UnityEngine;

namespace Infrastructure.Screens
{
    public class GameScreen: ScreenBase, IInitializableScreen
    {
        [SerializeField] private Transform Container;
        [SerializeField] private TMP_Text ScoresText;
        [SerializeField] private TMP_Text LevelText;
        [SerializeField] private Transform AddScoresRoot;
        [SerializeField] private TimerView TimerView;
        [SerializeField] private AddScoresView AddScoresViewPrefab;

        private LevelsService _levelsService;
        private ScoresService _scoresService;

        public void Initialize()
        {
            _levelsService = ServiceLocator.GetService<LevelsService>();
            _scoresService = ServiceLocator.GetService<ScoresService>();
            
            _scoresService.ScoresAdded += OnScoresAdded;
            TimerView.Initialize();
        }

        public void StartGame()
        {
            ResetTimer();
        }

        protected override void OnShow()
        {
            UpdateScores();
            UpdateLevel();
        }

        private void Update()
        {
            UpdateTimer();
        }

        private void OnScoresAdded(int scores)
        {
            UpdateScores();
            CreateAddScoresView(scores);
        }

        private void CreateAddScoresView(int scores)
        {
            AddScoresView addScoresView = Instantiate(AddScoresViewPrefab, AddScoresRoot, false);
            addScoresView.Construct(scores);
        }

        private void UpdateScores()
        {
            if (ScoresText)
                ScoresText.text = _scoresService.Scores.ToString();
        }

        private void UpdateLevel()
        {
            if (LevelText)
                LevelText.text = _levelsService.GetCurrentLevel().ToString();
        }

        private void ResetTimer()
        {
            if (TimerView)
                TimerView.ResetTimer();
        }

        private void UpdateTimer()
        {
            if (TimerView)
                TimerView.UpdateTimer();
        }
    }
}