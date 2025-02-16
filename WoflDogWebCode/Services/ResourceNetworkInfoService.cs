using System.Collections.Generic;
using System.Linq;
using WoflDogWebCode.Models;


namespace WoflDogWebCode.Services
{
    public class ResourceNetworkInfoService : IResourceNetworkInfoService
    {
        private readonly WoflDogWebCode.Models.ApplicationDbContext _context;
        
        public ResourceNetworkInfoService(WoflDogWebCode.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public List<ResourceNetworkInfo> GetResourceNetworkInfos()
        {
            return _context.ResourceNetworkInfos.ToList();
        }

        public ResourceNetworkInfo GetResourceNetworkInfo()
        {
            return null;
        }

        public void AddResourceNetworkInfo(ResourceNetworkInfo resourceNetworkInfo)
        {
            _context.ResourceNetworkInfos.Add(resourceNetworkInfo);
            _context.SaveChanges();
        }

        public void UpdateResourceNetworkInfo(ResourceNetworkInfo resourceNetworkInfo)
        {
            _context.ResourceNetworkInfos.Update(resourceNetworkInfo);
            _context.SaveChanges();
        }
        public void DeleteResourceNetworkInfo(int id)
        {
            var resourceNetworkInfoToRemove = _context.ResourceNetworkInfos.Find(id);
            if (resourceNetworkInfoToRemove != null)
            {
                _context.ResourceNetworkInfos.Remove(resourceNetworkInfoToRemove);
                _context.SaveChanges();
            }
        }
    }
}
