using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PatientServices.Models
{
    [Table("tblPatient")]
    public partial class Patient
    {
        [Key]
        public int Id { get; set; }
        [Column("PatientFName")]
        [StringLength(100)]
        public string PatientFname { get; set; }
        [Column("PatientLName")]
        [StringLength(100)]
        public string PatientLname { get; set; }
        public int? PatientCountry { get; set; }
        [StringLength(200)]
        public string PatientDesc { get; set; }

        [ForeignKey(nameof(PatientCountry))]
        [InverseProperty(nameof(Country.TblPatient))]
        public virtual Country PatientCountryNavigation { get; set; }
    }
}
