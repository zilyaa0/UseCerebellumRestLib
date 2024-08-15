using CerebellumRestLib.Models;
using CerebellumRestLib.Models.Base;
using CerebellumRestLib.Models.JSON.Entities.Сontracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CerebellumRestLib.Queries.Services.Abstract
{
    public interface IContractsService
    {
        Task<PageableBase<Contract>> GetСontracts(ContractListRequest listRequest);
        Task<Contract> GetContract(long contractId);
    }
}
