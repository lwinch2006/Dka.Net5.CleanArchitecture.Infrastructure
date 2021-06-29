using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Application.Abstractions.Data;
using Dapper;
using Domain.Common.Dto.Tenants;
using Domain.Common.Entities.Tenants;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Repositories
{
    public class TenantsRepository : ITenantsRepository
    {
        private readonly string _connectionString;

        public TenantsRepository(IConfiguration configuration)
        {
            _connectionString = configuration["Data:ConnectionString"];
        }

        public async Task<IEnumerable<Tenant>> Get()
        {
            const string query = @"
                SELECT *
                FROM [Tenants]
            ";

            await using (var connecion = new SqlConnection(_connectionString))
            {
                var result = await connecion.QueryAsync<Tenant>(query);
                return result;
            }
        }

        public async Task<Tenant> Get(Guid id)
        {
            return await Task.FromResult(new Tenant());
        }

        public async Task<Tenant> Create(CreateTenantDto createTenantDto)
        {
            return await Task.FromResult(new Tenant());
        }

        public async Task<int> Update(UpdateTenantDto createTenantDto)
        {
            return await Task.FromResult(1);
        }

        public async Task<int> Delete(DeleteTenantDto createTenantDto)
        {
            return await Task.FromResult(1);
        }
    }
}