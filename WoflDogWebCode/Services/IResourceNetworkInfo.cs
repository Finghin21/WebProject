using System.Collections.Generic;
using WoflDogWebCode.Models;

namespace WoflDogWebCode.Services
{
    public interface IResourceNetworkInfoService
    {
        List<ResourceNetworkInfo> GetResourceNetworkInfos();
        ResourceNetworkInfo GetResourceNetworkInfo();
        void AddResourceNetworkInfo(ResourceNetworkInfo resourceNetworkInfo);
        void UpdateResourceNetworkInfo(ResourceNetworkInfo resourceNetworkInfo);
        void DeleteResourceNetworkInfo(int id);
    }
}
