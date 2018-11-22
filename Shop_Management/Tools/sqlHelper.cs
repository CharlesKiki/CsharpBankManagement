using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Text;
using System.Configuration;
using System.Reflection;

using type_lds = System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>>;
using type_llds = System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>>>;
using type_dllds = System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>>>>;

using type_llls = System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<string>>>;
using type_lls = System.Collections.Generic.List<System.Collections.Generic.List<string>>;



namespace Wsy_webApiSystem
{
    public class sqlHelper
    {


        /// <summary>
        ///  泛型根据dataModel 生成select语句
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string makeSelectSqlCommandT<T>(T t, bool isNon)
        {
            return makeSelectSqlCommand(t, false);
            // 2018 1 26 检测到无法访问代码？？
            PropertyInfo[] ps = t.GetType().GetProperties();
            Type ts = t.GetType();
            string resu = "select * from " + ts.Name;
            if (t != null)
            {
                resu += "  where  ";
            }
            foreach (System.Reflection.PropertyInfo p in ps)
            {
                if ((!Convert.ToString(p.GetValue(t)).Equals("")) && (!Convert.ToString(p.GetValue(t)).Equals(null)))
                {

                    if (p.GetValue(t).ToString().IndexOf('\'') >= 0)
                    {
                        resu = "safe check fail";
                    }
                    if (!isNon)
                    {
                        resu += p.Name + " = \'" + p.GetValue(t) + "\' and  ";
                    }
                    else
                    {
                        resu += p.Name + " != \'" + p.GetValue(t) + "\' and  ";
                    }
                }
            }
            resu = resu.Trim();
            int l = resu.LastIndexOf("and");

            if (l > 0 && resu.Length - 3 == l)
            {
                resu = resu.Trim().Remove(l);
            }
            l = resu.LastIndexOf("where");

            if (l > 0 && resu.Length - 5 == l)
            {
                resu = resu.Trim().Remove(l);
            }
            return resu;
        }

        public static string makeSelectSqlCommand(object t, bool isNon)
        {
            System.Reflection.PropertyInfo[] ps = t.GetType().GetProperties();
            Type ts = t.GetType();
            string resu = "select * from " + ts.Name;
            if (t != null)
            {
                resu += "  where  ";
            }
            foreach (System.Reflection.PropertyInfo p in ps)
            {
                if ((!Convert.ToString(p.GetValue(t)).Equals("")) && (!Convert.ToString(p.GetValue(t)).Equals(null)))
                {
                    if (p.GetValue(t).ToString().IndexOf('\'') >= 0)
                    {
                        resu = "safe check fail";
                    }
                    if (!isNon)
                    {
                        resu += p.Name + " = \'" + p.GetValue(t) + "\' and  ";
                    }
                    else
                    {
                        resu += p.Name + " != \'" + p.GetValue(t) + "\' and  ";
                    }
                }
            }
            resu = resu.Trim();
            int l = resu.LastIndexOf("and");

            if (l > 0 && resu.Length - 3 == l)
            {
                resu = resu.Trim().Remove(l);
            }
            l = resu.LastIndexOf("where");

            if (l > 0 && resu.Length - 5 == l)
            {
                resu = resu.Trim().Remove(l);
            }
            return resu;
        }


        /// <summary>
        /// 根据dataModel 生成insert语句
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string makeInsertSqlCommandT<T>(T t)
        {

            System.Reflection.PropertyInfo[] ps = t.GetType().GetProperties();

            Type ts = t.GetType();
            string resu = "insert into " + ts.Name + "(";
            string[] temp1 = new string[ps.Length];
            string[] temp2 = new string[ps.Length];
            int count = 0;
            //string resu = "select * from " + ts.Name;
            if (t != null)
            {

                foreach (System.Reflection.PropertyInfo p in ps)
                {

                    if ((!Convert.ToString(p.GetValue(t)).Equals("")) && (!Convert.ToString(p.GetValue(t)).Equals(null)))
                    {
                        //resu.Add(p.Name + "=" + p.GetValue(data));
                        if (p.GetValue(t).ToString().IndexOf('\'') >= 0)
                        {
                            resu = "safe check fail";
                        }
                        temp1[count] = p.Name;
                        temp2[count] = Convert.ToString(p.GetValue(t));
                        count++;
                    }
                }
                int l = count;


                for (int i = 0; i < l; i++)
                {
                    if (i != l - 1)
                    {
                        resu += temp1[i] + ",";
                    }
                    else if (i == l - 1)
                    {

                        resu += temp1[i];

                    }
                }
                resu += ") values(";
                for (int i = 0; i < l; i++)
                {
                    if (i != l - 1)
                    {
                        resu = resu + "\'" + temp2[i] + "\',";
                    }
                    else if (i == l - 1)
                    {
                        resu = resu + "\'" + temp2[i] + "\'";

                    }

                }
                resu += ")";


            }
            return resu;
        }

