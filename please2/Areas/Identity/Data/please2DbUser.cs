using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace please2.Areas.Identity.Data;

// Add profile data for application users by adding properties to the please2DbUser class
public class please2DbUser : IdentityUser
{
    [PersonalData]
    [Column(TypeName = "nvarchar(100)")]
    public string CIN { get; set; }

    [PersonalData]
    [Column(TypeName ="nvarchar(100)")]
    public string FirstName {  get; set; }

    [PersonalData]
    [Column(TypeName = "nvarchar(100)")]
    public string LastName { get; set; }

    [PersonalData]
    [Column(TypeName = "nvarchar(100)")]
    public string Phone { get; set; }

    [PersonalData]
    [Column(TypeName = "nvarchar(100)")]
    public string Address { get; set; }
}

