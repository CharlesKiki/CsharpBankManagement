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
    public struct FangkuanjiluList
    {
        public string name { get; set; }
        public string idcardnumber { get; set; }
        public string date { get; set; }
        public string commit { get; set; }

    }

    /// <summary>
    /// XycxWindowxaml.xaml 的交互逻辑
    /// </summary>
    public partial class FkjllWinsow : Window
    {
        //声明数据库上下文
        private BankManagementDatabaseEntities databasecontext = new BankManagementDatabaseEntities();
        //初始化
        public FkjllWinsow()
        {
            InitializeComponent();
            this.Gd1.MouseDown += Gd1_MouseDown;
            this.ShowDialog();          

        }
        //鼠标拖动事件
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
        //关闭按钮
        private void tbnclose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        //最小化按钮
        private void btnmin_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        //业务逻辑加载，显示放宽记录
        private void dg_Loaded(object sender, RoutedEventArgs e)
        {
            List<FangkuanjiluList> infolist = new List<FangkuanjiluList>();
            FangkuanjiluList List = new FangkuanjiluList();

            //从数据库添加指定的数据
            List.name = "111";
            List.idcardnumber = "456145199742614585";
            List.date = "12月21";
            List.commit = "初次贷款。";
            //这个功能还没有测试
            dg.ItemsSource = databasecontext.LoanApplication.ToList();

            infolist.Add(List);
            dg.AutoGenerateColumns = false;
            dg.ItemsSource = infolist;
        }


    }

}
