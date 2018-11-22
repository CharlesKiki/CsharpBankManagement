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

namespace Shop_Management.ThirdCtrl
{
    /// <summary>
    /// KhWindow.xaml 的交互逻辑
    /// </summary>
    public partial class KhxqTable : Window
    {
        public KhxqTable()
        {
            InitializeComponent();
            this.Gr1.MouseDown += gdTitle_MouseDown;
            this.ShowDialog();
        }
        string[] Fdsz = { };
        public KhxqTable(string [] fdsz)
        {
            InitializeComponent();
            this.Gr1.MouseDown += gdTitle_MouseDown;
            this.ShowDialog();
            Fdsz = fdsz;
        }
        bool BtNsh=false;
        public KhxqTable(bool BtnSh)
        {
            BtNsh = BtnSh;
            InitializeComponent();
            this.Gr1.MouseDown += gdTitle_MouseDown;
            this.ShowDialog();
            

        }
        /// <summary>
        ///  拖动窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void gdTitle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                this.DragMove();
            }
            catch
            {
            }

        }
        /// <summary>
        /// 关闭窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbnclose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 最小化窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnmin_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnFfsqdkb_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            DksqbTable dw = new DksqbTable();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string[] gender = {"男","女"};
            cmb_b_z2_gender.ItemsSource = cmb_b_z1_gender.ItemsSource = cmb_b_gender.ItemsSource = gender;
            cmb_b_z2_gender.SelectedIndex = cmb_b_z1_gender.SelectedIndex = cmb_b_gender.SelectedIndex = 0;
            if (Fdsz.Length > 0)
            {
                cmb_b_ofd.ItemsSource = cmb_b_zjr_ofd.ItemsSource = Fdsz;
                cmb_b_ofd.SelectedIndex = cmb_b_zjr_ofd.SelectedIndex = 0;
            }
            if(BtNsh)
            {
                btnUpdata.Visibility = Visibility.Collapsed;
                btnSave.Visibility = Visibility.Collapsed;
                btnFfsqdkb.Visibility = Visibility.Collapsed;
                btnClear.Visibility = Visibility.Collapsed;
                btnSh.Visibility = Visibility.Visible;
            
            }
        }

        private void btnSh_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            DkshTable dw = new DkshTable();
        }


    }
}
