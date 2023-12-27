using Learning.Domain.Models;

namespace Learning.Service.Interfaces
{
    public interface IPetService
    {
        Task<Pet> GetById(int id);

        Task<Pet> Create(Pet pet);
    }
}
