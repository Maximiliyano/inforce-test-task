namespace URLShortener.WebApi.Models;

public abstract class BaseEntity
{
    private DateTime _createdAt;

    protected BaseEntity()
    {
        CreatedAt = UpdatedAt = DateTime.Now;
    }

    public int Id { get; set; }

    public DateTime CreatedAt
    {
        get => _createdAt;
        set => _createdAt = (value == DateTime.MinValue) ? DateTime.Now : value;
    }
    
    public DateTime UpdatedAt { get; set; }
}