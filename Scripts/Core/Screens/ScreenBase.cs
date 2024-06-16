using Infrastructure.Attributes;
using Infrastructure.Services;
using UnityEngine;

namespace Infrastructure.Screens
{
    [RequireComponent(typeof(Canvas))]
    [TopmostComponent]
    public abstract class ScreenBase : MonoBehaviour
    {
        private Canvas _canvas;
        private ScreensService _screensService;

        public void InjectScreenService()
        {
            _screensService = ServiceLocator.GetService<ScreensService>();
        }

        public void Show()
        {
            UpdateServiceScreens();
            EnableCanvas();
            OnShow();
        }

        public void Hide()
        {
            DisableCanvas();
            OnHide();
        }

        protected virtual void OnShow()
        {
        }

        protected virtual void OnHide()
        {
        }

        private void UpdateServiceScreens()
        {
            _screensService.UpdateCurrentScreen(this);
        }

        private void Awake()
        {
            _canvas = GetComponent<Canvas>();
            DisableCanvas();
        }

        private void EnableCanvas() => _canvas.enabled = true;

        private void DisableCanvas() => _canvas.enabled = false;
    }
}