        public static string makeInsertSqlCommand(object t)
        {

            System.Reflection.PropertyInfo[] ps = t.GetType().GetProperties();

            Type ts = t.GetType();
            string resu = "insert into " + ts.Name + "(";
            string[] temp1 = new string[ps.Length];
            string[] temp2 = new string[ps.Length];
            int count = 0;
            //string resu = "select * from " + ts.Name;
            if (t != null)
            {

                foreach (System.Reflection.PropertyInfo p in ps)
                {

                    if ((!Convert.ToString(p.GetValue(t)).Equals("")) && (!Convert.ToString(p.GetValue(t)).Equals(null)))
                    {

                        if (p.GetValue(t).ToString().IndexOf('\'') >= 0)
                        {
                            resu = "safe check fail";
                        }
                        //resu.Add(p.Name + "=" + p.GetValue(data));
                        temp1[count] = p.Name;
                        temp2[count] = Convert.ToString(p.GetValue(t));
                        count++;
                    }
                }
                int l = count;


                for (int i = 0; i < l; i++)
                {
                    if (i != l - 1)
                    {
                        resu += temp1[i] + ",";
                    }
                    else if (i == l - 1)
                    {

                        resu += temp1[i];

                    }
                }
                resu += ") values(";
                for (int i = 0; i < l; i++)
                {
                    if (i != l - 1)
                    {
                        resu = resu + "\'" + temp2[i] + "\',";
                    }
                    else if (i == l - 1)
                    {
                        resu = resu + "\'" + temp2[i] + "\'";

                    }

                }
                resu += ")";


            }
            return resu;
        }

        /// <summary>
        /// 泛型 根据dataModel 生成update语句
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string makeUpdateSqlCommandT<T>(T t, bool isNon, string wherekey, string reValue)
        {
            System.Reflection.PropertyInfo[] ps = t.GetType().GetProperties();

            Type ts = t.GetType();
            string resu = "update " + ts.Name + " set ";

            string temp = null;
            string where = null;
            string w = null;

            if (t != null)
            {
                foreach (System.Reflection.PropertyInfo p in ps)
                {


                    if ((!Convert.ToString(p.GetValue(t)).Equals("")) && (!Convert.ToString(p.GetValue(t)).Equals(null)))
                    {
                        try
                        {

                            if (p.GetValue(t).ToString().IndexOf('\'') >= 0)
                            {
                                resu = "safe check fail";
                            }
                            if (p.Name.Equals(wherekey))
                            {
                                if (!string.IsNullOrEmpty(reValue))
                                {
                                    resu += p.Name + "= \'" + reValue + "\',";
                                    temp = p.GetValue(t).ToString();
                                }
                                else
                                {
                                    temp = p.GetValue(t).ToString();

                                }
                            }
                            else
                            {
                                resu += p.Name + "= \'" + p.GetValue(t).ToString() + "\',";
                            }
                        }
                        catch { }


                    }



                }

                if ((!string.IsNullOrEmpty(wherekey)) && (!string.IsNullOrEmpty(temp)))
                {
                    where = temp;
                    w = wherekey;
                    int l = resu.LastIndexOf(',');
                    if (l > 0 && resu.Length - 1 == l)
                    {
                        resu = resu.Remove(l);

                    }

                    if (!isNon)
                    {
                        resu += " where  " + w + " = \'" + where + "\'";
                    }
                    else
                    {
                        resu += " where  " + w + " != \'" + where + "\'";
                    }

                }
                int l2 = resu.LastIndexOf(',');
                if (l2 > 0 && resu.Length - 1 == l2)
                {
                    resu = resu.Remove(l2);

                }


            }
            return resu;
        }

