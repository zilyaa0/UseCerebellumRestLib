using CerebellumRestLib.Helpers;
using CerebellumRestLib.Models.JSON.Entities;
using CerebellumRestLib.Models.JSON.Results;
using CerebellumRestLib.Queries.Providers.Abstract;
using CerebellumRestLib.Queries.Services.Abstract;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CerebellumRestLib.Queries.Services
{
    public class OrganizationsService : IOrganizationsService
    {
        #region Fields
        private readonly ICurrentUserProvider _currentUser;
        private readonly ILogger<OrganizationsService> _logger;
        #endregion

        #region Constructor
        public OrganizationsService(ICurrentUserProvider currentUser,
                                    ILogger<OrganizationsService> logger)
        {
            _currentUser = currentUser;
            _logger = logger;
        }
        #endregion

        #region Commands
        #endregion

        #region Private methods
        public async Task<Organization> AddOrganization(OrganizationEdit organization)
        {
            try
            {
                if (organization == null)
                    throw new ArgumentNullException(nameof(organization));

                var result = await _currentUser.GetRequestHandler().PostJson<OrganizationResult>($"departments", body: organization.ToJson(true));
                return result.Organization;

            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }

        public async Task DeleteOrganization(int idOrg)
        {
            try
            {
                await _currentUser.GetRequestHandler().Delete($"departments/{idOrg}");
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }

        public async Task<Organization> EditOrganization(int idOrg, OrganizationEdit organization)
        {
            try
            {
                if (organization == null)
                    throw new ArgumentNullException(nameof(organization));

                var result = await _currentUser.GetRequestHandler().PutJson<OrganizationResult>($"departments/{idOrg}", body: organization.ToJson());
                return result.Organization;

            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }

        public async Task<int> GetDepartmentCount()
        {
            try
            {
                var result = await _currentUser.GetRequestHandler().GetJson<CountResult>("departments/count");
                return result.Count;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error in GetDepartmentCount");
                throw;
            }
        }

        public async Task<string> GetDepartmentName(int id)
        {
            try
            {
                var result = await _currentUser.GetRequestHandler().GetJson<GetDepartmentNameResult>($"departments/{id}/name");
                return result.DepartmentName;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error in GetDepartmentName");
                throw;
            }
        }

        public async Task<List<Organization>> GetOrganizations(bool all = false)
        {
            try
            {
                var url = all ? "/all" : "";
                return await GetOrganizations($"departments{url}");
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error in GetOrganizations");
                throw;
            }
        }
        #endregion

        #region Private methods
        private async Task<List<Organization>> GetOrganizations(string url)
        {
            try
            {
                var result = await _currentUser.GetRequestHandler().GetJson<OrganizationsListResult>(url);

                return result.Organizations ?? new List<Organization>();
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }
        #endregion
    }
}
