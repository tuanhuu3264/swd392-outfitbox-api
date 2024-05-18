namespace SWD392.OutfitBox.API.Controllers.Endpoints
{
    public static class WalletEndpoints
    {
        public const string GetAllWalletsByUserId = "wallets/by-user-id/{userId}";
        public const string GetAllEnabledWalletsByUserId = "wallets/enabled/by-user-id/{userId}";
        public const string AddWalletsByUserId = "wallets/add-by-user-id/{userId}";
        public const string UpdateWalletByUserId = "wallets/update-by-user-id/{userId}";
        public const string ActiveOrDeactiveWallet = "wallets/active-or-deactive/{id}";
    }
}
