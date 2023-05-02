namespace Shoppica.UI
{
    public static class GlobalConfig
    {
        public static HttpClient Client = new HttpClient();

        static GlobalConfig()
        {
            Client.BaseAddress = new Uri("https://localhost:7170/api/");
        }
    }
}
