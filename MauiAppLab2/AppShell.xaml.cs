using System.Windows.Input;

namespace MauiAppLab2
{
    public partial class AppShell : Shell
    {
        public Dictionary<string, Type> Routes { get; private set; } = new Dictionary<string, Type>();

        public AppShell()
        {
            InitializeComponent(); 
            BindingContext = this;
        }
    }
}
