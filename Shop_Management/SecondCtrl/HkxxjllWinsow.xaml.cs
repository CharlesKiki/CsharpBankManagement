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
     业务逻辑说明：
     该功能的实现依赖一个借款表格，当借款人还款后会给借款表一个还款时间标记
     一次借款对一个用户来说是一个事件，还款也对应一个借款时间
     
     
     */
namespace Shop_Management.SecondCtrl
{
    /// <summary>
    /// XycxWindowxaml.xaml 的交互逻辑
    /// </summary>
    public partial class HkxxjllWinsow : Window
    {
        public HkxxjllWinsow()
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

        //最小化窗体逻辑
        private void btnmin_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        //增加新的短款申请表
        private void btnTxkhzl_Click(object sender, RoutedEventArgs e)
        {
            HkxxTable ht = new HkxxTable();
        }

        //从数据库加载那些人已经还款了
        //查到所有的带有还款时间的记录和对应借款人
        private void dg_Loaded(object sender, RoutedEventArgs e)
        {
            //List<hk_info> ld = new List<hk_info>();
           // ld.Add(dk);
            //dg.ItemsSource = ld;
        }


    }

}
