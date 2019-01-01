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

//贷款审核记录
namespace Shop_Management.SecondCtrl
{
    /// <summary>
    /// XycxWindowxaml.xaml 的交互逻辑
    /// </summary>
    public partial class DkshjlWinsow : Window
    {
        public DkshjlWinsow()
        {
            InitializeComponent();
            this.Gd1.MouseDown += Gd1_MouseDown;
            //绑定树表按下事件
            this.ShowDialog();      
            //初始化之后显示该界面

        }

        void Gd1_MouseDown(object sender, MouseButtonEventArgs e)
        //当执行该事件之后，执行拖动
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
            //关闭按钮事件
            this.Close();
        }
        private void btnmin_Click(object sender, RoutedEventArgs e)
        {
            //最小化
            this.WindowState = WindowState.Minimized;
        }

        private void btnTxkhzl_Click(object sender, RoutedEventArgs e)
        {
            //打开贷款审核窗口
            DkshTable dt = new DkshTable();
        }

        //加载所有的贷款申请
        //根据当前的分店的情况分别的显示贷款情况
        private void dg_Loaded(object sender, RoutedEventArgs e)
        {
            //在列表中增加贷款审核的item
           // List<dk_sh_log> ld = new List<dk_sh_log>();
           // ld.Add(dk);
            //dg.ItemsSource = ld;
        }


    }

}
