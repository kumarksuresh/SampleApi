using System;
using System.Collections.Generic;

namespace SampleApi.Data;

public partial class PolicyInfo
{
    public int Id { get; set; }

    public int InsuredId { get; set; }

    public int PolicyTypeId { get; set; }

    public string PolicyNumber { get; set; } = null!;

    public DateTime PolicyStartDate { get; set; }

    public DateTime PolicyEndDate { get; set; }

    public decimal PremiumAmount { get; set; }

    public virtual Insured Insured { get; set; } = null!;

    public virtual PolicyType PolicyType { get; set; } = null!;
}
