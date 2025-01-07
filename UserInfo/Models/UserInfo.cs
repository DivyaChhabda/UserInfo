using System;
using System.Collections.Generic;

namespace UserInfo.Models;

public partial class UserInfo
{
    public int UserId { get; set; }

    public string? UserType { get; set; } 

    public string? UserEmail { get; set; }

    public DateTime DateJoined { get; set; }

    public DateTime DateLastUpdated { get; set; }
}
