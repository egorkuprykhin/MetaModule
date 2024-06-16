using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure.Components
{
    public class SliderHandleSetter : MonoBehaviour
    {
        public Slider Slider;
        public Image Handle;
        public Sprite EnabledHandleSprite;
        public Sprite DisabledHandleSprite;

        private void Awake()
        {
            Slider.onValueChanged.AddListener(OnSliderValueChanged);
            OnSliderValueChanged(Slider.value);
        }

        private void OnSliderValueChanged(float value)
        {
            Handle.sprite = 
                value == 0 
                    ? DisabledHandleSprite 
                    : EnabledHandleSprite;
        }
    }
}