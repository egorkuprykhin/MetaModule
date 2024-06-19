using UnityEngine;

namespace Infrastructure.Views
{
    [RequireComponent(typeof(RectTransform))]
    public class ProgressbarStretchedView : ProgressbarBaseView
    {
        [SerializeField] private RectTransform Parent;
        [SerializeField] private RectTransform Target;
        [SerializeField] private int MaxSize;

        private float _minSize;

        public override void Initialize()
        {
            _minSize = Target.sizeDelta.x;
        }

        protected override void AdjustVisual(float factor)
        {
            float sizeX = _minSize + (MaxSize - _minSize) * factor;
            Target.sizeDelta = new Vector2(sizeX, Target.sizeDelta.y);
        }
    }
}