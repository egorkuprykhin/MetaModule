using System.Collections.Generic;
using Services.Core;
using UnityEngine;

namespace Infrastructure.Core
{
    public abstract class RegistrationBase : MonoBehaviour, IRegistration
    {
        [SerializeField] private List<MonoService> MonoServices;
        [SerializeField] private List<MonoService> MonoInterfaceServices;

        public void Register(IRegistrar registrar)
        {
            RegisterSerializedServices(registrar);
            RegisterServices(registrar);
        }

        protected abstract void RegisterServices(IRegistrar registrar);

        private void RegisterSerializedServices(IRegistrar registrar) =>
            MonoServices.ForEach(service => registrar.Register(service.GetType(), service));
    }
}