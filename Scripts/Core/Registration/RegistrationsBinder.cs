using System.Collections.Generic;
using System.Linq;
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
            var registrations = 
                FindObjectsOfType<RegistrationBase>()
                .OrderBy(x => x.Order);
            Registrations = new List<RegistrationBase>(registrations);
        }
#endif
    }
}