﻿using System;
using System.Collections.Generic;

namespace NorthwindAPI.Domain;

public partial class Region
{
    public short RegionId { get; set; }

    public char RegionDescription { get; set; }

    public virtual ICollection<Territory> Territories { get; set; } = new List<Territory>();
}
