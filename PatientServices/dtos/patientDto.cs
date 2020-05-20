using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PatientServices.dtos
{
    public class patientDto
    {
        [Required]       
        [StringLength(100)]
        public string PatientFname { get; set; }
        [Required]
        [StringLength(100)]
        public string PatientLname { get; set; }
        [Required]
        public int? PatientCountry { get; set; }
        [StringLength(200)]
        public string PatientDesc { get; set; }

       
    }
}
