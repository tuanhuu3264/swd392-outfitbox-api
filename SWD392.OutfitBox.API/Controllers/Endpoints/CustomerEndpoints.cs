namespace SWD392.OutfitBox.API.Controllers.Endpoints
{
    public static class CustomerEndpoints
    {
        public const string GetAllCustomers = "customers";
        public const string GetCustomerById = "customers/{id}";
        public const string CreateCustomer  = "customers";
        public const string UpdateCustomer = "customers";
        public const string ActiveOrDeactiveCustomer = "customers/active-or-deactive/{id}";
    }
}
