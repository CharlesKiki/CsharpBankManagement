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
    public partial class RyglbWinsow : Window
    {
        public RyglbWinsow()
        {
            InitializeComponent();
            this.Gd1.MouseDown += Gd1_MouseDown;
            this.ShowDialog();          

        }

        private BankManagementDatabaseEntities context = new BankManagementDatabaseEntities();
        //声明数据库上下文

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
            RyglTable rt = new RyglTable();
        }
        private void dg_Loaded(object sender, RoutedEventArgs e)
        {
           // List<hk_info> ld = new List<hk_info>();
           // ld.Add(dk);
            //dg.ItemsSource = ld;
        }
        private void Gd1_Loaded(object sender, RoutedEventArgs e)
        {
            string[] fl = { "真实姓名","电话号码","所属分店" ,"职位"};
            cmbState.ItemsSource = fl;
            //combox下拉菜单内容
            cmbState.SelectedIndex = 0;
        }
        //更新按钮
        private void btnUpData_Click(object sender, RoutedEventArgs e)
        {
            //修改某个员工的信息表格
            RyglTable rt = new RyglTable("更新", true);
            //重新刷新当前的DataGrid
        }
        //增加新员工
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //打开新的表，增加员工的逻辑在表中
            RyglTable rt = new RyglTable("添加", true);
            //连接数据库，刷新当前的表格
            
        }


    }

}
