namespace BlazorEcommerce.Server.Services.Interfaces
{
    using Stripe.Checkout;
    public interface IPaymentService
    {
        Task<Session> CreateCheckoutSession();
        Task<ServiceResponse<bool>> FulfillOrder(HttpRequest request);
    }
}
