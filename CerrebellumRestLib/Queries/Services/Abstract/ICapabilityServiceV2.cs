using CerebellumRestLib.Models.JSON.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CerebellumRestLib.Queries.Services.Abstract
{
    public interface ICapabilityServiceV2
    {
        Task<IEnumerable<Allowed>> GetAllowed();
        Task<IEnumerable<State>> GetStates();
        Task<IEnumerable<Capability>> GetCapabilities();
    }
}
