using System.Text;

namespace MauiAppLab2.Views;

public partial class PhoneWordTranslatorPage : ContentPage
{
    string translatedNumber = string.Empty;

    public PhoneWordTranslatorPage()
    {
        InitializeComponent();
    }

    private void OnTranslate(object sender, EventArgs e)
    {
        string enteredNumber = PhoneNumberText.Text;
        translatedNumber = ToNumber(enteredNumber);

        if (!string.IsNullOrEmpty(translatedNumber))
        {
            CallButton.IsEnabled = true;
            CallButton.Text = "Call " + translatedNumber;
        }
        else
        {
            CallButton.IsEnabled = false;
            CallButton.Text = "Call";
        }
    }

    async void OnCall(object sender, EventArgs e)
    {
        if (await DisplayAlert(
            "Dial a Number",
            "Would you like to call " + translatedNumber + "?",
            "Yes",
            "No"))
        {
            try
            {
                if (PhoneDialer.Default.IsSupported)
                    PhoneDialer.Default.Open(translatedNumber);
            }
            catch (ArgumentNullException)
            {
                await DisplayAlert("Unable to dial", "Phone number was not valid.", "OK");
            }
            catch (Exception)
            {
                // Other error has occurred.
                await DisplayAlert("Unable to dial", "Phone dialing failed.", "OK");
            }
        }
    }

    public static string ToNumber(string raw)
    {
        if (string.IsNullOrWhiteSpace(raw))
            return null;

        raw = raw.ToUpperInvariant();

        StringBuilder newNumber = new StringBuilder();
        foreach (char c in raw)
        {
            if (" -0123456789".Contains(c))
                newNumber.Append(c);
            else
            {
                int? result = TranslateToNumber(c);
                if (result != null)
                    newNumber.Append(result);
                // Bad character?
                else
                    return null;
            }
        }
        return newNumber.ToString();
    }

    static readonly string[] digits = {
        "ABC", "DEF", "GHI", "JKL", "MNO", "PQRS", "TUV", "WXYZ"
    };

    static int? TranslateToNumber(char c)
    {
        for (int i = 0; i < digits.Length; i++)
        {
            if (digits[i].Contains(c))
                return 2 + i;
        }
        return null;
    }

}