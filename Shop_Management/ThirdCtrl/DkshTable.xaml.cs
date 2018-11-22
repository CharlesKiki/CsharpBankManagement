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
    public partial class DkshTable : Window
    {
        public DkshTable()
        {
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

        private void Gd1_Loaded(object sender, RoutedEventArgs e)
        {
            string[] opi = { "同意", "拒绝" };
            cmb_b_gender.ItemsSource = opi;
            cmb_b_gender.SelectedIndex = 0;

        }

        private void btnTj_Click(object sender, RoutedEventArgs e)
        {
            
        }



    }
}
