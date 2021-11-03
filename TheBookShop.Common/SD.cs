using System;

namespace TheBookShop.Common
{
    public static class SD //static details
    {
        public const string RoleAdmin = "Admin";
        public const string RolePatron = "Patron";
        public const string RoleEmployeee = "Employee";

        public const string LocalToken = "JWT Token";
        public const string LocalUserDetails = "User Details";
    }

    public enum SubscriptionStatus 
    {
        Unsubscribed = 0,
        Subscribed = 1
    }
}
