using System.Threading.Tasks;
using DG.Tweening;
using Infrastructure.Services;
using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure.Screens
{
    public class LoadingScreen : ScreenBase, IInitializableScreen
    {
        [SerializeField] public float LoadingTime;
        [SerializeField] public bool Filled;
        [SerializeField] public Image FilledProgressbar;
        [SerializeField] public RectTransform StretchedProgressbar;
        [SerializeField] public Transform RotatedObject;
        [SerializeField] public int Rotations;
        [SerializeField] public Ease RotationEase;
        [SerializeField] public int StartSize;
        [SerializeField] public int FinishSize;

        private PostLoadingService _postLoadingService;

        public void Initialize()
        {
            _postLoadingService = ServiceLocator.GetService<PostLoadingService>();
        }

        protected override async void OnShow()
        {
            await ShowProgress();
            Hide();
        }

        protected override void OnHide()
        {
            _postLoadingService.PostLoadingAction();
        }

        private async Task ShowProgress()
        {
            if (RotatedObject)
            {
                DOTween.To(
                        () => RotatedObject.transform.rotation.eulerAngles,
                        value => RotatedObject.transform.eulerAngles = value,
                        new Vector3(0, 0, -360),
                        LoadingTime
                    ).SetLoops(Rotations, LoopType.Restart)
                    .SetEase(RotationEase);
            }
            
            float timer = 0;
            while (timer < LoadingTime)
            {
                if (Filled)
                {
                    FilledProgressbar.fillAmount = timer / LoadingTime;
                }
                else
                {
                    float sizeX = StartSize + (FinishSize - StartSize) * (timer / LoadingTime);
                    StretchedProgressbar.sizeDelta = new Vector2(sizeX, StretchedProgressbar.sizeDelta.y);
                }

                float passedTime = Time.deltaTime;

                timer += passedTime;
                
                await Task.Delay((int)(passedTime * 1000));
            }

            if (RotatedObject)
                RotatedObject.DOKill();
        }
    }
}