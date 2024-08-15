using CerebellumRestLib.Models.JSON.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CerebellumRestLib.Queries.Services.Abstract
{
    public interface IOrganizationsService
    {
        Task<int> GetDepartmentCount();
        Task<string> GetDepartmentName(int id);
        Task<List<Organization>> GetOrganizations(bool all = false);
        Task<Organization> AddOrganization(OrganizationEdit organization);
        Task<Organization> EditOrganization(int idOrg, OrganizationEdit organization);
        Task DeleteOrganization(int idOrg);
    }
}
