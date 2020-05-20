using PatientServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientServices.Data
{
   public interface IPatient
    {
        Task<IEnumerable<Patient>> Getpatients();
        Task<Patient> Getpatient(int patientId);
        Task<bool> Createpatient(Patient patient);
        Task<Patient> GetpatientbyName(string patientName);


    }
}
