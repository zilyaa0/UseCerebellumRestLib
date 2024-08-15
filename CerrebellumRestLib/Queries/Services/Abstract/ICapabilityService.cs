using CerebellumRestLib.Models.JSON.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CerebellumRestLib.Queries.Services.Abstract
{
    public interface ICapabilityService
    {
        Task<IEnumerable<Allowed>> GetAllowed();
        Task<IEnumerable<State>> GetStates();
        Task<IEnumerable<Capability>> GetCapabilities();
    }
}
