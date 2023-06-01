
namespace Proiect_TWM.Configuration.ApiHelper
{
    //we made the class static because we don't want to instantiate it
    public static class ApiHelper
    {
        public static HttpClient ApiClient { get; set; }
        //not the best practice to have a static property, but we want to open the HttpClient once per application

        public static void InitializeClient()
        {
           ApiClient = new HttpClient();
           ApiClient.BaseAddress = new Uri("https://house-plants2.p.rapidapi.com/");
           ApiClient.DefaultRequestHeaders.Accept.Clear();
           ApiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")); //we only accept data with type json
           ApiClient.DefaultRequestHeaders.Add("X-RapidAPI-Key", "da30eae187mshf5055d7ea2d28dap1ca514jsn30ce36d43c05");
           ApiClient.DefaultRequestHeaders.Add("X-RapidAPI-Host", "house-plants2.p.rapidapi.com");
        }
    }
}
