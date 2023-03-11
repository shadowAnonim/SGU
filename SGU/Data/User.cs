using System;
using System.Collections.Generic;

namespace SGU;

public partial class User
{
    public string FirstName { get; set; } = null!;

    public string MiddleName { get; set; } = null!;

    public string? LastName { get; set; }

    public long GenderId { get; set; }

    public string BornPlace { get; set; } = null!;

    public string EMail { get; set; } = null!;

    public byte[] BornDate { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public byte[] NeedHostel { get; set; } = null!;

    public byte[] Photo { get; set; } = null!;

    public long PassportSeries { get; set; }

    public long PassportNumber { get; set; }

    public string PassportIssued { get; set; } = null!;

    public long DivisionCode { get; set; }

    public byte[] PassportDate { get; set; } = null!;

    public byte[] PassportScan { get; set; } = null!;

    public string Street { get; set; } = null!;

    public long HomeNumber { get; set; }

    public long FlatNumber { get; set; }

    public long FormOfStudyId { get; set; }

    public long CertificateNumber { get; set; }

    public byte[] CertificateScan { get; set; } = null!;

    public long CerificateOriginalityId { get; set; }

    public long Id { get; set; }

    public long DirectionId { get; set; }

    public long CityId { get; set; }

    public virtual CertificateOriginality CerificateOriginality { get; set; } = null!;

    public virtual City City { get; set; } = null!;

    public virtual Direction Direction { get; set; } = null!;

    public virtual FormOfStudy FormOfStudy { get; set; } = null!;

    public virtual Gender Gender { get; set; } = null!;

    public virtual ICollection<IndividualAchivment> IndividualAchivments { get; } = new List<IndividualAchivment>();
}
