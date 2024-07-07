using Infrastructure.Core;
using Infrastructure.Services;

namespace Registrations
{
    public class PreloadingRegistration : RegistrationBase
    {
        protected override void RegisterServices(IServicesRegistrar registrar)
        {
            registrar.Register<SaveLoadService>();
            registrar.Register<OptionsDataService>();
        }
    }
}