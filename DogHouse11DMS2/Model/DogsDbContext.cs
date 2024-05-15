using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogHouse11DMS2.Model
{
    internal class DogsDbContext:DbContext
    {
        public DogsDbContext() : base("DogsDbContext")
        {

        }
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<Breed> Breeds { get; set; }
    }
}
