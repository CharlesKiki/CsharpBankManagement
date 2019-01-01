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
//这是一个数据库的模型，这需要重新编写数据库

    //贷款信息
namespace Shop_Management.SecondCtrl
{
    /// <summary>
    /// XycxWindowxaml.xaml 的交互逻辑
    /// </summary>
    public partial class DkxxWinsow : Window
    {
        public DkxxWinsow()
        {
            InitializeComponent();
            //初始化控件
            this.Gd1.MouseDown += Gd1_MouseDown;
            //鼠标事件
            this.ShowDialog();
            //显示窗口

        }
        //拖动事件
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
        //最小化事件
        private void btnmin_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        //贷款信息窗口，点击后会打开新的申请贷款界面
        private void btnTxkhzl_Click(object sender, RoutedEventArgs e)
        {

            //DkxxTable dt = new DkxxTable(dk);
        }

        //初始化了一个表信息，这是用来模拟数据库用的
            //dk_info dk = new dk_info
            //{
            //    dk_bkcard = "123456789123456789",
            //    dk_id = "0012",
            //    dk_lv = "0.05%",
            //    dk_md = "没钱吃饭",
            //    dk_remark = "12346",
            //    dk_stat = DateTime.Now.ToString(),
            //    dk_y = "2",
            //    dk_y_count = "15",
            //    dk_y_money = " ",
            //    dk_zmoney = "50",
            //    name = "李四",
            //    ofd = "总店",
            //    remark = "",
            //    sfz = "456798798131345646",
            //    zjr = "root",
            //    zjr_ofd = "总店"
            //};

        //加载函数，加载进入时的显示内容
        private void dg_Loaded(object sender, RoutedEventArgs e)
        {
            //初始化了一个表信息，增加到item内
            //List<dk_info> ld = new List<dk_info>();
            //ld.Add(dk);
            //dg.ItemsSource = ld;
        }


    }

}
