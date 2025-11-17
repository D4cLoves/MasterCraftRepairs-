using System;
namespace MasterCraftRepairs.Domain.Entities;

public abstract class Order
{
     public Guid Id { get; protected set; } = Guid.NewGuid();
     
     public Guid ProductId { get; private set; }
     public Guid MasterId { get; private set; }
     public Guid ClientId { get; private set; }
     
     public DateTime StartDate { get; protected set; }
     public DateTime? EndDate { get; protected set; }
     
     public decimal Price { get; private set; }

     protected Order(Guid productId, Guid masterId, Guid clientId, decimal price)
     {
         ProductId = productId;
         MasterId = masterId;
         ClientId = clientId;
         StartDate = DateTime.UtcNow;
         Price = price;
     }

     public abstract Order PutIntoWork(Guid masterId);
     public abstract Order Complete(DateTime endDate);
     public abstract Order Cancel();
}

public class NewOrder : Order
{
    NewOrder(Guid productId, Guid masterId, Guid clientId, decimal price) : base(productId, masterId, clientId, price)
    {
    }
    
    public override Order PutIntoWork(Guid masterId) => new OrderInProgress(Id, ProductId, masterId, ClientId, Price, StartDate);
    public override Order Complete(DateTime endDate) => throw new InvalidOperationException("нет");
    public override Order Cancel() => new CancelledOrder(Id, ProductId, MasterId, ClientId, Price, StartDate);
}

public class OrderInProgress : Order
{
    public OrderInProgress(Guid id, Guid productId, Guid masterId, Guid clientId, decimal price, DateTime startDate) : base(
        productId, masterId, clientId, price)
    {
        Id = id;
        StartDate = startDate;
    }

    public override Order PutIntoWork(Guid masterId) => this;
    public override Order Complete(DateTime endDate) => new CompletedOrder(Id, ProductId, MasterId, ClientId, Price, StartDate, endDate);
    public override Order Cancel() => new CancelledOrder(Id, ProductId, MasterId, ClientId, Price, StartDate);
    
}

public class CompletedOrder : Order
{
    public CompletedOrder(Guid id, Guid productId, Guid masterId, Guid clientId, decimal price, DateTime startDate,
        DateTime endDate) : base(
        productId, masterId, clientId, price)
    {
        Id = id;
        StartDate = startDate;
        EndDate =  endDate;
    }
    
    public override Order PutIntoWork(Guid masterId) => throw new InvalidOperationException("нет, он уже завершен");
    public override Order Complete(DateTime endDate) => this;
    public override Order Cancel() => throw new InvalidOperationException("нет, он уже завершен");
}

public class CancelledOrder : Order
{
    public CancelledOrder(Guid id, Guid productId, Guid masterId, Guid clientId, decimal price, DateTime startDate) : base(
        productId, masterId, clientId, price)
    {
        Id = id;
        StartDate = startDate;
    }
    
    public override Order PutIntoWork(Guid masterId) => throw new InvalidOperationException("нет, он уже отменен");
    public override Order Complete(DateTime endDate) => throw new InvalidOperationException("нет, он уже отменен");
    public override Order Cancel() => this;
}