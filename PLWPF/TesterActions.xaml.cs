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
    /// Interaction logic for TesterActions.xaml
    /// </summary>
    public partial class TesterActions : Window
    {
        BL.IBL bl;
        BE.Tester tester;


        public TesterActions()
        {
            InitializeComponent();
            tester = new BE.Tester();
            bl = BL.Factory_BL.GetBL();
        }
        public TesterActions(BE.Tester t)
        {

            InitializeComponent();
            tester = new BE.Tester(t);
            bl = BL.Factory_BL.GetBL();


        }

        private void pb_testerDELETE_Click(object sender, RoutedEventArgs e)
        {
           bl.DeleteTester(tester.TesterId);
            new TesterDeleteSuccess().ShowDialog();
            this.Close();
            
        }

        private void pb_Testupdat_Click(object sender, RoutedEventArgs e)
        {
            new TesterUpdate(tester).ShowDialog();
        }
    }
}
