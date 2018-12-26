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

namespace Shop_Management.ThirdCtrl
{
    /// <summary>
    /// XycxWindowxaml.xaml 的交互逻辑
    /// </summary>
    public partial class DksqbTable : Window
    {
        //控件初始化
        public DksqbTable()
        {
            InitializeComponent();
            this.Gd1.MouseDown += Gd1_MouseDown;
            this.ShowDialog();
        }

        //声明数据库上下文
        private BankManagementDatabaseEntities databasecontext = new BankManagementDatabaseEntities();
        
        //拖动逻辑
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
        //关闭按钮逻辑
        private void tbnclose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        //最小化逻辑按钮
        private void btnmin_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        //关闭按钮
        private void btnTxkhzl_Click(object sender, RoutedEventArgs e)
        {
            //数据验证是否合适
            string CustomerName = txt_b_name.Text;
            string TransactionID = txt_b_name.Text;
                //实际上业务订单号应该不会重复
            string CustomerChineseID = txt_b_sfz.Text;
            string ReceiveMoneyAccount = txt_b_dk_bkcard.Text;
            string RepaymentWeek = txt_b_dk_y_money.Text;
            string CreditPurpose = txt_b_dk_md.Text;

            //写入数据库
            //LoanApplcation表实例化
            var LoanApplicationTable = new LoanApplication()
            {
                CustomerName = CustomerName,
                TransactionID = TransactionID,
                CustomerChineseID = CustomerChineseID,
                RepaymentWeek = RepaymentWeek,
                CreditPurpose = CreditPurpose
            };
            /*实际上这种命名方式极其不好，应该改正命名方式和数据库字段的名字不同*/
            databasecontext.LoanApplication.Add(LoanApplicationTable);
            databasecontext.SaveChanges();
            //this.Close();
        }

      


    }
}
