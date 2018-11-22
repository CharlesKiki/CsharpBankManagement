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
using System.Windows.Shapes;

namespace Shop_Management.SecondCtrl
{
    /// <summary>
    /// DksqxwWindow.xaml 的交互逻辑
    /// </summary>
    public partial class NewMessagebox : Window
    {
        public NewMessagebox(string Text)
        {
            ShowMessage = Text;
            InitializeComponent();
            this.Gd1.MouseDown += Gd1_MouseDown;
            this.ShowDialog();
        }
        string ShowMessage = "";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Text">显示文本内容</param>
        /// <param name="btn1IsDown">判断按钮1是否按下</param>
        /// <param name="btn2IsDown">判断按钮2是否按下</param>
        public NewMessagebox(string Text, ref bool btn1IsDown, ref bool btn2IsDown)
        {
            InitializeComponent();
            ShowMessage = Text;
            this.Gd1.MouseDown += Gd1_MouseDown;
            this.ShowDialog();
            btn1IsDown = btnYes.IsMouseOver;
            btn2IsDown = btnNo.IsMouseOver;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Text">要显示的内容</param>
        /// <param name="BtnOK">一个启用确定按钮</param>
        bool btnOk = false;
        public NewMessagebox(string Text, bool BtnOK)
        {
            btnOk = BtnOK;
            InitializeComponent();
            ShowMessage = Text;
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
        private void btnYes_Click(object sender, RoutedEventArgs e)
        {
            tbnclose_Click(null,null);
        }
        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            tbnclose_Click(null, null);
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (btnOk)
            {
                btnOK.Visibility = Visibility.Visible;
                btnNo.Visibility = Visibility.Collapsed;
                btnYes.Visibility = Visibility.Collapsed;
            }
            lbltext.Content = ShowMessage;
        }
    }
}
