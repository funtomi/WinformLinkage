using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.IO;
using System.Data;

namespace WinformLinkage {
    /// <summary>
    /// json辅助类
    /// </summary>
    static class JsonHelper {

        /// <summary>
        /// 读取数据文件
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static string GetFileJson(string filepath) {
            string json = string.Empty;
            if (!File.Exists(filepath)) {
                return json;
            }
            using (FileStream fs = new FileStream(filepath, FileMode.Open, System.IO.FileAccess.Read, FileShare.ReadWrite)) {
                using (StreamReader sr = new StreamReader(fs, Encoding.GetEncoding("utf-8"))) {
                    json = sr.ReadToEnd().ToString();
                }
            }
            return json;
        }

        public static void SaveFileJson(string filePath, string json) {
            try {
                using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write)) {
                    using (StreamWriter sw = new StreamWriter(fs)) {
                        sw.WriteLine(json);
                    }
                }
            } catch (Exception) {
                throw;
            }

        }

        /// <summary>
        /// List<T>转Json
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string Obj2Json<T>(T data) {
            try {
                System.Runtime.Serialization.Json.DataContractJsonSerializer serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(data.GetType());
                using (MemoryStream ms = new MemoryStream()) {
                    serializer.WriteObject(ms, data);
                    return Encoding.UTF8.GetString(ms.ToArray());
                }
            } catch {
                return null;
            }
        }

        /// <summary>
        /// Json转List<T>
        /// </summary>
        /// <param name="json"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static Object Json2Obj(String json, Type t) {
            try {
                System.Runtime.Serialization.Json.DataContractJsonSerializer serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(t);
                using (MemoryStream ms = new MemoryStream(Encoding.ASCII.GetBytes(json))) {

                    return serializer.ReadObject(ms);
                }
            } catch {
                return null;
            }
        }

        /// <summary>
        /// 获取Json的Model
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="szJson"></param>
        /// <returns></returns>
        public static T ParseFromJson<T>(string szJson) {
            T obj = Activator.CreateInstance<T>();  //注意 要有T类型要有无参构造函数
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(szJson))) {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
                return (T)serializer.ReadObject(ms);
            }
        }

        /// <summary>
        /// DataTable 转Json
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string DataTable2Json(DataTable dt) {
            if (dt.Rows.Count == 0) {
                return "";
            }

            StringBuilder jsonBuilder = new StringBuilder();  
            jsonBuilder.Append("[");//转换成多个model的形式  
            for (int i = 0; i < dt.Rows.Count; i++) {
                jsonBuilder.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++) {
                    jsonBuilder.Append("\"");
                    jsonBuilder.Append(dt.Columns[j].ColumnName);
                    jsonBuilder.Append("\":\"");
                    jsonBuilder.Append(dt.Rows[i][j].ToString());
                    jsonBuilder.Append("\",");
                }
                jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                jsonBuilder.Append("},");
            }
            jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
            jsonBuilder.Append("]"); 
            return jsonBuilder.ToString();
        }

        /// <summary>
        /// 单个对象转JSON
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T Json2Obj<T>(string json) {
            T obj = Activator.CreateInstance<T>();
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(json))) {
                System.Runtime.Serialization.Json.DataContractJsonSerializer serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(obj.GetType());
                return (T)serializer.ReadObject(ms);
            }
        }  


    }
}
