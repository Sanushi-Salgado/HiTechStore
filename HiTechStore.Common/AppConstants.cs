namespace HiTechStore.Common
{
    public class AppConstants
    {
        // Hosted web API - base url
        public const string BASE_URL = "https://localhost:44373/api/";


        // Endpoint resources
        public const string AUTHENTICATION = "authentication";

        public const string USERS_RESOURCE = "users";

        public const string PRODUCTS_RESOURCE = "products";

        public const string CUSTOMERS_RESOURCE = "customers";


        // Endpoint URLs
        public const string ADMIN_REGISTRATION_ENDPOINT = BASE_URL + AUTHENTICATION + "/register-admin";

        public const string USER_REGISTRATION_ENDPOINT = BASE_URL + AUTHENTICATION + "/register";
    
        public const string LOGIN_ENDPOINT = BASE_URL + AUTHENTICATION + "/login";

        public const string USERS_ENDPOINT = BASE_URL + USERS_RESOURCE;

        public const string PRODUCTS_ENDPOINT = BASE_URL + PRODUCTS_RESOURCE;

        public const string PRODUCTS_TYPES_ENDPOINT = BASE_URL + PRODUCTS_RESOURCE + "/types";

        public const string CUSTOMERS_ENDPOINT = BASE_URL + CUSTOMERS_RESOURCE;

        public const string CUSTOMER_CONTACT_DETAILS_ENDPOINT = BASE_URL + CUSTOMERS_RESOURCE + "/contact_details";

        public const string CUSTOMER_ORDER_DETAILS_ENDPOINT = BASE_URL + CUSTOMERS_RESOURCE + "/order_details";
   
    }
}