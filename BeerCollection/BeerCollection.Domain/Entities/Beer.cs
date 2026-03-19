namespace BeerCollection.Domain.Entities;
public class Beer
{
    public Guid Id { get; private set; }

    public string Name { get; private set; }
    public string Type { get; private set; }

    public double AverageRating { get; private set; }
    public int RatingCount { get; private set; }

    // Required by EF Core for materialization.
    private Beer()
    {
        Name = string.Empty;
        Type = string.Empty;
    }

    public Beer(string name, string type, int? initialRating = null)
    {
        Id = Guid.NewGuid();
        Name = name;
        Type = type;

        if (initialRating.HasValue)
        {
            AverageRating = initialRating.Value;
            RatingCount = 1;
        }
        else
        {
            AverageRating = 0;
            RatingCount = 0;
        }
    }

    public void AddRating(int rating)
    {
        if (rating < 1 || rating > 5)
            throw new ArgumentException("Rating must be between 1 and 5");

        AverageRating = ((AverageRating * RatingCount) + rating) / (RatingCount + 1);
        RatingCount++;
    }
}
