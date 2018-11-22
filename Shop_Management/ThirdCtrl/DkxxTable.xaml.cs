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
    public partial class DkxxTable : Window
    {
        public DkxxTable()
        {
            InitializeComponent();
            this.Gd1.MouseDown += Gd1_MouseDown;
            this.ShowDialog();
        }
        bool Btnxq = false;
        dk_info DK;
        public DkxxTable(dk_info dk)
        {
            DK = dk;
            InitializeComponent();
            this.Gd1.MouseDown += Gd1_MouseDown;
            this.ShowDialog();
        }
        public DkxxTable(bool btnXq)
        {
            Btnxq = btnXq;
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
        private void btnCkxq_Click(object sender, RoutedEventArgs e)
        {

            this.Close();
            if (Btnxq)
            {
                KhxqTable KU = new KhxqTable(true);
            }
        }

        private void Gd1_Loaded(object sender, RoutedEventArgs e)
        {
            if (Btnxq)
            {
                btnTxkhzl.Content = "查看客户详情";
            }
            if (DK != null)
            {
                Dictionary<string, string> myd = sqlHelper.ConvertTToDsT(DK);
                WindowElementHelper.setWindowGdElementPvs(gddksq, myd);
            }
        }

      


    }
}
