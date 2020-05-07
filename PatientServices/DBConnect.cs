using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientServices
{
    public class DBConnect : DbContext
    {
        public DBConnect(DbContextOptions<DBConnect> options): base(options){}

    }
}
