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



namespace PLWPF
{
    /// <summary>
    /// Interaction logic for TesterUpdate.xaml
    /// </summary>
    public partial class TesterUpdate : Window
    {
        BE.Tester tester;
        BL.IBL bl;
        public TesterUpdate(BE.Tester t)
        {
            InitializeComponent();
            tester = new BE.Tester(t.GetCopy());
            bl = BL.Factory_BL.GetBL();
            this.TesterUpdateGrid.DataContext=tester;
            this.CarType.ItemsSource = Enum.GetValues(typeof(BE.EnumClass.CarType));
        

        }

        private void EnterNameu_TextChanged(object sender, TextChangedEventArgs e)
        {
           

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void c_phone_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void GearboxType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SundayStart_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
        {

        }

        private void WednesdayFinish_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.UpdateTester(tester);
                tester = new BE.Tester();
                this.TesterUpdateGrid.DataContext = tester;
                //refreshData();
                this.Close();
                new TesterUpdateSuccess().ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Close();
        }
       
    }
}
