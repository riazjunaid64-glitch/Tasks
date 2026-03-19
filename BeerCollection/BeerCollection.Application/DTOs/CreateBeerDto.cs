namespace BeerCollection.Application.DTOs;

public class CreateBeerDto
{
    public string Name { get; set; }
    public string Type { get; set; }
    public int? Rating { get; set; }
}