        public static string makeUpdateSqlCommand(object t, string wherekey, string reValue, bool isNon)
        {
            System.Reflection.PropertyInfo[] ps = t.GetType().GetProperties();

            Type ts = t.GetType();
            string resu = "update " + ts.Name + " set ";

            string temp = null;
            string where = null;
            string w = null;

            if (t != null)
            {
                foreach (System.Reflection.PropertyInfo p in ps)
                {


                    if ((!Convert.ToString(p.GetValue(t)).Equals("")) && (!Convert.ToString(p.GetValue(t)).Equals(null)))
                    {
                        try
                        {
                            if (p.GetValue(t).ToString().IndexOf('\'') >= 0)
                            {
                                resu = "safe check fail";
                            }


                            if (p.Name.Equals(wherekey))
                            {
                                if (!string.IsNullOrEmpty(reValue))
                                {
                                    resu += p.Name + "= \'" + reValue + "\',";
                                    temp = p.GetValue(t).ToString();
                                }
                                else
                                {
                                    temp = p.GetValue(t).ToString();

                                }
                            }
                            else
                            {
                                resu += p.Name + "= \'" + p.GetValue(t).ToString() + "\',";
                            }
                        }
                        catch { }


                    }



                }

                if ((!string.IsNullOrEmpty(wherekey)) && (!string.IsNullOrEmpty(temp)))
                {
                    where = temp;
                    w = wherekey;
                    int l = resu.LastIndexOf(',');
                    if (l > 0 && resu.Length - 1 == l)
                    {
                        resu = resu.Remove(l);

                    }

                    if (!isNon)
                    {
                        resu += " where  " + w + " = \'" + where + "\'";
                    }
                    else
                    {
                        resu += " where  " + w + " != \'" + where + "\'";
                    }

                }
                int l2 = resu.LastIndexOf(',');
                if (l2 > 0 && resu.Length - 1 == l2)
                {
                    resu = resu.Remove(l2);

                }


            }
            return resu;
        }


        /// <summary>
        /// 泛型 根据dataModel 生成delete语句
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="isNon"></param>
        /// <returns></returns>
        public static string makeDeleteSqlCommandT<T>(T t, bool isNon)
        {
            System.Reflection.PropertyInfo[] ps = t.GetType().GetProperties();
            Type ts = t.GetType();
            string resu = "delete from " + ts.Name + " where ";
            if (t != null)
            {
                foreach (System.Reflection.PropertyInfo p in ps)
                {
                    if ((!Convert.ToString(p.GetValue(t)).Equals("")) && (!Convert.ToString(p.GetValue(t)).Equals(null)))
                    {

                        if (p.GetValue(t).ToString().IndexOf('\'') >= 0)
                        {
                            resu = "safe check fail";
                        }
                        if (!isNon)
                        {
                            resu += p.Name + " = \'" + p.GetValue(t) + "\' and  ";
                        }
                        else
                        {
                            resu += p.Name + " != \'" + p.GetValue(t) + "\' and  ";
                        }
                    }
                }
                resu = resu.Trim();
                int l = resu.LastIndexOf("and");

                if (l > 0 && resu.Length - 3 == l)
                {
                    resu = resu.Trim().Remove(l);
                }

            }
            return resu;

        }

        public static string makeDeleteSqlCommand(object t, bool isNon)
        {
            System.Reflection.PropertyInfo[] ps = t.GetType().GetProperties();
            Type ts = t.GetType();
            string resu = "delete from " + ts.Name + " where ";
            if (t != null)
            {
                foreach (System.Reflection.PropertyInfo p in ps)
                {
                    if ((!Convert.ToString(p.GetValue(t)).Equals("")) && (!Convert.ToString(p.GetValue(t)).Equals(null)))
                    {
                        if (p.GetValue(t).ToString().IndexOf('\'') >= 0)
                        {
                            resu = "safe check fail";
                        }
                        if (!isNon)
                        {
                            resu += p.Name + " = \'" + p.GetValue(t) + "\' and  ";
                        }
                        else
                        {
                            resu += p.Name + " != \'" + p.GetValue(t) + "\' and  ";
                        }
                    }
                }
                resu = resu.Trim();
                int l = resu.LastIndexOf("and");

                if (l > 0 && resu.Length - 3 == l)
                {
                    resu = resu.Trim().Remove(l);
                }

            }
            return resu;

        }



