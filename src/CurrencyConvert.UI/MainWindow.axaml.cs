using Avalonia.Controls;

namespace CurrencyConvert.UI;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        // Listbox buttons - These get updated when the user selects a currency.(state tracking)
        //string selectedFromCurrency = FromListBox.SelectedItem.ToString();
        //string convertingToCurrency = ToListBox.SelectedItem.ToString();
     
    }
    
    private void UserInput_GotFocus(object sender, Avalonia.Input.GotFocusEventArgs e)
{
    // Clear the text box content when it gains focus
    UserInput.Text = "";
}

}