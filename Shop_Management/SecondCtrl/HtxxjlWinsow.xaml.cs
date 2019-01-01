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


    /*
     业务逻辑：
     检查借款事件表中所有的有还款时间的记录
     */
namespace Shop_Management.SecondCtrl
{
    /// <summary>
    /// XycxWindowxaml.xaml 的交互逻辑
    /// </summary>
    public partial class HtxxjlWinsow : Window
    {
        public HtxxjlWinsow()
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

        //关闭事件
        private void tbnclose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //最小化窗体
        private void btnmin_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        //增加还款记录
        private void btnTxkhzl_Click(object sender, RoutedEventArgs e)
        {
            HtxxTable ht = new HtxxTable();
        }

        //加载还款记录
        private void dg_Loaded(object sender, RoutedEventArgs e)
        {
           // List<dk_sh_log> ld = new List<dk_sh_log>();
           // ld.Add(dk);
           // dg.ItemsSource = ld;
        }


    }

}
