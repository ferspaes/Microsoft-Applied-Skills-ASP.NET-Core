using Learning.Domain.Models;
using Learning.Repository.Interfaces;
using Learning.Service.Interfaces;

namespace Learning.Service.Services
{
    public class PetService : IPetService
    {
        private readonly IPetRepository _petRepository;

        public PetService(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public async Task<Pet> Create(Pet pet)
        {
            return await _petRepository.Create(pet);
        }

        public async Task<Pet> GetById(int id)
        {
            return await _petRepository.GetById(id);
        }
    }
}
