using Shop_Management.ThirdCtrl;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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

namespace Shop_Management.SecondCtrl
{
    /// <summary>
    /// XycxWindowxaml.xaml 的交互逻辑
    /// </summary>
    public partial class FdglWinsow : Window
    {
        public FdglWinsow()
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
        private void btnTxkhzl_Click(object sender, RoutedEventArgs e)
        {
            FdglTable rt = new FdglTable();
        }
        private void dg_Loaded(object sender, RoutedEventArgs e)
        {
            List<hk_info> ld = new List<hk_info>();
           // ld.Add(dk);
            dg.ItemsSource = ld;
        }
        private void Gd1_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpData_Click(object sender, RoutedEventArgs e)
        {
            FdglTable rt = new FdglTable("更新", true);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            FdglTable rt = new FdglTable("添加", true);
        }


    }

}
