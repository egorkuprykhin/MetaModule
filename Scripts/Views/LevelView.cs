using System.Collections.Generic;
using Infrastructure.Services;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure.Views
{
    public class LevelView : MonoBehaviour
    {
        [SerializeField] private TMP_Text LevelNumber;
        [SerializeField] private Button LevelButton;
        [SerializeField] private List<GameObject> ProgressStars;
        
        private int _level;
        
        private LevelsService _levelsService;

        public void Construct(int level)
        {
            _level = level;
            _levelsService = ServiceLocator.GetService<LevelsService>();
            
            InitView(level);
            UpdateProgressView();
            
            LevelButton.onClick.AddListener(TryStartLevel);
        }

        public void UpdateProgressView()
        {
            int progressStars = _levelsService.GetLevelProgress(_level);
            for(int i = 0; i < progressStars; i ++)
                ProgressStars[i].SetActive(true);
        }

        private void TryStartLevel()
        {
            StartLevelService startLevelService = ServiceLocator.GetService<StartLevelService>();
            startLevelService.StartLevelIfUnlocked(_level);
        }

        private void InitView(int level)
        {
            LevelNumber.text = level.ToString();
            ProgressStars.ForEach(progressStar => progressStar.SetActive(false));
        }
    }
}