using BeerCollection.Application.DTOs;
using BeerCollection.Domain.Entities;

namespace BeerCollection.Application.Interfaces;

public interface IBeerService
{
    Task AddBeerAsync(CreateBeerDto dto);
    Task<List<Beer>> GetAllAsync();
    Task<List<Beer>> SearchAsync(string query);
    Task RateBeerAsync(Guid id, int rating);
}
