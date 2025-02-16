using System.Collections.Generic;
using WoflDogWebCode.Models;

namespace WoflDogWebCode.Services
{
    public interface IResourceClassService
    {
        List<ResourceClass> GetResourceClasses();
        ResourceClass GetResourceClass();
        void AddResourceClass(ResourceClass resourceClass);
        void UpdateResourceClass(ResourceClass resourceClass);
        void DeleteResourceClass(int id);
    }
}
