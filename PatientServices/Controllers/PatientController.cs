using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientServices.Data;
using PatientServices.dtos;
using PatientServices.Models;

namespace PatientServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatient _patient;

        public PatientController(IPatient patient)
        {
            _patient = patient;
        }


        // GET: api/Patient
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var p=await _patient.Getpatients();
            return Ok(p);
        }

        // GET: api/Patient/5
        [HttpGet("{id:int}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            var p = await _patient.Getpatient(id);
            return Ok(p);
        }

        // GET: api/PatientByName/Name
        [HttpGet("{patientName}", Name = "GetByName")]
        public async Task<IActionResult> GetByName(string patientName)
        {
            var p = await _patient.GetpatientbyName(patientName);
            return Ok(p);
        }

        // POST: api/Patient
        [HttpPost]
        public async Task<IActionResult> Post(patientDto patientdt)
        {
            var patientNew = new Patient {
                PatientFname = patientdt.PatientFname,
                PatientLname = patientdt.PatientLname,
                PatientCountry=patientdt.PatientCountry,
                PatientDesc=patientdt.PatientDesc
        };

            var chk = await _patient.Createpatient(patientNew);
            if (chk == true)
            { return StatusCode(201); }
            else
            { 
                return StatusCode(500);
            }
        }

        //// PUT: api/Patient/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
