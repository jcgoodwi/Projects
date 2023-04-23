using System;
using System.Collections.Generic;

namespace DataAccess.Entities;

public partial class Cardset
{
    public int Id { get; set; }

    public string Front { get; set; } = null!;

    public string Back { get; set; } = null!;
}
