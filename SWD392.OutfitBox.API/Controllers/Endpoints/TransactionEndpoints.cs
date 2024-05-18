namespace SWD392.OutfitBox.API.Controllers.Endpoints
{
    public static class TransactionEndpoints
    {
        public const string Checkout = "transactions/checkout";
        public const string GetAllTransactionsByUserId = "transactions/by-user-id/{userId}";
        public const string GetAllTransactionsByWalletId = "transactions/by-wallet-id/{walletId}/user-id/{userId}";
    }
}
