using System.Collections.Generic;
using Services.Core;
using UnityEngine;

namespace Infrastructure.Core
{
    public abstract class RegistrationBase : MonoBehaviour, IRegistration
    {
        [SerializeField] private List<MonoService> MonoServices;
        [SerializeField] private List<MonoService> MonoInterfaceServices;

        public void Register(IServicesRegistrar registrar)
        {
            RegisterSerializedServices(registrar);
            RegisterServices(registrar);
        }

        protected abstract void RegisterServices(IServicesRegistrar registrar);

        private void RegisterSerializedServices(IServicesRegistrar registrar) =>
            MonoServices.ForEach(service => registrar.Register(service.GetType(), service));
    }
}