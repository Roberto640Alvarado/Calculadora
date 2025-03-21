using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CalculadoraMatematica.Controllers;

namespace CalculadoraMatematica
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void BtnCalcular_Click(object sender, RoutedEventArgs e)
        {
            string expresion = txtExprMath.Text;
            string resultado = await CalculadoraController.Calcular(expresion);
            txtResult.Text = resultado;
        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}