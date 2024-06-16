using Infrastructure.Views;
using UnityEngine;

namespace Infrastructure.Screens
{
    public class OptionsScreen : ScreenBase, IInitializableScreen
    {
        [SerializeField] private OptionsView OptionsView;
        
        public void Initialize()
        {
            OptionsView.Initialize();
        }

        protected override void OnShow()
        {
            OptionsView.Show();
        }

        protected override void OnHide()
        {
            OptionsView.Hide();
        }
    }
}