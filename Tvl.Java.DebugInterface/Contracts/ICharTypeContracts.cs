﻿namespace Tvl.Java.DebugInterface.Contracts
{
    using System;
    using System.Diagnostics.Contracts;

    [ContractClassFor(typeof(ICharType))]
    internal abstract class ICharTypeContracts : ICharType
    {
        #region IType Members

        public string GetName()
        {
            throw new NotImplementedException();
        }

        public string GetSignature()
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
