using System;
using System.Collections.Generic;

namespace SGU.Data;

public partial class User
{
    public string FirstName { get; set; } = null!;

    public string MiddleName { get; set; } = null!;

    public string? LastName { get; set; }

    public long GenderId { get; set; }

    public string BornPlace { get; set; } = null!;

    public string EMail { get; set; } = null!;

    public byte[]? BornDate { get; set; }

    public string? PhoneNumber { get; set; }

    public byte[]? NeedHostel { get; set; }

    public byte[]? Photo { get; set; }

    public long? PassportSeries { get; set; }

    public long? PassportNumber { get; set; }

    public string? PassportIssued { get; set; }

    public long? DivisionCode { get; set; }

    public byte[]? PassportDate { get; set; }

    public byte[]? PassportScan { get; set; }

    public string? Street { get; set; }

    public long? HomeNumber { get; set; }

    public long? FlatNumber { get; set; }

    public long? FormOfStudyId { get; set; }

    public long? CertificateNumber { get; set; }

    public byte[]? CertificateScan { get; set; }

    public long? CerificateOriginalityId { get; set; }

    public long Id { get; set; }

    public long? DirectionId { get; set; }

    public long? CityId { get; set; }

    public string? Password { get; set; }

    public virtual CertificateOriginality? CerificateOriginality { get; set; }

    public virtual City? City { get; set; }

    public virtual Direction? Direction { get; set; }

    public virtual FormOfStudy? FormOfStudy { get; set; }

    public virtual Gender Gender { get; set; } = null!;

    public virtual ICollection<IndividualAchivment> IndividualAchivments { get; } = new List<IndividualAchivment>();
}
