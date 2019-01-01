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
//数据库缺失

    //分店管理逻辑
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
            //初始化控件
            this.Gd1.MouseDown += Gd1_MouseDown;
            //鼠标拖动事件
            this.ShowDialog();          
            //显示界面
        }
        //当窗口被鼠标按下的事件
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
        //实际上这是一个新的窗口，当前的窗口是显示信息的业务逻辑
        private void btnTxkhzl_Click(object sender, RoutedEventArgs e)
        {
            FdglTable rt = new FdglTable();
        }
        private void dg_Loaded(object sender, RoutedEventArgs e)
        {
            //数据库缺失
           // List<hk_info> ld = new List<hk_info>();
           // ld.Add(dk);
            //dg.ItemsSource = ld;
        }
        private void Gd1_Loaded(object sender, RoutedEventArgs e)
        {

        }
        //更新按钮，这回导致一个新的界面弹出，
        //该界面应该从数据库加载当前某用户的信息
        private void btnUpData_Click(object sender, RoutedEventArgs e)
        {
            FdglTable rt = new FdglTable("更新", true);
        }

        //添加新的信息，这会导致一个新的空申请表
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            FdglTable rt = new FdglTable("添加", true);
        }


    }

}
