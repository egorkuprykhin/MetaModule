using System.Collections.Generic;
using Services.Core;
using UnityEngine;

namespace Infrastructure.Core
{
    public abstract class RegistrationBase : MonoBehaviour, IRegistration
    {
        [SerializeField] public List<MonoService> MonoServices;
        // [SerializeField] private List<MonoService> MonoInterfaceServices;

        public void Register(IServicesRegistrar registrar)
        {
            RegisterSerializedServices(registrar);
            RegisterServices(registrar);
        }
        
#if UNITY_EDITOR
        public void CollectMonoServices()
        {
            var services = gameObject.GetComponentsInChildren<MonoService>();
            MonoServices = new List<MonoService>(services);
        }
#endif

        protected abstract void RegisterServices(IServicesRegistrar registrar);

        private void RegisterSerializedServices(IServicesRegistrar registrar) =>
            MonoServices.ForEach(service => registrar.Register(service.GetType(), service));
    }
}