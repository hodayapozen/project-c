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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BE;
using BL;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();
          
            //int[] days = { 1, 3 };
            //bool[,] testerWorkHours = Configuration.MatrixInitialization(10, 15, days);
            //Tester tester2 = new Tester("025395633", "Chen", "Tamar", new DateTime(1966, 4, 10), EnumClass.Gender.male, "055678945", 15, 10, EnumClass.CarType.Private, EnumClass.GearboxType.Manual, 100);
            //bl.AddTester(tester2);
        }

        private void pb_trainee_Click(object sender, RoutedEventArgs e)
        {
           
              //  new TraineeWPF().ShowDialog();
            
        }

        private void Pb_tester_Click(object sender, RoutedEventArgs e)
        {
            TesterWPF testerWPF = new TesterWPF();
            testerWPF.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new LinqWPF().ShowDialog();
        }
    }
}
