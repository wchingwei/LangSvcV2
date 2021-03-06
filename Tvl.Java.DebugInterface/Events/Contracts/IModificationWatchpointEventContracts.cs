﻿namespace Tvl.Java.DebugInterface.Events.Contracts
{
    using System;
    using System.Diagnostics.Contracts;

    [ContractClassFor(typeof(IModificationWatchpointEvent))]
    internal abstract class IModificationWatchpointEventContracts : IModificationWatchpointEvent
    {
        #region IModificationWatchpointEvent Members

        public IValue GetNewValue()
        {
            Contract.Ensures(Contract.Result<IValue>() == null || this.GetVirtualMachine().Equals(Contract.Result<IValue>().GetVirtualMachine()));

            throw new NotImplementedException();
        }

        #endregion

        #region IWatchpointEvent Members

        public IField GetField()
        {
            throw new NotImplementedException();
        }

        public IObjectReference GetObject()
        {
            throw new NotImplementedException();
        }

        public IValue GetCurrentValue()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IThreadEvent Members

        public IThreadReference GetThread()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IEvent Members

        public Request.IEventRequest GetRequest()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IMirror Members

        public IVirtualMachine GetVirtualMachine()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region ILocatable Members

        public ILocation GetLocation()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
