using Stockly.Core.Enums;

namespace Stockly.Core.Entities;

public class StockMovement : BaseEntity
{
    public Guid ProductId { get; private set; }
    public StockMovementType Type { get; private set; }
    public int Quantity { get; private set; }
    public string? Reference { get; private set; }

    public Guid CreatedBy { get; private set; }

    public int PreviousQuantity { get; private set; }
    public int FinalQuantity { get; private set; }

    public StockMovement(
        Guid productId,
        StockMovementType type,
        int quantity,
        int previousQuantity,
        Guid createdBy,
        string? reference = null
    )
    {
        if (quantity <= 0)
            throw new ArgumentException("Quantity must be greater than zero.");

        if (type == StockMovementType.Out && quantity > previousQuantity)
            throw new InvalidOperationException("Insufficient stock for this movement.");

        ProductId = productId;
        Type = type;
        Quantity = quantity;
        Reference = reference;
        CreatedBy = createdBy;

        PreviousQuantity = previousQuantity;
        FinalQuantity = CalculateFinalQuantity(type, quantity, previousQuantity);
    }

    private static int CalculateFinalQuantity(
        StockMovementType type,
        int quantity,
        int previousQuantity
    )
    {
        return type == StockMovementType.In
            ? previousQuantity + quantity
            : previousQuantity - quantity;
    }
}
