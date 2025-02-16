using System;
using System.Collections.Generic;

namespace WoflDogWebCode.Models;

public partial class ResourceNetworkInfo
{
    public long Id { get; set; }

    public long? ClassId { get; set; }

    public string Title { get; set; } = null!;

    public string Href { get; set; } = null!;

    public string ImageUrl { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ResourceClass? Class { get; set; }
}
