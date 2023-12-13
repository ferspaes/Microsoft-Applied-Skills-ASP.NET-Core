using Learning.Domain.Models;
using Learning.Repository.Interfaces;

namespace Learning.Repository.Repositories
{
    public class PetRepository : IPetRepository
    {
        private static List<Pet> _pets;
        public PetRepository()
        {
            _pets = new List<Pet>();
        }

        public async Task<Pet> Create(Pet pet)
        {
            if (!_pets.Any())
            {
                pet.Id = 1;
            }

            var petToAdd = new Pet()
            {
                Active = true,
                Date = DateTime.Now,
                Description = pet.Description,
                Name = $"{pet.Name}_{pet.Id}",
                Id = pet.Id,
            };

            _pets.Add(petToAdd);

            return _pets.FirstOrDefault(x => x.Id == petToAdd.Id);
        }

        public async Task<Pet> GetById(int id)
        {
            if (_pets.Any(x => x.Id == id))
            {
                return _pets[id];
            }
            else
            {
                return null;
            }
        }
    }
}
