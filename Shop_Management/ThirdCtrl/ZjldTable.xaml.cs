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
using Wsy_Model;
using Wsy_webApiSystem;





namespace Shop_Management.ThirdCtrl
{
    /// <summary>
    /// XycxWindowxaml.xaml 的交互逻辑
    /// </summary>
    public partial class ZjldTable : Window
    {
        
        public ZjldTable()
        {
            InitializeComponent();
            this.Gd1.MouseDown += Gd1_MouseDown;
            this.ShowDialog();
        }
        money_info Model;
        public ZjldTable( money_info mi)
        {
            Model = mi;
            InitializeComponent();
            this.Gd1.MouseDown += Gd1_MouseDown;
            this.ShowDialog();
        }

        void Gd1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                this.DragMove();
            }
            catch
            {
            }

        }
        private void tbnclose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btnmin_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void gdzjldxx_Loaded(object sender, RoutedEventArgs e)
        {
            string[] fun = { "放款", "收款" };
            cmb_b_m_fun.ItemsSource = fun;
            cmb_b_m_fun.SelectedIndex = 0;
        }

        private void Gd1_Loaded(object sender, RoutedEventArgs e)
        {
            Dictionary<string, string> myd = sqlHelper.ConvertTToDsT(Model);
            WindowElementHelper.setWindowGdElementPvs(gdzjldxx, myd);
        }


    }
}
