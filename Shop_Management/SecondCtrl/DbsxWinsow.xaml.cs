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

namespace Shop_Management.SecondCtrl
{
    /// <summary>
    /// XycxWindowxaml.xaml 的交互逻辑
    /// </summary>
    public partial class DbsxWinsow : Window
    {
        public DbsxWinsow()
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

            test aa = (test)dg.SelectedValue;
            if (aa == null) return;
            if (aa.dbsx == "放款")
            {
                DkxxTable dw = new DkxxTable(true);
            }
            else if (aa.dbsx == "催收")
            {
                NewMessagebox nm = new NewMessagebox("张三以欠款一天，请催收", true);
            }


        }

        private void dg_Loaded(object sender, RoutedEventArgs e)
        {
            List<test> aa = new List<test>();
            test ss = new test { dbsx = "放款", jd = "bb", sj = DateTime.Now.ToString(), xgry = "dd" };
            test sa = new test { dbsx = "催收", jd = "预期1天", sj = DateTime.Now.ToString(), xgry = "张三" };
            aa.Add(ss);
            aa.Add(sa);
            dg.ItemsSource = aa;
        }
        public class test
        {
            public string dbsx { get; set; }
            public string xgry { get; set; }
            public string jd { get; set; }
            public string sj { get; set; }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }

}
