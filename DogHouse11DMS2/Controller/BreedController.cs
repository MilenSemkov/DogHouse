using DogHouse11DMS2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogHouse11DMS2.Controller
{
    internal class BreedController
    {
        private DogsDbContext _dogsDbContext=new DogsDbContext();
        public List<Breed> GetAllBreeds()
        {
            return _dogsDbContext.Breeds.ToList();
        }
        public string GetBreedsId(int id)
        {
            return _dogsDbContext.Breeds.Find(id).Name;
        }
    }
}
