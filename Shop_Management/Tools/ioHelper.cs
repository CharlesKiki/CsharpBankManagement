using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.IO.MemoryMappedFiles;
using System.IO.Pipes;
using System.IO.IsolatedStorage;
using System.IO.Compression;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft;
//using Microsoft.Web;
using Microsoft.Win32;
using Microsoft.CSharp.RuntimeBinder;
using Microsoft.Runtime;
using System.Data.OleDb;
using System.Data.Odbc;
using System.Reflection;
//using Wsy_Model;
//这个Model不确定是不是数据库Model
using type_lds = System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>>;
using type_llds = System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>>>;
using type_dllds = System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>>>>;
using type_llls = System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<string>>>;
using type_lls = System.Collections.Generic.List<System.Collections.Generic.List<string>>;



using _sh = Wsy_webApiSystem.sqlHelper;


namespace Wsy_webApiSystem
{
    public class ioHelper
    {



        /// <summary>
        /// 克隆引用类型的内存对象 不支持泛型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T DeepCopy<T>(T obj)
        {
            object retval;
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                //序列化成流
                bf.Serialize(ms, obj);
                ms.Seek(0, SeekOrigin.Begin);
                //反序列化成对象
                retval = bf.Deserialize(ms);
                ms.Close();
            }
            return (T)retval;
        }

        /// <summary>
        /// 克隆引用类型的对象 支持泛型
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static object CloneObject(object o)
        {
            Type t = o.GetType();
            PropertyInfo[] properties = t.GetProperties();
            Object p = t.InvokeMember("", System.Reflection.BindingFlags.CreateInstance, null, o, null);
            foreach (PropertyInfo pi in properties)
            {
                if (pi.CanWrite)
                {
                    object value = pi.GetValue(o, null);
                    pi.SetValue(p, value, null);
                }
            }
            return p;
        }


        /// <summary>
        /// 序列化对象
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        //public static string SerializeModle(object o)
        //{
        //    string resu = null;
        //    BinaryFormatter mBinaryFormatter = new BinaryFormatter();
        //    MemoryStream ms = new MemoryStream();
        //    //  mBinaryFormatter.TypeFormat = FormatterTypeStyle.XsdString;
        //    mBinaryFormatter.Serialize(ms, o);
        //    ms.Seek(0, SeekOrigin.Begin);
        //    byte[] bs = new byte[ms.Length];
        //    ms.Read(bs, 0, bs.Length);
        //    resu = encodeHelper.base64Encode(Encoding.Unicode.GetString(bs, 0, bs.Length));
        //    ms.Close();
        //    return resu;
        //}

        public static byte[] SerializeModel(object o)
        {
            byte[] resu;
            BinaryFormatter mBinaryFormatter = new BinaryFormatter();
            //  mBinaryFormatter.TypeFormat = FormatterTypeStyle.XsdString;
            MemoryStream ms = new MemoryStream();
            mBinaryFormatter.Serialize(ms, o);
            ms.Seek(0, SeekOrigin.Begin);
            byte[] bs = new byte[ms.Length];
            ms.Read(bs, 0, bs.Length);
            resu = bs;
            ms.Close();
            return resu;
        }



        /// <summary>
        /// 反序列化对象
        /// </summary>
        /// <param name="serStr"></param>
        /// <returns></returns>
        //public static object DeserializeModel(string serStr)
        //{
        //    object resu = null;
        //    serStr = encodeHelper.base64Decode(serStr);
        //    byte[] serb = Encoding.Unicode.GetBytes(serStr);
        //    BinaryFormatter mBinaryFormatter = new BinaryFormatter();
        //    // mBinaryFormatter.TypeFormat = FormatterTypeStyle.XsdString;
        //    MemoryStream ms = new MemoryStream();
        //    ms.Write(serb, 0, serb.Length);
        //    // ms.Position = 0;
        //    ms.Seek(0, SeekOrigin.Begin);
        //    resu = mBinaryFormatter.Deserialize(ms);

        //    return resu;
        //}

        public static object DeserializeModel(byte[] bs)
        {
            object resu = null;
            byte[] serb = bs;
            BinaryFormatter mBinaryFormatter = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            ms.Write(serb, 0, serb.Length);
            ms.Seek(0, SeekOrigin.Begin);
            resu = mBinaryFormatter.Deserialize(ms);

            return resu;
        }



