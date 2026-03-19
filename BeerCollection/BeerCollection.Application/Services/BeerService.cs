using BeerCollection.Application.DTOs;
using BeerCollection.Application.Interfaces;
using BeerCollection.Domain.Entities;
using BeerCollection.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BeerCollection.Application.Services;

public class BeerService : IBeerService
{
    private readonly AppDbContext _context;

    public BeerService(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddBeerAsync(CreateBeerDto dto)
    {
        var beer = new Beer(dto.Name, dto.Type, dto.Rating);
        _context.Beers.Add(beer);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Beer>> GetAllAsync()
    {
        return await _context.Beers.ToListAsync();
    }

    public async Task<List<Beer>> SearchAsync(string query)
    {
        return await _context.Beers
            .Where(b => b.Name.Contains(query))
            .ToListAsync();
    }

    public async Task RateBeerAsync(Guid id, int rating)
    {
        var beer = await _context.Beers.FirstOrDefaultAsync(b => b.Id == id);

        if (beer == null)
            throw new Exception("Beer not found");

        beer.AddRating(rating);
        await _context.SaveChangesAsync();
    }
}
