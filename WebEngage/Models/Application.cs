using System;
using System.Collections.Generic;

namespace WebEngage.Models;

public partial class Application
{
    public int Id { get; set; }

    public string? AppName { get; set; }

    public string? License { get; set; }

    public string? AppCode { get; set; }
}
