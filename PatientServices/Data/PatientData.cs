using Microsoft.EntityFrameworkCore;
using PatientServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace PatientServices.Data
{
    public class PatientData : IPatient
    {
        private readonly DBConnect _db;

        public PatientData(DBConnect DB)
        {
            _db = DB;
        }

        public async Task<bool> Createpatient(Patient patient) {

            await _db.TblPatient.AddAsync(patient);
           bool Chk= await _db.SaveChangesAsync()>0;

            return Chk;

        }
        public async Task<Patient> Getpatient(int patientId)
        {
            var patient= await _db.TblPatient.FirstOrDefaultAsync(x => x.Id == patientId);
            return patient;
        }

        public async Task<Patient> GetpatientbyName(string patientName)
        {
            var patient = await _db.TblPatient.FirstOrDefaultAsync(x => x.PatientFname.Contains(patientName) || x.PatientLname.Contains(patientName));
            return patient;
        }

        public async Task<IEnumerable<Patient>> Getpatients()
        {
            var p = await _db.TblPatient.ToListAsync();
            return p;
        }
    }
}
