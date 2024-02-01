using System.Text;

namespace MauiAppLab2.Views;

public partial class DeviceInformationPage : ContentPage
{
	public DeviceInformationPage()
	{
		InitializeComponent();
	}

    private void DeviceInformationPage_Loaded(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"Model: {DeviceInfo.Current.Model}");
        sb.AppendLine($"Manufacturer: {DeviceInfo.Current.Manufacturer}");
        sb.AppendLine($"Name: {DeviceInfo.Current.Name}");
        sb.AppendLine($"OS Version: {DeviceInfo.Current.VersionString}");
        sb.AppendLine($"Idiom: {DeviceInfo.Current.Idiom}");
        sb.AppendLine($"Platform: {DeviceInfo.Current.Platform}");

        DeviceInformationLabel.Text = sb.ToString();    
    }
}