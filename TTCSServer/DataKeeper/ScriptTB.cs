//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataKeeper
{
    using System;
    using System.Collections.Generic;
    
    public partial class ScriptTB
    {
        public string BlockID { get; set; }
        public string BlockName { get; set; }
        public string StationName { get; set; }
        public Nullable<System.DateTime> ExecutionTimeStart { get; set; }
        public Nullable<System.DateTime> ExecutionTimeEnd { get; set; }
        public Nullable<int> CommandCounter { get; set; }
        public int ExecutionNumber { get; set; }
        public Nullable<int> DelayTime { get; set; }
        public string DeviceName { get; set; }
        public string DeviceCategory { get; set; }
        public string CommandName { get; set; }
        public string Owner { get; set; }
        public string Parameter { get; set; }
        public string ScriptState { get; set; }
    }
}
