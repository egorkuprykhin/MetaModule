using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.Core
{
    public class RegistrationsBinder : MonoBehaviour
    {
        [SerializeField] public List<RegistrationBase> Registrations;
        
        public void BindRegistrations(IRegistrationRegistrar registrar)
        {
            Registrations.ForEach(registrar.Register);
        }
#if UNITY_EDITOR
        public void CollectRegistrations()
        {
            var registrations = gameObject.GetComponentsInChildren<RegistrationBase>();
            Registrations = new List<RegistrationBase>(registrations);
        }
#endif
    }
}