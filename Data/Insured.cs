using System;
using System.Collections.Generic;

namespace SampleApi.Data;

public partial class Insured
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public virtual ICollection<PolicyInfo> PolicyInfos { get; set; } = new List<PolicyInfo>();
}
