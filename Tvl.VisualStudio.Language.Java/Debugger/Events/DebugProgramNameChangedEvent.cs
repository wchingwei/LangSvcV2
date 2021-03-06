﻿namespace Tvl.VisualStudio.Language.Java.Debugger.Events
{
    using System;
    using System.Runtime.InteropServices;
    using Microsoft.VisualStudio.Debugger.Interop;

    [ComVisible(true)]
    public class DebugProgramNameChangedEvent : DebugEvent, IDebugProgramNameChangedEvent2
    {
        public DebugProgramNameChangedEvent(enum_EVENTATTRIBUTES attributes)
            : base(attributes)
        {
        }

        public override Guid EventGuid
        {
            get
            {
                return typeof(IDebugProgramNameChangedEvent2).GUID;
            }
        }
    }
}
