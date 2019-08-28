using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ApocalypticShelter.DB
{
    public class ConnectionFactory
    {
        public static IDbConnection OpenPGConnection(string ConnectionString)
        {
            var conn = new NpgsqlConnection(ConnectionString);
            return conn;
        }
    }
}
