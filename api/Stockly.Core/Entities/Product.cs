namespace Stockly.Core.Entities;

public class Product : BaseEntity
{
    public string Name { get; private set; }
    public string Sku { get; private set; }
    public Guid CategoryId { get; private set; }
    public int CurrentQuantity { get; private set; }
    public int MinimumQuantity { get; private set; }
    public Guid CreatedBy { get; private set; }
    public Guid UpdatedBy { get; private set; }
    public DateTime? DeletedAt { get; private set; }

    public Product(
        string name,
        string sku,
        Guid categoryId,
        int currentQuantity,
        int minimumQuantity,
        Guid createdBy
    )
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name is required");

        if (string.IsNullOrWhiteSpace(sku))
            throw new ArgumentException("Sku is required");

        if (currentQuantity < 0)
            throw new ArgumentException("Current quantity cannot be negative");

        if (minimumQuantity < 0)
            throw new ArgumentException("Minimum quantity cannot be negative");

        Name = name;
        Sku = sku;
        CategoryId = categoryId;
        CurrentQuantity = currentQuantity;
        MinimumQuantity = minimumQuantity;
        CreatedBy = createdBy;
        UpdatedBy = createdBy;
    }

    public void UpdateStock(int quantity)
    {
        if (quantity < 0)
            throw new InvalidOperationException("Quantity cannot be negative");

        CurrentQuantity = quantity;
        UpdatedAt = DateTime.UtcNow;
    }
}
