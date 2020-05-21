using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace generatePesel
{
    public partial class WelcomeScreen : Window
    {
        public WelcomeScreen()
        {
            InitializeComponent();
        }

        private void Generate_Click(object sender, RoutedEventArgs e)
        {
            var generate = new MainWindow();
            generate.Show();
        }
        private void Validate_Click(object sender, RoutedEventArgs e)
        {
            var validate = new Validator();
            validate.Show();
        }

        private void Verify_Click(object sender, RoutedEventArgs e)
        {
            var verify = new Verifier();
            verify.Show();
        }
    }
}
