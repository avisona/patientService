using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PatientServices.Models
{
    [Table("tblCountry")]
    public partial class Country
    {
        public Country()
        {
            TblPatient = new HashSet<Patient>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string CountryName { get; set; }

        [InverseProperty("PatientCountryNavigation")]
        public virtual ICollection<Patient> TblPatient { get; set; }
    }
}
