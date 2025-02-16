using System.Collections.Generic;
using WoflDogWebCode.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WoflDogWebCode.Services
{
    public class ResourceClassService : IResourceClassService
    {
        private readonly WoflDogWebCode.Models.ApplicationDbContext _context;

        public ResourceClassService(WoflDogWebCode.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public List<ResourceClass> GetResourceClasses()
        {
            return _context.ResourceClasses.Include(rc => rc.ResourceNetworkInfos).ToList();
        }

        public ResourceClass GetResourceClass()
        {
            return null;
        }

        public void AddResourceClass(ResourceClass resourceClass)
        {
            _context.ResourceClasses.Add(resourceClass);
            _context.SaveChanges();
        }

        public void UpdateResourceClass(ResourceClass resourceClass)
        {
            _context.ResourceClasses.Update(resourceClass);
            _context.SaveChanges();
        }

        public void DeleteResourceClass(int id)
        {
            var resourceClassToRemove = _context.ResourceClasses.Find(id);
            if (resourceClassToRemove != null)
            {
                _context.ResourceClasses.Remove(resourceClassToRemove);
                _context.SaveChanges();
            }
        }
    }
}
