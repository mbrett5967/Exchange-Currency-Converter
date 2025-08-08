using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;




static void Main ()
{

}

//namespace CurrencyConverter
/*

public class Converter
{
    // API key
    private const string ApiUrl = "https://api.exchangerate-api.com/v4/latest/GBP";

    public static async Task Main()
    {
        await ExecuteMainLogic();
    }
    // Main 
    public static async Task ExecuteMainLogic();
    {
        
     double userValue = GetAmountFromUser();
    var rates = await FetchLiveRates();
            //var selectedFromCurrency = 
            //var convertingToCurrency = 


           // Handling exception from API pull 
        if (rates != null)
            {
                DisplayConversionResults(userValue, rates);
}
        else
            {
                Console.WriteLine("Unable to fetch rates. Please try again later.");
            }
            ShowEndMenu();
        } 



         // User Input - will need to pull users current currency from API
        private static double GetAmountFromUser()
        {
            Console.WriteLine("Enter amount: ");
            double userValue;
            while (!double.TryParse(Console.ReadLine(), out userValue) || userValue <= 0)
            {
                Console.WriteLine("Please enter a valid positive amount using a decimal");
            }
            return Math.Round(userValue, 2);
        }
        
        // Return list of currencies
       // public static List<string> GetSupportedCurrencies(JObject rates)
        {










        // Fetching live rates, calculate conversion and return result to UI
        public static async Task<double> ConvertCurrency(double amount, string fromCurrency, string toCurrency)

        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(ApiUrl);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    return JObject.rates(responseBody);
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                    return null;
                }
            }
        }         
   
    
 */



//. Chinese Yuans , US Dollar , GBP , Euro , Japanese Yen , Kenyan Shillings ,Indian Rupees
// UAE Dirhams , New Zealand Dollars, Australian Dollars , Turkish Lira , Qatar riyals , Saudi riyals