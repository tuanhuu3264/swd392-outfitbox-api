namespace SWD392.OutfitBox.API.Controllers.Endpoints
{
    public static class UserEndpoints
    {
        public const string GetAllUsers = "users";
        public const string GetUserById = "users/{id}";
        public const string CreateUser  = "users";
        public const string UpdateUser = "users";
        public const string ActiveOrDeactiveUser = "users/active-or-deactive/{id}";
    }
}
