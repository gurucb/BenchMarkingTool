using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cassandra;
using Cassandra.Data;


namespace BenchMark.BasketActions
{
    public class CassandraHelper
    {
        static ISession session;
        static Cluster cluster;
        public CassandraHelper()
        {
        }
        private static void CreateCassandrSession(Dictionary<string,string> connParameters)
        {
            
            string cServer = connParameters["Server"];
            string cKeySpace = connParameters["KeySpace"];
            //Singleton pattern
            if (cluster == null)
            {
                cluster = Cluster.Builder().AddContactPoint(cServer).Build();
            }
            if (session == null)
            {
                session = cluster.Connect(cKeySpace);
            }
        }
        public static int Create(Dictionary<string , string> connParameters, string qry)
        {
            int result = 0;
            CreateCassandrSession(connParameters);
            session.Execute(qry);
            return result;
        }

        public static void Read(Dictionary<string, string> connParameters, string qry)
        {
            
            CreateCassandrSession(connParameters);
            session.Execute(qry);
            session.Execute(qry);
            
        }
    }
}
