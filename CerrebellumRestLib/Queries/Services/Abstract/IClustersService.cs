using CerebellumRestLib.Models;
using CerebellumRestLib.Models.JSON.Entities;
using CerebellumRestLib.Models.RequestParams;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CerebellumRestLib.Queries.Services.Abstract
{
    public interface IClustersService
    {
        Task<IEnumerable<Cluster>> GetClusters(ClusterListRequest listRequest);
    }
}
