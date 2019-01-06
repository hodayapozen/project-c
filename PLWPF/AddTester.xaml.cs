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
    /// Interaction logic for AddTester.xaml
    /// </summary>
    public partial class AddTester : Window
    {
        BL.IBL bl;
        BE.Tester tester;
        private List<string> errorMessages;
        public AddTester()
        {
          
            InitializeComponent();
            tester = new BE.Tester();
            this.AddTesterGrid.DataContext = tester;
            bl = BL.Factory_BL.GetBL();
            errorMessages = new List<string>();
            birthdayDatePicker.DisplayDateEnd = DateTime.Now.AddYears(BE.Configuration.MinAgeTester);


            this.CarType.ItemsSource = Enum.GetValues(typeof(BE.EnumClass.CarType));
            this.gender.ItemsSource = Enum.GetValues(typeof(BE.EnumClass.Gender));
            this.GearboxType.ItemsSource = Enum.GetValues(typeof(BE.EnumClass.GearboxType));
          
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource testerViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("testerViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // testerViewSource.Source = [generic data source]
        }

        private void GearboxType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void SundayStart_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SundayFinish_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void MondayFinish_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {
        
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.AddTester(tester);
                this.Close();
                new TesterAddSuccess().ShowDialog();
              //  new TesterActions(tester).ShowDialog();
               
                //tester = new BE.Tester();
                //this.AddTesterGrid.DataContext = tester;

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void tb_ID_TextChanged(object sender, TextChangedEventArgs e)
        {
         
        }

        private void lastnameu_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void gender_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void MondayStart_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {

        }

        private void GearboxType_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
