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
        private BankManagementDatabaseEntities context = new BankManagementDatabaseEntities();
        //声明数据库上下文
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string Username = tbUse.Text;
            string Password = pbPwd.Password;
            bool LoginCheck = false;
            //连接数据库
            //业务逻辑解释：用户名唯一，若存在且密码正确，通过
            //用户名不存在，密码错误，错误

            var query = from t in context.LoginInfo
                        where t.Bno == this.tbUse.Text && t.Password == this.pbPwd.Password
                        select t;
            if (query.Count() > 0)
            {
                var q = query.First();
                LoginCheck = true;
            }
            else
            {
                MessageBox.Show("登录失败！");
                this.pbPwd.Clear();
                this.tbUse.Focus();
            }

            if (LoginCheck == true)
            {
                this.Visibility = Visibility.Hidden;
            }
            //此处并没有实际的验证登陆的效果，实际上就是隐藏了登陆页面。
        }

        private void cbxSafePwd_Checked(object sender, RoutedEventArgs e)
        {
            //分店选择功能
            //该功能尚未实现
        }
    }
}
