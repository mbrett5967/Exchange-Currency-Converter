using Avalonia;
using Avalonia.Controls;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;


namespace CurrencyConvert.UI;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        // Fill ComboBoxes
        selectedFromCurrency.Items.Clear();
        selectedFromCurrency.ItemsSource = new string[] { "USD", "EUR", "GBP", "JPY" };
        convertingToCurrency.Items.Clear();
        convertingToCurrency.ItemsSource = new string[] { "USD", "EUR", "GBP", "JPY" };
    }

    private async void OnConvertClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        // Get selections
        string from = selectedFromCurrency.SelectedItem?.ToString();
        string to = convertingToCurrency.SelectedItem?.ToString();
        string amountText = UserInput.Text; 

        if (string.IsNullOrEmpty(from) || string.IsNullOrEmpty(to) || string.IsNullOrEmpty(amountText))
        {
            await ShowDialog("Please enter all values.");
            return;
        }

        if (!decimal.TryParse(amountText, out decimal amount))
        {
            await ShowDialog("Invalid amount.");
            return;
        }

        try
        {
            using var client = new HttpClient();
            string url = $"https://api.frankfurter.app/latest?amount={amount}&from={from}&to={to}";
;
            var response = await client.GetStringAsync(url);

            using var doc = JsonDocument.Parse(response);
            decimal result = doc.RootElement
                        .GetProperty("rates")
                        .GetProperty(to)
                        .GetDecimal();

            await ShowDialog($"{amount} {from} = {result} {to}");
        }
        catch
        {
            await ShowDialog("Error fetching conversion.");
        }
    }

    private async Task ShowDialog(string message)
    {
        var dialog = new Window
        {
            Content = new TextBlock { Text = message, Margin = new Thickness(20) },
            Width = 300,
            Height = 150
        };

        await dialog.ShowDialog(this);
    }

    private void UserInput_GotFocus(object sender, Avalonia.Input.GotFocusEventArgs e)
    {
        // Clear the text box content when it gains focus
        UserInput.Text = "";
    }
}