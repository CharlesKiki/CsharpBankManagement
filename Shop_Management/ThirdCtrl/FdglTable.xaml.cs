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
    /// XycxWindowxaml.xaml 的交互逻辑
    /// </summary>
    public partial class FdglTable : Window
    {
        public FdglTable()
        {
            InitializeComponent();
            this.Gd1.MouseDown += Gd1_MouseDown;
            this.ShowDialog();
        }
        bool Btnok = false;
        string uid = "";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Uid">设为更新或添加</param>
        /// <param name="btnOK">把按钮更改为确认</param>
        public FdglTable(string Uid, bool btnOK)
        {
            Btnok = btnOK;
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
            switch (btnClose.Uid)
            {

                case "更新":/****操作事件*****/break;
                case "添加":/****操作事件*****/break;
                default:
                    break;
            }
            this.Close();
           
        }

        private void Gd1_Loaded(object sender, RoutedEventArgs e)
        {
            if (Btnok)
            {
                btnClose.Uid = uid;
                btnClose.Content = "确定";
            }
        }

    }
}