        /// <summary>
        /// 泛型 根据dataModel 生成insert语句,多条数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ts"></param>
        /// <returns></returns>
        public static string makeInsertSqlCommandT<T>(List<T> lts)
        {
            T[] ts = lts.ToArray();
            string resu = null;
            string colu = makeInsertColumnsDataT<T>(ts[0]);
            if (string.IsNullOrEmpty(colu) || colu.Trim().Equals("()"))
            {
                return null;
            }

            try
            {

                string values = "";
                string temp = null;
                foreach (T t in ts)
                {
                    values += makeInsertValuesData<T>(t) + ",";
                    if (string.IsNullOrEmpty(temp))
                    {
                        System.Reflection.PropertyInfo[] ps = ts.GetType().GetProperties();
                        Type ty = t.GetType();
                        temp = ty.Name;
                    }
                }
                values = removeSurpData(values);
                resu = "insert into " + temp + colu + " values" + values;
                //resu += 






            }
            catch { }


            return resu;
        }

        public static string makeInsertSqlCommandS(object o)
        {
            object[] os = o as object[];

            string resu = null;
            string colu = makeInsertColumnsData(os[0]);
            if (string.IsNullOrEmpty(colu) || colu.Trim().Equals("()"))
            {
                return null;
            }

            try
            {

                string values = "";
                string temp = null;
                foreach (object ts in os)
                {
                    values += makeInsertValuesData(ts) + ",";
                    if (string.IsNullOrEmpty(temp))
                    {
                        System.Reflection.PropertyInfo[] ps = ts.GetType().GetProperties();
                        Type ty = ts.GetType();
                        temp = ty.Name;
                    }
                }
                values = removeSurpData(values);
                resu = "insert into " + temp + colu + " values" + values;
                //resu += 






            }
            catch { }


            return resu;
        }



        /// <summary>
        /// 泛型 生成insert 语句 值的集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string makeInsertValuesData<T>(T t)
        {
            System.Reflection.PropertyInfo[] ps = t.GetType().GetProperties();
            string resu = "(";

            try
            {

                foreach (System.Reflection.PropertyInfo p in ps)
                {
                    if ((!Convert.ToString(p.GetValue(t)).Equals("")) && (!Convert.ToString(p.GetValue(t)).Equals(null)))
                    {
                        if (p.GetValue(t).ToString().IndexOf('\'') >= 0)
                        {
                            resu = "safe check fail";
                        }
                        resu += "\'" + p.GetValue(t) + "\',";

                    }
                }


            }
            catch { }
            resu = resu.Trim();
            resu = removeSurpData(resu);
            resu += ")";
            return resu;

        }

        public static string makeInsertValuesDataT(object t)
        {
            System.Reflection.PropertyInfo[] ps = t.GetType().GetProperties();
            string resu = "(";

            try
            {

                foreach (System.Reflection.PropertyInfo p in ps)
                {
                    if ((!Convert.ToString(p.GetValue(t)).Equals("")) && (!Convert.ToString(p.GetValue(t)).Equals(null)))
                    {
                        if (p.GetValue(t).ToString().IndexOf('\'') >= 0)
                        {
                            resu = "safe check fail";
                        }
                        resu += "\'" + p.GetValue(t) + "\',";

                    }
                }


            }
            catch { }
            resu = resu.Trim();
            resu = removeSurpData(resu);
            resu += ")";
            return resu;

        }


        /// <summary>
        /// 泛型 生成insert 语句 列名的集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string makeInsertColumnsDataT<T>(T t)
        {
            System.Reflection.PropertyInfo[] ps = t.GetType().GetProperties();
            string resu = "(";

            try
            {

                foreach (System.Reflection.PropertyInfo p in ps)
                {
                    if ((!Convert.ToString(p.GetValue(t)).Equals("")) && (!Convert.ToString(p.GetValue(t)).Equals(null)))
                    {

                        resu += p.Name + ",";

                    }
                }


            }
            catch { }
            resu = resu.Trim();
            resu = removeSurpData(resu);
            resu += ")";
            return resu;

        }

