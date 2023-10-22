using System;
using System.Collections.Generic;

namespace ConnectDBApp;

public partial class User
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public long Age { get; set; }
}
