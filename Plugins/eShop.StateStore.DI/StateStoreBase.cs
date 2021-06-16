using eShop.UseCases.PluginInterfaces.StateStore;
using System;

namespace eShop.StateStore.DI
{
    public class StateStoreBase : IStateStore
    {
        protected Action listeners;

        public void AddStateChangeListeners(Action listener)
        {
            this.listeners += listener;
        }

        public void BroadCastSatateChange()
        {
            if (this.listeners != null)
            {
                this.listeners.Invoke();
            }
        }

        public void RemoveStateChangeListeners(Action listener)
        {
            this.listeners -= listener;
        }
    }
}
