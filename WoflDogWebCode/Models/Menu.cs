﻿using System;
using System.Collections.Generic;

namespace WoflDogWebCode.Models;

public partial class Menu
{
    public long Id { get; set; }

    public string Title { get; set; } = null!;

    public string Href { get; set; } = null!;

    public string Icon { get; set; } = null!;

    public long? ParentId { get; set; }
}
