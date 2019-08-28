using ApocalypticShelter.Models;
using ApocalypticShelter.Repositories.Interfaces;
using ApocalypticShelter.Repositories.Scripts;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ApocalypticShelter.Repositories
{
    public class ResourceRepository : IResourceRepository
    {
        protected IDbConnection Connection;
        public ResourceRepository(IDbConnection Connection)
        {
            this.Connection = Connection;
        }

        public async Task<Resource> Get(int id)
        {
            using (var con = Connection)
            {
                var parameter = new DynamicParameters();
                parameter.Add("@ID", id, DbType.Int32, ParameterDirection.Input);
                string sql = ResourceScript.Get;
                return (await con.QueryAsync<Resource>(sql, parameter)).SingleOrDefault();
            }
        }

        public async Task<IEnumerable<Resource>> GetAll()
        {
            string sql = ResourceScript.All;
            using (var con = Connection)
            {
                return await con.QueryAsync<Resource>(sql);
            }
        }
    }
}
