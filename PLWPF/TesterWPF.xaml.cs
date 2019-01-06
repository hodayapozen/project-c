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
    /// Interaction logic for TesterWPF.xaml
    /// </summary>
    public partial class TesterWPF : Window
    {
       BL.IBL bl;
       BE.Tester tester;

        public TesterWPF()
        {
            InitializeComponent();
            tester = new BE.Tester();
            bl = BL.Factory_BL.GetBL();
            this.DataContext = tester;
        }

        private void pb_next_Click(object sender, RoutedEventArgs e)
        {
         //   Tester t = new Tester("025395633", "Chen", "Tamar", new DateTime(1966, 4, 10), EnumClass.Gender.male, "055678945", 15, 10, EnumClass.CarType.Private, EnumClass.GearboxType.Manual, 100);

          //  bl.AddTester(t);
            BE.Tester tester = new BE.Tester();
            tester = bl.GetTester(this.tb_idLogin.Text);
           TesterActions testerAct= new TesterActions(tester);
            testerAct.ShowDialog();

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void tb_idLogin_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void pb_new_Click(object sender, RoutedEventArgs e)
        {
           new AddTester().ShowDialog();
        }
    }
}
