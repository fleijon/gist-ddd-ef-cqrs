namespace Sales.Domain.Customers.Orders
{
    public enum OrderStatus
    {
        Canceled = 0,
        Placed = 1,
        WaitingForPayment = 2,
        ReadyToShip = 3
    }
}