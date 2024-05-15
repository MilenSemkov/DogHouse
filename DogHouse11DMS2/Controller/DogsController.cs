using DogHouse11DMS2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DogHouse11DMS2.Controller
{
    internal class DogsController
    {
        private DogsDbContext _dogsDbContext=new DogsDbContext();
        public Dog Get(int id)
        {
            Dog findedDog = _dogsDbContext.Dogs.Find(id);
            if (findedDog != null) 
            {
                _dogsDbContext.Entry(findedDog).Reference(x => x.Breeds).Load();
            }
            return findedDog;
        }
        public List<Dog>GetAll()
        {
            return _dogsDbContext.Dogs.Include("Breed").ToList();
        }
        public void Create(Dog dog)
        {
            _dogsDbContext.Dogs.Add(dog);
            _dogsDbContext.SaveChanges();
        }
        public void Update(int id,Dog dog)
        {
            Dog findedDog = _dogsDbContext.Dogs.Find(id);
            if (findedDog == null) 
            {
                return;
            }
            findedDog.Age = dog.Age;
            findedDog.Name = dog.Name;
            findedDog.BreedsId = dog.BreedsId;
            _dogsDbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            Dog findedDog =_dogsDbContext.Dogs.Find(id);
            _dogsDbContext.Dogs.Remove(findedDog);
            _dogsDbContext.SaveChanges();
        }
    }
}
