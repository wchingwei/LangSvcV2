﻿namespace Tvl.Java.DebugInterface.Request.Contracts
{
    using System;
    using System.Diagnostics.Contracts;

    [ContractClassFor(typeof(IBreakpointRequest))]
    internal abstract class IBreakpointRequestContracts : IBreakpointRequest
    {
        #region ILocatable Members

        public ILocation GetLocation()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IInstanceFilter Members

        public void AddInstanceFilter(IObjectReference instance)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IThreadFilter Members

        public void AddThreadFilter(IThreadReference thread)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IEventRequest Members

        public bool IsEnabled
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public SuspendPolicy SuspendPolicy
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public object GetProperty(object key)
        {
            throw new NotImplementedException();
        }

        public void PutProperty(object key, object value)
        {
            throw new NotImplementedException();
        }

        public void AddCountFilter(int count)
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
    }
}
