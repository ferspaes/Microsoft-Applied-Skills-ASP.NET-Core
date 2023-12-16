using Learning.Domain.Models;

namespace Learning.Repository.Interfaces
{
    public interface IPetRepository
    {
        Task<Pet> GetById(int id);
        Task<Pet> Create(Pet pet);
    }
}
