using PasswordGenerator3.AppData;
using System.Windows;

namespace PasswordGenerator3.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PasswordGeneratorService _passwordGeneratorService;

        public MainWindow()
        {
            InitializeComponent();

        }

        private void GenerateBtn_Click(object sender, RoutedEventArgs e)
        {
            _passwordGeneratorService = new PasswordGeneratorService(NumbersCb.IsChecked.Value, SymbolCb.IsChecked.Value, LowerCb.IsChecked.Value, UpperCb.IsChecked.Value, WordsCb.IsChecked.Value);
            int lenght = int.Parse(PassworLenghtTB.Text);
            int passwordsCount = int.Parse(passwordsCountTB.Text);
            PasswordsLb.ItemsSource = _passwordGeneratorService.Start(lenght, passwordsCount);

            if (int.Parse(passwordsCountTB.Text) < 6)
            {
                GuardPasswordTB.Text = "Ненадежный";

            }
            else
            {
                bool[] passwordGeneratorService = { NumbersCb.IsChecked.Value, SymbolCb.IsChecked.Value, LowerCb.IsChecked.Value, UpperCb.IsChecked.Value, WordsCb.IsChecked.Value };
                foreach (bool guard in passwordGeneratorService)
                {
                    if (passwordGeneratorService[1])
                    {
                        GuardPasswordTB.Text = "Надежный";
                    }
                }
            }
        }
    }
}
