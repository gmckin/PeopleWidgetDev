using PeopleData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DataAccessObjects;
using System.IO;
using DataAccess;
using System.Reflection;

namespace DataAccess.Crud
{
    public partial class DataAccessHelper
    {
        private SqlConnection conn;
        AccessMapper am = new AccessMapper();
        DataTable dt;
        public List<People> GetPeople()
        {
            DataSet ds = new DataSet();
           

            dt = new DataTable();
            dt.TableName = "People";
            dt.Columns.Add("Id", typeof(Int32));
            dt.Columns.Add("FirstName", typeof(string));
            dt.Columns.Add("LastName", typeof(string));
            dt.Columns.Add("DateOfBirth", typeof(DateTime));
            dt.Columns.Add("Age",typeof(Int16));
            dt.Columns.Add("Gender", typeof(string));
            ds.Tables.Add(dt);
            string fileName = "PeopleDataSet.xml";
            System.IO.StringReader sr = new System.IO.StringReader(fileName);
            ds.ReadXml("C:\\Users\\gmck9\\source\\repos\\PeopleWidget\\PeopleData\\PeopleDataSet.xml", XmlReadMode.InferSchema);

            List<People> people = new List<People>((IEnumerable<People>)ds);
            people = people.Cast<People>().ToList();
            //var rows = ds.Tables.AsQueryable();
            //List<PersonDAO> p = new List<PersonDAO>();
            //foreach (var row in rows)
            //{
            //    p = am.MapToEntity(from DataRow dr in dt.Rows select new PersonDAO());
            //}
            return people;
        }

        private void fillRows(int Id, string FirstName, string LastName, DateTime DateOfBirth, int Age, string Gender)
        {
            DataRow dr;
            dr = dt.NewRow();
            dr["Id"] = Id;
            dr["FirstName"] = FirstName;
            dr["LastName"] = LastName;
            dr["DateOfBirth"] = DateOfBirth;
            dr["Age"] = Age;
            dr["Gender"] = Gender;
            dt.Rows.Add(dr);
        }
    }
}
