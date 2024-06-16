using Infrastructure.Attributes;
using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure.ButtonActions
{
    [RequireComponent(typeof(Button))]
    [RequireComponent(typeof(ButtonActionComposer))]
    [TopmostComponent(Order = 0)]
    public abstract class ButtonAction : MonoBehaviour
    {
        [SerializeField] public int Order;
        
        private ButtonActionComposer _composer;

        public abstract void Action();

        protected abstract void Initialize();

        private void Start()
        {
            RegisterInComposer();
            Initialize();
        }

        private void RegisterInComposer()
        {
            _composer = GetComponent<ButtonActionComposer>();
            _composer.Register(this);
        }
    }
}