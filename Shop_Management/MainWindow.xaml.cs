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
using System.Windows.Threading;
using Shop_Management.Controls;

namespace Shop_Management
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            btnmax_Click(null,null);
            this.Gr1.MouseDown += gdTitle_MouseDown;
        }
        /// <summary>
        ///  拖动窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void gdTitle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                this.DragMove();
            }
            catch 
            { }

        }
        /// <summary>
        /// 关闭窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbnclose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 最大化窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        bool btnmaxbool = true;
        private void btnmax_Click(object sender, RoutedEventArgs e)
        {
            if (btnmaxbool)
                //最大化窗口
            {
                this.WindowState = WindowState.Maximized;
                //窗口状态，最大化
                Style sty = (Style)this.FindResource("RestoreButtonStyle");
                btnMax.Style = sty;
                btnmaxbool = false;

            }
            else
            {
                this.WindowState = WindowState.Normal;
                Style sty = (Style)this.FindResource("MaxButtonStyle");
                //？
                btnMax.Style = sty;
                btnmaxbool = true;
            }
            
        }
        /// <summary>
        /// 最小化窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnmin_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }


    }
}
