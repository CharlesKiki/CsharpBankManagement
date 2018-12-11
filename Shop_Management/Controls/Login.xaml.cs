﻿using System;
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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Shop_Management.Controls
{
    /// <summary>
    /// Login.xaml 的交互逻辑
    /// </summary>
    public partial class Login : UserControl
    {
        public Login()
        {
            InitializeComponent();
            
        }
 
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            //此处并没有实际的验证登陆的效果，实际上就是隐藏了登陆页面。
        }

        private void cbxSafePwd_Checked(object sender, RoutedEventArgs e)
        {

        }



    }
}