using BeerCollection.Application.DTOs;
using BeerCollection.Application.Interfaces;
using BeerCollection.Domain.Entities;

namespace BeerCollection.Application.Services;

public class BeerService : IBeerService
{
    private readonly List<Beer> _beers = new();

    public Task AddBeerAsync(CreateBeerDto dto)
    {
        var beer = new Beer(dto.Name, dto.Type, dto.Rating);
        _beers.Add(beer);

        return Task.CompletedTask;
    }

    public Task<List<Beer>> GetAllAsync()
    {
        return Task.FromResult(_beers);
    }

    public Task<List<Beer>> SearchAsync(string query)
    {
        var result = _beers
            .Where(b => b.Name.Contains(query, StringComparison.OrdinalIgnoreCase))
            .ToList();

        return Task.FromResult(result);
    }

    public Task RateBeerAsync(Guid id, int rating)
    {
        var beer = _beers.FirstOrDefault(b => b.Id == id);

        if (beer == null)
            throw new Exception("Beer not found");

        beer.AddRating(rating);

        return Task.CompletedTask;
    }
}
