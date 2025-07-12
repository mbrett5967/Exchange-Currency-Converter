using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace CurrencyConverter
{
    public class Converter
    {
        // API key
        private const string ApiUrl = "https://api.exchangerate-api.com/v4/latest/GBP";

        public static async Task Main()
        {
            await ExecuteMainLogic();
        }

        public static async Task ExecuteMainLogic()
        {
            double pounds = GetAmountFromUser();
            var rates = await FetchLiveRates();
          
            // Handling excpetion from API pull 
            if (rates != null)
            {
                DisplayConversionResults(pounds, rates);
            }
            else
            {
                Console.WriteLine("Unable to fetch rates. Please try again later.");
            }
            ShowEndMenu();
        }
         // User Input GBP only
        private static double GetAmountFromUser()
        {
            Console.WriteLine("Enter amount: (GBP)");
            double pounds;
            while (!double.TryParse(Console.ReadLine(), out pounds) || pounds <= 0)
            {
                Console.WriteLine("Please enter a valid positive amount using a decimal");
            }
            return Math.Round(pounds, 2);
        }
        // Fetching live rates
        private static async Task<JObject?> FetchLiveRates()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(ApiUrl);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    return JObject.Parse(responseBody);
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                    return null;
                }
            }
        }
        // Output of results
        private static void DisplayConversionResults(double pounds, JObject rates)
        {
            if (rates == null)
            {
                Console.WriteLine("Unable to fetch rates. Please try again later.");
                return;
            }

            Console.WriteLine($"\n£{pounds} is equal to: ");
            if (rates["rates"]?["USD"] != null && rates["rates"]?["EUR"] != null)
            {
                double usdRate = rates["rates"]?["USD"]?.Value<double>() ?? 0;
                double euroRate = rates["rates"]?["EUR"]?.Value<double>() ?? 0;
                double usdAmount = Math.Round(pounds * usdRate, 2);
                double euroAmount = Math.Round(pounds * euroRate, 2);

                Console.WriteLine($"- {usdAmount} USD");
                Console.WriteLine($"- {euroAmount} Euros");
            }
            else
            {
                Console.WriteLine("Currency rates for USD or EUR are not available.");
            }
        }
       // End menu display
        private static void ShowEndMenu()
        {
            Console.WriteLine();
            Console.WriteLine("[R]eset");
            Console.WriteLine("[E]xit");
            char finale = Console.ReadKey(true).KeyChar;
            EndMenu(finale);
        }
    // End menu options 
        private static void EndMenu(char endOption)
        {
            if (endOption == 'R' || endOption == 'r')
            {
                Console.WriteLine("\nResetting...");
                ExecuteMainLogic().Wait();
            }
            else if (endOption == 'E' || endOption == 'e')
            {
                Console.WriteLine("Exiting...");
                Environment.Exit(0);
            }
        }
    }
}




