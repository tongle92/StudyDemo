using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable dt = ToSql.CreateDataTable();
            ToSql.QueryByName(dt);
            ToSql.OrderByAgeDesc(dt);
            Console.Read();
        }



    }

    public class ToSql
    {
        /// <summary>
        /// 构造datatable
        /// </summary>
        /// <returns></returns>
        public static DataTable CreateDataTable()
        {
            using (DataTable dt = new DataTable("student"))
            {

                DataColumn dcname = new DataColumn("name", typeof(string));
                dt.Columns.Add(dcname);
                DataColumn dcage = new DataColumn("age", typeof(int));
                dt.Columns.Add(dcage);
                DataColumn dcsex = new DataColumn("sex", typeof(bool));
                dt.Columns.Add(dcsex);
                DataColumn dcaddress = new DataColumn("address", typeof(string));
                dt.Columns.Add(dcaddress);

                DataRow dr = dt.NewRow();
                dr["name"] = "a";
                dr["age"] = 20;
                dr["sex"] = false;
                dr["address"] = "苏州";
                dt.Rows.Add(dr);

                DataRow dr2 = dt.NewRow();
                dr2["name"] = "b";
                dr2["age"] = 18;
                dr2["sex"] = false;
                dr2["address"] = "上海";
                dt.Rows.Add(dr2);

                DataRow dr3 = dt.NewRow();
                dr3["name"] = "c";
                dr3["age"] = 19;
                dr3["sex"] = true;
                dr3["address"] = "无锡";
                dt.Rows.Add(dr3);

                DataRow dr4 = dt.NewRow();
                dr4["name"] = "d";
                dr4["age"] = 18;
                dr4["sex"] = true;
                dr4["address"] = "杭州";
                dt.Rows.Add(dr4);

                DataRow dr5 = dt.NewRow();
                dr5["name"] = "e";
                dr5["age"] = 17;
                dr5["sex"] = false;
                dr5["address"] = "宜兴";
                dt.Rows.Add(dr5);

                return dt;

            }

        }

        /// <summary>
        /// 根据名字查询
        /// </summary>
        /// <param name="dt"></param>
        public static void QueryByName(DataTable dt)
        {
            var rows = from dr in dt.AsEnumerable() where dr.Field<string>("name") == "a" select dr;
            //获取名字
            var list = from dr in rows select dr["name"].ToString();

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// 根据年龄倒序
        /// </summary>
        /// <param name="dt"></param>
        public static void OrderByAgeDesc(DataTable dt)
        {
            var rows = from dr in dt.AsEnumerable() orderby dr.Field<int>("age"),dr.Field<string>("name") descending select dr;
            var listage = from row in rows select int.Parse(row["age"].ToString());

            StringBuilder sb = new StringBuilder();
            foreach (var item in listage)
            {
                sb.Append(item+" ");
            }
            sb.Append("\r\n");

            var listname = from row in rows select row["name"].ToString();
            foreach (var item in listname)
            {
                sb.Append(item + " ");
            }
            Console.WriteLine(sb);
        }
    }

    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public bool Sex { get; set; }
        public string Address { get; set; }

    }
}
