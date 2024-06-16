using UnityEngine;

namespace Infrastructure.Views
{
    [RequireComponent(typeof(RectTransform))]
    public class ProgressbarStretchedView : ProgressbarBaseView
    {
        [SerializeField] private RectTransform Parent;
        [SerializeField] private RectTransform Target;

        private float _minSize;
        private float _maxSize;

        public override void Initialize()
        {
            _minSize = Target.sizeDelta.x;
            _maxSize = Parent.sizeDelta.x;
        }

        protected override void AdjustVisual(float factor)
        {
            float sizeX = _minSize + (_maxSize - _minSize) * factor;
            Target.sizeDelta = new Vector2(sizeX, Target.sizeDelta.y);
        }
    }
}