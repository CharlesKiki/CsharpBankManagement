using Shop_Management.SecondCtrl;
using Shop_Management.ThirdCtrl;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Shop_Management.Controls
{
    /// <summary>
    /// UcMain.xaml 的交互逻辑
    /// </summary>
    public partial class Main : UserControl
    {
        CustomerInfo Customer;
        string token = "";
        public Main()
        {
            InitializeComponent();
            Customer = new CustomerInfo();
            Customer.Visibility = Visibility.Collapsed;
            Gr2.Children.Add(Customer);


            #region 鼠标路由
            btndksq.AddHandler(Button.MouseEnterEvent, new RoutedEventHandler (ImageButton_MouseEnter), true);
            btndbsx.AddHandler(Button.MouseEnterEvent, new RoutedEventHandler(ImageButton_MouseEnter), true);
            btnkuzl.AddHandler(Button.MouseEnterEvent, new RoutedEventHandler(ImageButton_MouseEnter), true);
            btnrygl.AddHandler(Button.MouseEnterEvent, new RoutedEventHandler(ImageButton_MouseEnter), true);
            btnxtgl.AddHandler(Button.MouseEnterEvent, new RoutedEventHandler(ImageButton_MouseEnter), true);
            btnxycx.AddHandler(Button.MouseEnterEvent, new RoutedEventHandler(ImageButton_MouseEnter), true);
            btnzjjl.AddHandler(Button.MouseEnterEvent, new RoutedEventHandler(ImageButton_MouseEnter), true);

            btndksq.AddHandler(Button.MouseLeaveEvent, new RoutedEventHandler(ImageButton_MouseLeave), true);
            btndbsx.AddHandler(Button.MouseLeaveEvent, new RoutedEventHandler(ImageButton_MouseLeave), true);
            btnkuzl.AddHandler(Button.MouseLeaveEvent, new RoutedEventHandler(ImageButton_MouseLeave), true);
            btnrygl.AddHandler(Button.MouseLeaveEvent, new RoutedEventHandler(ImageButton_MouseLeave), true);
            btnxtgl.AddHandler(Button.MouseLeaveEvent, new RoutedEventHandler(ImageButton_MouseLeave), true);
            btnxycx.AddHandler(Button.MouseLeaveEvent, new RoutedEventHandler(ImageButton_MouseLeave), true);
            btnzjjl.AddHandler(Button.MouseLeaveEvent, new RoutedEventHandler(ImageButton_MouseLeave), true);
            #endregion
        }

        private void ImageButton_MouseEnter(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            btn.Opacity = 0.7;
        }

        private void ImageButton_MouseLeave(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            btn.Opacity = 1;
        }

        private void btnkuzl_Click(object sender, RoutedEventArgs e)
        {
            lblmain.Content = "返回主页";
            lblmain.Uid = "Customer";
            Customer.Visibility = Visibility.Visible;

        }

        private void lblmain_MouseDown(object sender, MouseButtonEventArgs e)
        {
            switch (lblmain.Uid.ToString())
            {
                case "Customer": Customer.Visibility = Visibility.Collapsed; lblmain.Content = "主页"; break;
                default:
                    break;
            }
        }

        private void btndksq_Click(object sender, RoutedEventArgs e)
        {
            bool btn1 = false, btn2 = false;
            NewMessagebox dksq = new NewMessagebox("是否老用户？", ref btn1, ref btn2);
            if (btn1) { KhxqTable kh = new KhxqTable();}
            if (btn2) { XycxWindowxaml xw = new XycxWindowxaml(); }

        }

        private void btnxtgl_Click(object sender, RoutedEventArgs e)
        {
            FdglWinsow fw = new FdglWinsow();
        }

        private void btnxycx_Click(object sender, RoutedEventArgs e)
        {
            XycxWindowxaml xw = new XycxWindowxaml();
           
        }

        private void btndbsx_Click(object sender, RoutedEventArgs e)
        {
            DbsxWinsow tg = new DbsxWinsow ();
        }

        private void btnzjjl_Click(object sender, RoutedEventArgs e)
        {
            ZjjlWinsow zw = new ZjjlWinsow();
        }

        private void btnrygl_Click(object sender, RoutedEventArgs e)
        {
            RyglbWinsow rw = new RyglbWinsow();
        }


    }
}
