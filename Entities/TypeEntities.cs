using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BenchMark.Entities
{
    public enum SourceType { SQL = 1, XML = 2 };

    public enum TargetType { SQLGeneric = 1, AppFabric = 2, Cassandra = 3, CouchBase = 4, Redis = 5, MemOptSQL = 6 };


    public enum OperationType { CreateBasket = 1, ReadBasket = 2 };
}
