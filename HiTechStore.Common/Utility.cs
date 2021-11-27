namespace HiTechStore.Common
{
    public class Utility
    {
        // Encodes the password 
        public string CalculateHash(string password) => System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));


        // Decodes the password
        public string DecodeFrom64(string encodedData) => System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(encodedData));

    }
}