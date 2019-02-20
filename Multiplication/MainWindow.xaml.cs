using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Multiplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //varibles for calculate result
        int a,b,c;

        //varibles for set time refresh
        int time = 2000;

        public MainWindow()
        {
            InitializeComponent();

            // loop for calculate multiplication
            loop();
        }

        // loop for calculate and show result
        public async void loop(){
            while (true)
            {
                //code for set time refresh
                time = Int32.Parse(setTimeLabler.Text + "000");

                //code for calculate and show result
                try
                {
                    a = Int32.Parse(aTextBox.Text);
                    b = Int32.Parse(bTextBox.Text);
                    c = await calculate(a, b);
                    progressBar.Value = c;
                    resultLabel.Content = "= " + c.ToString();
                }
                catch (Exception e)
                {
                    MessageBox.Show("blad dzialanai programu");
                }
            }
        }     

        //button to set time refresh
        private void Apply_Click(object sender, RoutedEventArgs e)
        {
            time = Int32.Parse(setTimeLabler.Text+"000");
        }

        public async Task<int> calculate(int a, int b)
        {
            return await Task.Run(() =>
            {
                Thread.Sleep(time);
                return a*b;
            });
        }
    }
}
