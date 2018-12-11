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
using Shop_Management.ThirdCtrl;
using Shop_Management.SecondCtrl;


namespace Shop_Management.Controls
{
    /// <summary>
    /// CustomerInfo.xaml 的交互逻辑
    /// </summary>
    public partial class CustomerInfo : UserControl
    {
        public CustomerInfo()
        {
            //Route似乎是某种重定向的概念
            InitializeComponent();
            #region 鼠标路由
            btndksh.AddHandler(Button.MouseEnterEvent, new RoutedEventHandler(ImageButton_MouseEnter), true);
            btndkxx.AddHandler(Button.MouseEnterEvent, new RoutedEventHandler(ImageButton_MouseEnter), true);
            btnfkjl.AddHandler(Button.MouseEnterEvent, new RoutedEventHandler(ImageButton_MouseEnter), true);
            btnhkxx.AddHandler(Button.MouseEnterEvent, new RoutedEventHandler(ImageButton_MouseEnter), true);
            btnhtxx.AddHandler(Button.MouseEnterEvent, new RoutedEventHandler(ImageButton_MouseEnter), true);
            btnkhzl.AddHandler(Button.MouseEnterEvent, new RoutedEventHandler(ImageButton_MouseEnter), true);
            btnyqjl.AddHandler(Button.MouseEnterEvent, new RoutedEventHandler(ImageButton_MouseEnter), true);

            btndksh.AddHandler(Button.MouseLeaveEvent, new RoutedEventHandler(ImageButton_MouseLeave), true);
            btndkxx.AddHandler(Button.MouseLeaveEvent, new RoutedEventHandler(ImageButton_MouseLeave), true);
            btnfkjl.AddHandler(Button.MouseLeaveEvent, new RoutedEventHandler(ImageButton_MouseLeave), true);
            btnhkxx.AddHandler(Button.MouseLeaveEvent, new RoutedEventHandler(ImageButton_MouseLeave), true);
            btnhtxx.AddHandler(Button.MouseLeaveEvent, new RoutedEventHandler(ImageButton_MouseLeave), true);
            btnkhzl.AddHandler(Button.MouseLeaveEvent, new RoutedEventHandler(ImageButton_MouseLeave), true);
            btnyqjl.AddHandler(Button.MouseLeaveEvent, new RoutedEventHandler(ImageButton_MouseLeave), true);
            #endregion
        }

        private void ImageButton_MouseLeave(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            //事件
            btn.Opacity = 1;
        }

        private void ImageButton_MouseEnter(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            btn.Opacity=0.7;
        }
       
        private void btnkhzl_Click(object sender, RoutedEventArgs e)
        {
            KhxqTable ku = new KhxqTable();
         
        }

        private void btndkxx_Click(object sender, RoutedEventArgs e)
        {
            DkxxWinsow dxx = new DkxxWinsow();
        }

        private void btndksh_Click(object sender, RoutedEventArgs e)
        {
            DkshjlWinsow dw = new DkshjlWinsow();
        }

        private void btnhtxx_Click(object sender, RoutedEventArgs e)
        {
            HtxxjlWinsow hw = new HtxxjlWinsow();
        }

        private void btnhkxx_Click(object sender, RoutedEventArgs e)
        {
            HkxxjllWinsow hk = new HkxxjllWinsow();
        }

        private void btnyqjl_Click(object sender, RoutedEventArgs e)
        {
            YqjlWinsow yq = new YqjlWinsow();
        }

        private void btnfkjl_Click(object sender, RoutedEventArgs e)
        {
            FkjllWinsow fk = new FkjllWinsow();
            //打开新窗口
        }

    }
}
