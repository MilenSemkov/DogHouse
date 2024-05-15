using DogHouse11DMS2.Controller;
using DogHouse11DMS2.Model;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DogHouse11DMS2.View
{
    internal class Diplay
    {
        private DogsController dogcontroller = new DogsController();
        private int closeOperation = 6;
        public Diplay()
        {
            Input();
        }
        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "MENU" + new string(' ', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all enttries");
            Console.WriteLine("2. Add new entry");
            Console.WriteLine("3. Update entry");
            Console.WriteLine("4. Fetch entry by ID");
            Console.WriteLine("5. Delete entry by ID");
            Console.WriteLine("6. Exit");
        }
        private void Input()
        {
            var operation = -1;
            do
            {
                ShowMenu();
                operation = int.Parse(Console.ReadLine());
                switch (operation)
                {
                    case 1:
                        ListAll();
                        break;
                    case 2:
                        Add();
                        break;
                    case 3:
                        Update();
                        break;
                    case 4:
                        Fetch();
                        break;
                    case 5:
                        Delete();
                        break;
                    default:

                        break;
                }
            } while (operation != closeOperation);
        }
        private void PrintDog(Dog dog)
        {
            Console.WriteLine($"{dog.Id}. {dog.Name} -- Age: {dog.Age} BreedId: {dog.BreedsId}");
        }
        private void Delete()
        {
            Console.WriteLine("Enter ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            DogsController dogsController = new DogsController();
            Dog dog = dogsController.Get(id);
            if (dog != null)
            {
                dogcontroller.Delete(id);
            }
        }
        private void Fetch()
        {
            Console.WriteLine("Enter ID to fetch: ");
            int id = int.Parse(Console.ReadLine());
            DogsController dogsController = new DogsController();
            Dog dog = dogsController.Get(id);
            if (dog != null)
            {
                PrintDog(dog);
            }
        }
        private void ListAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "MENU" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            DogsController dogsController = new DogsController();
            var products = dogcontroller.GetAll();
            foreach (var item in products)
            {
                Console.WriteLine($"{item.Id} {item.Name} {item.Age} {item.BreedsId}");
            }
        }
        private void Add()
        {
            Dog newDog = new Dog();
            Console.Write("Name: ");
            newDog.Name = Console.ReadLine();

            Console.Write("Age: ");
            newDog.Age = int.Parse(Console.ReadLine());

            BreedController breedController = new BreedController();
            List<Breed> allBreeds = breedController.GetAllBreeds();
            Console.WriteLine("Porodi: ");
            Console.WriteLine(new string('-', 4));
            foreach (var item in allBreeds)
            {
                Console.WriteLine(item.Id + ". " + item.Name);
            }
            Console.WriteLine("Izberi poroda:");
            newDog.BreedsId = int.Parse(Console.ReadLine());

            DogsController dogsController2 = new DogsController();
            dogsController2.Create(newDog);

            Console.WriteLine($"{newDog.Id}. {newDog.Name} -- Age: {newDog.Age} BreedId: {newDog.BreedsId}");
        }
        private void Update()
        {
            Console.Write("Enter the DOG's ID: ");
            int dogId = int.Parse(Console.ReadLine());
            Dog newDog = dogcontroller.Get(dogId);
            if(newDog == null)
            {
                Console.WriteLine("No searching dog");
                return;
            }
            PrintDog(newDog);

            Console.WriteLine("Enter the new values: ");
            Console.Write("Name: ");
            newDog.Name=Console.ReadLine();

            Console.WriteLine("Age: ");
            newDog.Age=int.Parse(Console.ReadLine());

            BreedController breedController = new BreedController();
            List<Breed> allBreeds = breedController.GetAllBreeds();
            Console.WriteLine("Porodi: ");
            Console.WriteLine(new string('-',4));
            foreach (var item in allBreeds)
            {
                Console.WriteLine(item.Id+". "+item.Name);
            }
            Console.WriteLine("Izberi poroda: ");
            newDog.BreedsId = int.Parse(Console.ReadLine());
            DogsController controller=new DogsController();
            controller.Update(dogId, newDog);
        }

    }
}
