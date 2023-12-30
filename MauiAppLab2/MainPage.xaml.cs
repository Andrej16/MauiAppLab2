namespace MauiAppLab2
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count += 5;

            if (count == 1)
                CounterBtn.Text = $"Wow you clicked {count} time";
            else
                CounterBtn.Text = $"Wow wow stop please, since you clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }
}
