using Infrastructure.Core;
using Infrastructure.Services;

namespace Registrations
{
    public class PreloadingRegistration : RegistrationBase
    {
        protected override void RegisterServices(IRegistrar registrar)
        {
            registrar.Register<SaveLoadService>();
            registrar.Register<OptionsDataService>();
        }
    }
}