﻿namespace Tvl.VisualStudio.Language.Java.Debugger.Events
{
    using System;
    using System.Diagnostics.Contracts;
    using System.Runtime.InteropServices;
    using Microsoft.VisualStudio;
    using Microsoft.VisualStudio.Debugger.Interop;

    [ComVisible(true)]
    public class DebugPropertyCreateEvent : DebugEvent, IDebugPropertyCreateEvent2
    {
        private readonly IDebugProperty2 _property;

        public DebugPropertyCreateEvent(enum_EVENTATTRIBUTES attributes, IDebugProperty2 property)
            : base(attributes)
        {
            Contract.Requires<ArgumentNullException>(property != null, "property");

            _property = property;
        }

        public override Guid EventGuid
        {
            get
            {
                return typeof(IDebugPropertyCreateEvent2).GUID;
            }
        }

        public int GetDebugProperty(out IDebugProperty2 ppProperty)
        {
            ppProperty = _property;
            return VSConstants.S_OK;
        }
    }
}
