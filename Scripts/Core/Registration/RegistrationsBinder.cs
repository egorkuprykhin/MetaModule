using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.Core
{
    public class RegistrationsBinder : MonoBehaviour
    {
        [SerializeField] private List<RegistrationBase> Registrations;
        
        public void BindRegistrations(IRegistrar registrar)
        {
            Registrations.ForEach(registrar.Register);
        }
    }
}