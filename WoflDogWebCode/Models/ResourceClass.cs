using System;
using System.Collections.Generic;

namespace WoflDogWebCode.Models;

public partial class ResourceClass
{
    public long Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<ResourceNetworkInfo> ResourceNetworkInfos { get; } = new List<ResourceNetworkInfo>();
}