        public static string makeInsertColumnsData(object t)
        {
            System.Reflection.PropertyInfo[] ps = t.GetType().GetProperties();
            string resu = "(";

            try
            {

                foreach (System.Reflection.PropertyInfo p in ps)
                {
                    if ((!Convert.ToString(p.GetValue(t)).Equals("")) && (!Convert.ToString(p.GetValue(t)).Equals(null)))
                    {

                        resu += p.Name + ",";

                    }
                }


            }
            catch { }
            resu = resu.Trim();
            resu = removeSurpData(resu);
            resu += ")";
            return resu;

        }

        /// <summary>
        /// 删除逗号
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string removeSurpData(string data)
        {
            int l = data.LastIndexOf(',');
            if (l > 0 && data.Length - 1 == l)
            {
                data = data.Remove(l);

            }
            return data;
        }


        /// <summary>
        /// 泛型 获取数据model的值集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string[] getValues<T>(T t)
        {
            System.Reflection.PropertyInfo[] ps = t.GetType().GetProperties();
            string[] temp = new string[ps.Length];
            int count = 0;
            foreach (System.Reflection.PropertyInfo p in ps)
            {

                if ((!Convert.ToString(p.GetValue(t)).Equals(null)) && ((!Convert.ToString(p.GetValue(t)).Equals(""))))
                {
                    //resu.Add(p.Name + "=" + p.GetValue(data));
                    temp[count] = p.GetValue(t).ToString();
                    count++;

                }
            }

            string[] resu = new string[count];
            for (int i = 0; i < count; i++)
            {
                resu[i] = temp[i];
            }
            return resu;


        }


        /// <summary>
        /// 泛型 获取SqlDataReader 的值,并根据相应的model,转换未字典列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="sdr"></param>
        /// <returns></returns>
        public static type_lds getSdrVaulesT<T>(T t, SqlDataReader sdr)
        {
            type_lds resu = new type_lds();

            try
            {
                while (sdr.Read())
                {
                    Dictionary<string, string> temp = new Dictionary<string, string>();
                    foreach (System.Reflection.PropertyInfo p in t.GetType().GetProperties())
                    {

                        temp[p.Name] = sdr[p.Name].ToString();


                    }
                    resu.Add(temp);

                }
            }
            catch
            {
                sdr.Close();
            }

            sdr.Close();

            return resu;

        }

        public static type_lds getSdrVaules(object t, SqlDataReader sdr)
        {
            type_lds resu = new type_lds();

            try
            {
                while (sdr.Read())
                {
                    Dictionary<string, string> temp = new Dictionary<string, string>();
                    foreach (System.Reflection.PropertyInfo p in t.GetType().GetProperties())
                    {

                        temp[p.Name] = sdr[p.Name].ToString();


                    }
                    resu.Add(temp);

                }
            }
            catch
            {
                sdr.Close();
            }

            sdr.Close();

            return resu;

        }



        /// <summary>
        /// 执行sql返回受影响行数
        /// </summary>
        /// <param name="OpenStatSqlCon"></param>
        /// <param name="cmdtext"></param>
        /// <returns></returns>
        public static int SqlEvilRint(SqlConnection OpenStatSqlCon, string cmdtext)
        {
            int resu = -2;
            try
            {
                SqlCommand sqlcmd = new SqlCommand(cmdtext, OpenStatSqlCon);
                resu = sqlcmd.ExecuteNonQuery();
            }
            catch { }

            return resu;
        }


        /// <summary>
        /// 执行sql返回第一行第一列
        /// </summary>
        /// <param name="OpenStatSqlCon"></param>
        /// <param name="cmdtext"></param>
        /// <returns></returns>
        public static string SqlEvilRtext(SqlConnection OpenStatSqlCon, string cmdtext)
        {
            string resu = null;
            try
            {
                SqlCommand sqlcmd = new SqlCommand(cmdtext, OpenStatSqlCon);
                resu = sqlcmd.ExecuteScalar().ToString();
            }
            catch { }

            return resu;
        }


