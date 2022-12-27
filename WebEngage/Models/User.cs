using System;
using System.Collections.Generic;

namespace WebEngage.Models;

public partial class User
{
    public int Id { get; set; }

    public string? UserId { get; set; }

    public string? AnonymousId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? BirthDate { get; set; }

    public string? Gender { get; set; }

    public string? Email { get; set; }

    public bool? EmailOptIn { get; set; }

    public bool? SmsOptIn { get; set; }

    public string? WhatsappOptIn { get; set; }

    public string? Company { get; set; }

    public string? HashedEmail { get; set; }

    public string? HashedPhone { get; set; }

    public string? Attributes { get; set; }
}
