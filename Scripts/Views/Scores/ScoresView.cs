using Infrastructure.Core;
using Infrastructure.Services;
using TMPro;
using UnityEngine;

namespace Infrastructure.Views
{
    public class ScoresView : MetaView
    {
        [SerializeField] private TMP_Text Scores;
        [SerializeField] private Transform AddScoresRoot;
        [SerializeField] private AddScoresView AddScoresViewPrefab;

        private int _scores;
        
        protected ScoresService _scoresService;


        public override void Initialize()
        {
            _scoresService = ServiceLocator.GetService<ScoresService>();
        }

        public override void Show()
        {
            UpdateView();
        }

        public override void UpdateView()
        {
            if (_scores != _scoresService.Scores)
            {
                int scoresChange = Mathf.Abs(_scoresService.Scores - _scores);
                ShowAddScoresView(scoresChange);

                _scores = _scoresService.Scores;
                Scores.text = _scores.ToString();
            }
        }

        private void ShowAddScoresView(int scores)
        {
            if (AddScoresViewPrefab && AddScoresRoot)
            {
                AddScoresView addScoresView = Instantiate(AddScoresViewPrefab, AddScoresRoot, false);
                addScoresView.Show(scores);
            }
        }
    }
}