        /// <summary>
        /// 泛型 执行sql 返回字段列表,一个字典对应一行数据,字典的key对应字段名
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="OpenStatSqlCon"></param>
        /// <param name="cmdtext"></param>
        /// <returns></returns>
        public static type_lds SqlEvilRldsT<T>(T t, SqlConnection OpenStatSqlCon, string cmdtext)
        {
            type_lds resu = new type_lds();
            try
            {
                SqlCommand sqlcmd = new SqlCommand(cmdtext, OpenStatSqlCon);
                SqlDataReader sdr = sqlcmd.ExecuteReader(CommandBehavior.Default);
                resu = sqlHelper.getSdrVaulesT<T>(t, sdr);

            }
            catch { }

            return resu;
        }

        public static type_lds SqlEvilRlds(object t, SqlConnection OpenStatSqlCon, string cmdtext)
        {
            type_lds resu = new type_lds();
            try
            {
                SqlCommand sqlcmd = new SqlCommand(cmdtext, OpenStatSqlCon);
                SqlDataReader sdr = sqlcmd.ExecuteReader(CommandBehavior.Default);
                resu = sqlHelper.getSdrVaules(t, sdr);

            }
            catch { }

            return resu;
        }



        /// <summary>
        /// 泛型 执行sql 返回对应model类的列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="OpenStatSqlCon"></param>
        /// <param name="cmdtext"></param>
        /// <returns></returns>
        public static List<T> SqlEvilRltT<T>(T t, SqlConnection OpenStatSqlCon, string cmdtext)
        {
            //type_lds resu = new type_lds();
            List<T> resu = new List<T>();
            try
            {



                SqlCommand sqlcmd = new SqlCommand(cmdtext, OpenStatSqlCon);
                SqlDataReader sdr = sqlcmd.ExecuteReader(CommandBehavior.Default);
                type_lds lds = sqlHelper.getSdrVaulesT<T>(t, sdr);
                resu = ConvertLdsToLT<T>(t, lds);



            }
            catch { }

            return resu;
        }



        /// <summary>
        /// 泛型 把字典列表根据model类格式化为列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="lds"></param>
        /// <returns></returns>
        public static List<T> ConvertLdsToLT<T>(T t, type_lds lds)
        {
            List<T> resu = new List<T>();
            try
            {
                for (int l = 0; l < lds.Count; l++)
                {


                    foreach (System.Reflection.PropertyInfo p in t.GetType().GetProperties())
                    {

                        p.SetValue(t, lds[l][p.Name]);


                    }
                    resu.Add((T)ioHelper.CloneObject(t));
                }
            }
            catch { }
            return resu;

        }


        /// <summary>
        /// 泛型 把字典格式化成对应model类
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static T ConvertDsToT<T>(T t, Dictionary<string, string> ds)
        {
            foreach (System.Reflection.PropertyInfo p in t.GetType().GetProperties())
            {

                p.SetValue(t, ds[p.Name]);


            }
            return t;
        }





        /// <summary>
        /// 泛型 把model类格式化成对应字典
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static Dictionary<string, string> ConvertTToDsT<T>(T t)
        {
            Dictionary<string, string> resu = new Dictionary<string, string>();
            try
            {
                foreach (System.Reflection.PropertyInfo p in t.GetType().GetProperties())
                {


                    resu[p.Name] = p.GetValue(t).ToString();

                }
            }
            catch { }
            return resu;
        }

        public static Dictionary<string, string> ConvertTToDs(object t)
        {
            Dictionary<string, string> resu = new Dictionary<string, string>();
            try
            {
                foreach (System.Reflection.PropertyInfo p in t.GetType().GetProperties())
                {

                    if (p.GetValue(t) != null)
                    {
                        resu[p.Name] = p.GetValue(t).ToString();
                    }

                }
            }
            catch { }
            return resu;
        }

        /// <summary>
        /// 泛型 把model类列表格式化成字典列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static type_lds ConvertLtToLds<T>(List<T> t)
        {
            type_lds resu = new type_lds();
            try
            {
                for (int l = 0; l < t.Count; l++)
                {
                    T temp = t[l];
                    Dictionary<string, string> ds = ConvertTToDsT<T>(temp);
                    resu.Add(ds);
                }
            }
            catch { }
            return resu;
        }





        public static T ConvertObjToModel<T>(object m)
        {
            dynamic obj = null;
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            obj = assembly.CreateInstance(m.GetType().FullName);
            return (T)obj;

        }







    }
}