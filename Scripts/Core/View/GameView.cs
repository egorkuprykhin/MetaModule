namespace Infrastructure.Core
{
    public abstract class GameView<TSettings, TSfxSettings, TAnimationSettings> : GameViewBase 
        where TSettings : GameSettingsBase
        where TSfxSettings : SfxSettingBase
        where TAnimationSettings : AnimationSettingsBase
    {
        protected TSettings _settings { get; private set; }
        protected TSfxSettings _sfxSettings { get; private set; }
        protected TAnimationSettings _animationSettings { get; private set; }

        public void Construct(TSettings settings, TSfxSettings sfxSettings, TAnimationSettings animationSettings)
        {
            _settings = settings;
            _sfxSettings = sfxSettings;
            _animationSettings = animationSettings;
            
            PreConstruct();
            Construct();
        }

        protected virtual void PreConstruct() { }
        
        protected virtual void Construct() { }
    }
}