using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Application.Abstractions.Data;
using Dapper;
using Domain.Common.Dto.Tenants;
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

        public async Task<IEnumerable<TenantDto>> Get()
        {
            const string query = @"
                SELECT *
                FROM [Tenants]
            ";

            await using (var connecion = new SqlConnection(_connectionString))
            {
                var result = await connecion.QueryAsync<TenantDto>(query);
                return result;
            }
        }

        public async Task<TenantDto> Get(Guid id)
        {
            return await Task.FromResult(new TenantDto());
        }

        public async Task<TenantDto> Create(CreateTenantDto createTenantDto)
        {
            return await Task.FromResult(new TenantDto());
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