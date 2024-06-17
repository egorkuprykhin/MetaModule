using Infrastructure.Attributes;
using Infrastructure.Data;
using Infrastructure.Services;
using Infrastructure.Settings;
using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure.Components
{
    [RequireComponent(typeof(Selectable))]
    [TopmostComponent]
    public class PlaySfxOnValueChanged : MonoBehaviour
    {
        private SfxService _sfxService;
        private SfxSettings _sfxSettings;

        private void Start()
        {
            _sfxService = ServiceLocator.GetService<SfxService>();
            _sfxSettings = ServiceLocator.GetService<ConfigurationService>().GetSettings<SfxSettings>();
            
            RegisterCall();
        }

        private void RegisterCall()
        {
            if (TryGetComponent<Toggle>(out var toggle))
                toggle.onValueChanged.AddListener(value => PlayAudioCLip());
            
            if (TryGetComponent<Slider>(out var slider))
                slider.onValueChanged.AddListener(value => PlayAudioCLip());
        }

        private void PlayAudioCLip()
        {
            _sfxService.PlaySfx(_sfxSettings.Click);
        }
    }
}