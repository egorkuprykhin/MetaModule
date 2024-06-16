using System;
using Infrastructure.Common;
using Services.Core;
using UnityEngine;

namespace Infrastructure.Services.Internal
{
    public class ServiceLocatorBase : MonoBehaviour
    {
        private static TypedDictionary<IService> _services = new TypedDictionary<IService>();
        private static TypedHashSet<IUpdatableService> _updatableServices = new TypedHashSet<IUpdatableService>();
        private static TypedHashSet<IInitializableService> _initializableServices = new TypedHashSet<IInitializableService>();

        protected static TService GetService<TService>() where TService : class, IService
        {
            return _services.Get<TService>();
        }

        protected void Register<TService>() where TService : class, IService, new()
        {
            if (!_services.Has<TService>())
            {
                TService service = _services.Create<TService>();
                RegisterInterfaces(service);
            }
        }

        protected void Register(Type type, MonoService service)
        {
            if (!_services.Has(type))
            {
                _services.Register(type, service);
                RegisterInterfaces(service);
            }
        }

        protected void Initialize()
        {
            _initializableServices.ForEach( service => service.Initialize());
        }

        protected void UpdateServices(float dt)
        {
            _updatableServices.ForEach( service => service.UpdateService(dt));
        }

        private void RegisterInterfaces(IService service)
        {
            if (service is IUpdatableService updatableService) 
                _updatableServices.Add(updatableService);
            
            if (service is IInitializableService initializableService) 
                _initializableServices.Add(initializableService);
        }
    }
}