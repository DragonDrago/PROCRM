using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using ProCrm.Ldi.Api.Models;
using ProCrm.Ldi.Api.Domain;
using System.Data.SqlClient;
using ProCRM.Core.Tenant;
using Dapper;

namespace ProCrm.Ldi.Api.Repositories
{
    public class LdiRepository:ILdiRepository
    {
        private readonly ITenantContext _tenantContext;

        public LdiRepository(ITenantContext tenantContext )
        {
            _tenantContext = tenantContext;
        }

        public async Task<IEnumerable<LdiDomain>> All(LdiFilter ldiFilter)
        {
            using(SqlConnection connection = new SqlConnection(_tenantContext.CurrentTenant.ConnectionString))
            {
                await connection.OpenAsync();
                var ldis = await connection.QueryAsync<LdiDomain>(
                    sql:@"dbo.getLdi",
                    commandType: System.Data.CommandType.StoredProcedure);
                if(ldiFilter != null)
                {
                    if (ldiFilter.Id > 0)
                    {
                        ldis = ldis.Where(w => w.Id == ldiFilter.Id);
                    }
                    if (!string.IsNullOrEmpty(ldiFilter.FullName?.Trim()))
                    {
                        string fullName = ldiFilter.FullName.ToLower().Trim();
                        ldis=ldis.Where(w => w.FullName.ToLower().Contains(fullName));
                    }
                    if (!string.IsNullOrEmpty(ldiFilter.AttachedTo?.Trim()))
                    {
                        string attachedTo = ldiFilter.AttachedTo.ToLower().Trim();
                        ldis = ldis.Where(w => w.AttachedTo.ToLower().Contains(attachedTo));
                    }
                    if (!string.IsNullOrEmpty(ldiFilter.JobTitle?.Trim()))
                    {
                        string jobTitle = ldiFilter.JobTitle.ToLower().Trim();
                        ldis = ldis.Where(w => w.JobTitle.ToLower().Contains(jobTitle));
                    }
                    if (!string.IsNullOrEmpty(ldiFilter.Status?.Trim()))
                    {
                        string status = ldiFilter.Status.ToLower().Trim();
                        ldis = ldis.Where(w => w.Status.ToLower().Contains(status));
                    }
                }
                return ldis.ToList();
            }
        }

        public async Task<int> CreateOrUpdateAsync(LdiDomain ldiDomain)
        {
            using (SqlConnection connection = new SqlConnection(_tenantContext.CurrentTenant.ConnectionString))
            {
                await connection.OpenAsync();
                return await connection.ExecuteScalarAsync<int>(
                    sql:"dbo:insertOrUpdateLdi",
                    param: new
                    {
                        @id = ldiDomain.Id,
                        @status = ldiDomain.Status,
                        @source = ldiDomain.Source,
                        @attachedTo = ldiDomain.AttachedTo,
                        @fullName = ldiDomain.FullName,
                        @phone = ldiDomain.Phone,
                        @jobTitle = ldiDomain.JobTitle,
                        @country = ldiDomain.Country,
                        @city = ldiDomain.City,
                        @address = ldiDomain.Address,
                        @company = ldiDomain.Company,
                        @webSite = ldiDomain.WebSite,
                        @emailAddress = ldiDomain.EmailAddress,
                        @mailAddress = ldiDomain.MailAddress,
                        @facebook = ldiDomain.Facebook,
                        @instagram = ldiDomain.Instagram,
                        @comments = ldiDomain.Comments
                    },
                    commandType: System.Data.CommandType.StoredProcedure);
            }
            throw null;
        }

       

        public async Task<bool> Remove(int id)
        {
            using (SqlConnection connection = new SqlConnection(_tenantContext.CurrentTenant.ConnectionString))
            {
                await connection.OpenAsync();

                return await connection.ExecuteScalarAsync<int>(
                    sql: "UPDATE LdiDomain SET IsDeleted = 1 WHERE Id = @id",
                    param: new { @id },
                    commandType: System.Data.CommandType.Text) > 0;
            }
        }

        public Task<int> UpdateAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
