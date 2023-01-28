namespace BlazorEcommerce.Client.Shared
{
    public class AddressFormBase : ComponentBase
    {
        [Inject]
        public IAddressService AddressService { get; set; }

        protected Address address = null;
        protected bool editAddress = false;

        protected override async Task OnInitializedAsync()
        {
            address = await AddressService.GetAddress();
        }

        protected async Task SubmitAddress()
        {
            editAddress = false;
            address = await AddressService.AddOrUpdateAddress(address);
        }

        protected void InitAddress()
        {
            address = new Address();
            editAddress = true;
        }

        protected void EditAddress()
        {
            editAddress = true;
        }
    }
}
