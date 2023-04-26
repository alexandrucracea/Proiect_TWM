
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
           ApiClient.BaseAddress = new Uri("https://forkify-api.herokuapp.com/api");
           ApiClient.DefaultRequestHeaders.Accept.Clear();
           ApiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")); //we only accept data with type json
        }
    }
}
