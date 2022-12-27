using System;
using System.Collections.Generic;

namespace WebEngage.Models;

public partial class Event
{
    public int Id { get; set; }

    public string? UserId { get; set; }

    public string? AnonymousId { get; set; }

    public string? EventName { get; set; }

    public string EventTime { get; set; } = null!;

    public string? EventData { get; set; }

    public DateTime? Date { get; set; }
}
