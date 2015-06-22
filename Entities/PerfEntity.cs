using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BenchMark.Entities
{
    public class PerfEntity
    {
        public string ModuleName { get; set; }
        
        public string TimeType { get; set; }
        public string  ExecutionTimeStamp {get;set;}
        

        public static PerfEntity CreateEntity(string moduleName, string tt, string ts)
        {
            PerfEntity perfEntity = new PerfEntity();

            perfEntity.ModuleName = moduleName;
            perfEntity.TimeType = tt;
            perfEntity.ExecutionTimeStamp = ts;
            return perfEntity;
        }
    }
}
