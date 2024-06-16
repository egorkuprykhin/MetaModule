using DG.Tweening;
using Infrastructure.Core;
using TMPro;
using UnityEngine;

namespace Infrastructure.Views
{
    public class AddScoresView : MetaView<int>
    {
        [SerializeField] private TMP_Text AddScoresText;
        [SerializeField] private RectTransform AddScoresTransform;
        [SerializeField] private Vector2 AnimationOffset;
        [SerializeField] private float AnimationTime;
        [SerializeField] private float AnimationScaleFactor;
        
        public override void Show(int scores)
        {
            AddScoresText.text = $"+{scores}";
            AnimateAddScores();
        }

        private void AnimateAddScores()
        {
            DOTween
                .To(
                    () => AddScoresTransform.anchoredPosition,
                    value => AddScoresTransform.anchoredPosition = value,
                    AddScoresTransform.anchoredPosition + AnimationOffset,
                    AnimationTime);

            AddScoresTransform
                .DOScale(Vector3.one * AnimationScaleFactor, AnimationTime)
                .SetEase(Ease.InExpo)
                .OnComplete(() => Destroy(gameObject));
        }
    }
}