        /// <summary>
        /// 读文件
        /// </summary>
        /// <param name="fpath"></param>
        /// <returns></returns>
        public static string fileRead(string fpath)
        {
            string resu = "";

            try
            {
                FileStream fs = new FileStream(fpath, FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                resu = sr.ReadToEnd();
                sr.Close();
                fs.Close();
            }
            catch { }

            return resu;
        }


        /// <summary>
        /// 写文件
        /// </summary>
        /// <param name="fpath"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool fileWrite(string fpath, string data)
        {
            bool resu = false;
            try
            {
                FileStream fs = new FileStream(fpath, FileMode.OpenOrCreate);
                StreamWriter sw = new StreamWriter(fs);
                byte[] bdata = Encoding.UTF8.GetBytes(data);
                sw.WriteLine(data);
                sw.Close();
                fs.Close();
                resu = true;
            }
            catch { }

            return resu;
        }




        //public static string saveHttpUploadFile(System.Web.HttpPostedFileBase hpb)
        //{

        //    string resu = null;
        //    try
        //    {
        //        string h = hpb.FileName.Substring(hpb.FileName.IndexOf('.')).ToString();
        //        if (h.Equals(".xls") || h.Equals(".xlsx"))
        //        {

        //            string fname = Convert.ToString(DateTime.Now).Replace(' ', '-').Replace('/', '-').Replace(":", "-").Replace(";", "-") + hpb.FileName.Replace(";", "_");
        //            hpb.SaveAs(@"c:\temp\" + fname);
        //            resu = fname;
        //        }
        //        else
        //        {
        //            resu = "check";
        //        }

        //    }
        //    catch
        //    {
        //    }

        //    return resu;
        //}

        //public static List<List<List<string>>> searialExcelTolllS(string Path)
        //{
        //    List<List<List<string>>> resu = new List<List<List<string>>>();
        //    Path = @"c:\temp\" + Path;
        //    string strConn = "Provider=Microsoft.Ace.OleDb.12.0;" + "Data Source=" + Path + ";" + ";Extended Properties='Excel 12.0; HDR=NO; IMEX=1'";
        //    OleDbConnection conn = new OleDbConnection(strConn);
        //    conn.Open();
        //    string strExcel = "";
        //    OleDbDataAdapter myCommand = null;
        //    DataSet ds = null;
        //    strExcel = "select * from [sheet1$]";
        //    myCommand = new OleDbDataAdapter(strExcel, strConn);
        //    ds = new DataSet();
        //    myCommand.Fill(ds, "table1");
        //    //return ds;

        //    foreach (DataTable dt in ds.Tables)
        //    {
        //        List<List<string>> lls = new List<List<string>>();
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            List<string> ls = new List<string>();
        //            foreach (DataColumn dc in dr.Table.Columns)
        //            {
        //                ls.Add(dr[dc].ToString());
        //            }
        //            lls.Add(ls);
        //        }
        //        resu.Add(lls);
        //    }
        //    conn.Close();

        //    return resu;
        //}

        //public static List<List<List<string>>> searialExcelTolllS_2(string Path)
        //{
        //    List<List<List<string>>> resu = new List<List<List<string>>>();
        //    Path = @"c:\temp\" + Path;
        //    string strConn = "Provider=Microsoft.Ace.OleDb.12.0;" + "Data Source=" + Path + ";" + ";Extended Properties='Excel 12.0; HDR=NO; IMEX=1'";
        //    OleDbConnection conn = new OleDbConnection(strConn);
        //    conn.Open();
        //    string strExcel = "";
        //    OleDbDataAdapter myCommand = null;
        //    DataSet ds = null;
        //    strExcel = "select * from [sheet1$]";
        //    myCommand = new OleDbDataAdapter(strExcel, strConn);
        //    ds = new DataSet();
        //    myCommand.Fill(ds, "table1");
        //    //return ds;

        //    foreach (DataTable dt in ds.Tables)
        //    {
        //        List<List<string>> lls = new List<List<string>>();
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            List<string> ls = new List<string>();
        //            foreach (DataColumn dc in dr.Table.Columns)
        //            {
        //                ls.Add(dr[dc].ToString());
        //            }
        //            lls.Add(ls);
        //        }
        //        resu.Add(lls);
        //    }
        //    conn.Close();
        //    for (int i = 0; i < resu.Count; i++)
        //    {
        //        resu[i].RemoveAt(0);
        //    }

        //    return resu;
        //}
    }
}