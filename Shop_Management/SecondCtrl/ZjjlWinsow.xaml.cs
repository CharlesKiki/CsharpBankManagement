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
//using Wsy_Model;

namespace Shop_Management.SecondCtrl
{
    /// <summary>
    /// XycxWindowxaml.xaml 的交互逻辑
    /// </summary>
    public partial class ZjjlWinsow : Window
    {
        public ZjjlWinsow()
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
            //money_info aa = (money_info)dg.SelectedValue;
            //if (aa == null) return;
            //if (aa.name == "张三")
            //{
            //    this.Close();
            //    ZjldTable zw = new ZjldTable(mi);
            //}
            //Dictionary<string, money_info> dc = new Dictionary<string, money_info>();
            //foreach (var item in dc)
            //{
            //    if (item.Value.name == aa.name)
            //    {
            //        ZjldWindow zw = new ZjldWindow(item.Value);
            //    }
            //}

        }

        private void dg_Loaded(object sender, RoutedEventArgs e)
        {

        }
        //数据库缺失
        //money_info mi = new money_info {  m_remark="123", sfz="156464949856213216",m_date = DateTime.Now.ToString(), m_fun = "放款", name = "张三" };

        //private void dg_Loaded(object sender, RoutedEventArgs e)
        //{
        //    List<money_info> aa = new List<money_info>();
        //    aa.Add(mi);
        //    dg.ItemsSource = aa;
        //}


    }
}
