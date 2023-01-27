namespace BlazorEcommerce.Client.Services.Interfaces
{
    public interface IOrderService
    {
        Task<string> PlaceOrder();
        Task<List<OrderOverviewResponse>> GetOrders();
        Task<OrderDetailsResponse> GetOrderDetails(int orderId);
    }
}
