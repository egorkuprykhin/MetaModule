using System.Threading.Tasks;
using Infrastructure.Core;
using UnityEngine;

namespace Infrastructure.Views
{
    public abstract class ProgressbarBaseView : MetaViewAsync<float>
    {
        protected float _showTime;
        
        public override async Task Show(float showTime)
        {
            _showTime = showTime;
            await ShowProgress();
        }

        protected abstract void AdjustVisual(float factor);

        private async Task ShowProgress()
        {
            float timer = 0;
            while (timer < _showTime)
            {
                float factor = timer / _showTime;
                
                AdjustVisual(factor);

                float passedTime = Time.deltaTime;

                timer += passedTime;

                await Task.Delay((int)(passedTime * 1000));
            }
        }
    }
}