using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using type_lds = System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>>;
using type_llds = System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>>>;
using type_dllds = System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>>>>;

using type_llls = System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<string>>>;
using type_lls = System.Collections.Generic.List<System.Collections.Generic.List<string>>;


namespace Wsy_webApiSystem
{



    public class WindowElementHelper
    {
        /// <summary>
        /// 设置控件元素属性值
        /// </summary>
        /// <param name="element"></param>
        /// 控件属性名称对应的类
        /// <param name="dep"></param>
        /// 值
        /// <param name="ov"></param>
        public static void setWindowPV(UIElement element, DependencyProperty dep, object ov)
        {
            element.SetValue(dep, ov);
        }

        /// <summary>
        /// 获取grid下所有控件，并根据对应的属性名,依据字典,批量设置控件另一属性的值
        /// </summary>
        /// <param name="gd"></param>
        /// <param name="LastStr"></param>
        /// <param name="KeyDep"></param>
        /// <param name="ValueDep"></param>
        /// <param name="ds"></param>
        public static void setWindowGdElementPvs(Grid gd, string FStr, DependencyProperty KeyDep, DependencyProperty ValueDep, Dictionary<string, string> ds)
        {
            try
            {
                UIElementCollection Childrens = gd.Children;
                System.Collections.IEnumerator ie = Childrens.GetEnumerator();
                foreach (UIElement element in gd.Children)
                {

                    string ename = element.GetValue(KeyDep).ToString();
                    // 这里KeyDep 传入的是 TextBox的nameDep 但是也能解析 Combox.Name . getvalue/setvalue方法会根据控件元素类型 自适应
                    int s = -2;
                    int s2 = ename.IndexOf('_');
                    string f = "";
                    if (s2 > -1)
                    {
                        f = ename.Substring(0, s2);
                    }
                    if (!string.IsNullOrEmpty(FStr))
                    {
                        if (f != FStr)
                        {
                            continue;
                        }
                    }
                    s = ename.IndexOf("_b_");
                    if (s > -1)
                    {
                        ename = ename.Substring(s + 3, ename.Length - (s + 3));
                    }

                    if (f.Equals("cmb") && s > -1)
                    {
                        object os = element.GetValue(ComboBox.ItemsSourceProperty);
                        try
                        {
                            string[] aws = os as string[];
                            for (int i = 0; i < aws.Length; i++)
                            {
                                if (aws[i] == ds[ename])
                                {
                                    element.SetValue(ComboBox.SelectedIndexProperty, i);
                                    continue;
                                }
                            }


                        }
                        catch { }
                        continue;


                    }


                    if (f.Equals("chk") && s > -1)
                    {
                        try
                        {
                            bool cs = false;
                            if (ds[ename] == "是" || ds[ename] == "true" || ds[ename] == "True" || ds[ename] == "TRUE" || ds[ename] == "yes" || ds[ename] == "ok")
                            {
                                cs = true;

                            }
                            else
                            {
                                cs = false;

                            }
                            element.SetValue(CheckBox.IsCheckedProperty, cs);

                        }
                        catch
                        {

                        }
                        continue;



                    }



                    if (s > -1)
                    {
                        // ename = ename.Substring(s + 3, ename.Length - (s + 3));
                        try
                        {
                            element.SetValue(ValueDep, ds[ename]);
                        }
                        catch
                        {
                            //字典和控件不对应
                        }
                    }




                }
            }
            catch { }
        }



        /// <summary>
        /// 批量设置grid控件包涵的txt控件的值
        /// </summary>
        /// <param name="gd"></param>
        /// <param name="ds"></param>
        public static void setWindowGdElementPvs(Grid gd, Dictionary<string, string> ds)
        {
            setWindowGdElementPvs(gd, null, TextBox.NameProperty, TextBox.TextProperty, ds);

        }

        /// <summary>
        /// 获取grid包涵的控件,并根据对应的属性,获取某个属性的值,并格式化成字典
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="gd"></param>
        /// <param name="FStr"></param>
        /// <param name="KeyDep"></param>
        /// <param name="ValueDep"></param>
        /// <returns></returns>
        public static Dictionary<string, string> getWindowGdElementPvs(Grid gd, string FStr, DependencyProperty KeyDep, DependencyProperty ValueDep)
        {
            Dictionary<string, string> ds = new Dictionary<string, string>();
            try
            {
                UIElementCollection Childrens = gd.Children;
                System.Collections.IEnumerator ie = Childrens.GetEnumerator();
                foreach (UIElement element in gd.Children)
                {


                    string ename = element.GetValue(KeyDep).ToString();
                    //
                    int s = -2;

                    int s2 = ename.IndexOf('_');
                    string f = "";
                    if (s2 > -1)
                    {
                        f = ename.Substring(0, s2);
                    }
                    if (!string.IsNullOrEmpty(FStr))
                    {
                        s = ename.IndexOf(FStr);
                        if (s < 0)
                        {
                            continue;
                        }
                    }

                    s = ename.IndexOf("_b_");
                    if (s > -1)
                    {
                        ename = ename.Substring(s + 3, ename.Length - (s + 3));
                    }

                    if (f.Equals("cmb") && s > -1)
                    {
                        try
                        {
                            ds[ename] = element.GetValue(ComboBox.TextProperty).ToString();
                        }
                        catch { }
                        continue;
                    }
                    if (f.Equals("chk") && s > -1)
                    {
                        try
                        {

                            object ob = element.GetValue(CheckBox.IsCheckedProperty);
                            bool b = Convert.ToBoolean(ob);
                            if (b)
                            {
                                ds[ename] = "是";
                            }
                            else
                            {
                                ds[ename] = "否";
                            }

                        }
                        catch
                        {
                            // 
                        }
                        continue;
                    }


                    if (s > -1)
                    {


                        ds[ename] = element.GetValue(ValueDep).ToString();
                    }

                }

            }
            catch { }
            return ds;
        }


        /// <summary>
        /// 获取grid控件包涵的txt控件的值并格式化成对应的model
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="gd"></param>
        public static Dictionary<string, string> getWindowGdElementPvs(Grid gd)
        {

            return getWindowGdElementPvs(gd, null, TextBox.NameProperty, TextBox.TextProperty);


        }


        /// <summary>
        /// 获取grid控件包涵的txt控件的值并格式化成字典
        /// </summary>
        /// <param name="gd"></param>
        /// <returns></returns>
        public static Dictionary<string, string> getWindowGdTextElementPvs(Grid gd)
        {

            return getWindowGdElementPvs(gd, "txt", TextBox.NameProperty, TextBox.TextProperty);


        }

    }
}
