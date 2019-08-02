using AutoMapper;
using DataAccess.DataAccessObjects;
using PeopleData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AccessMapper
    {
        public readonly MapperConfiguration PeopleMapper = new MapperConfiguration(c => c.CreateMap<People, PersonDAO>().ReverseMap());
        private SqlConnection conn;
        DataSet ds;
        SqlDataAdapter da;

        public List<People> p;


        public PersonDAO MapToDao(People p)
        {
            var mapper = PeopleMapper.CreateMapper();
            if (p != null)
            {
                PersonDAO pd = mapper.Map<PersonDAO>(p);
                return pd;
            }
            else
            {
                return new PersonDAO();
            }
        }


        public People MapToEntity(PersonDAO pd)
        {
            var p = new People
            {
                Id = pd.Id,
                FirstName = pd.FirstName,
                LastName = pd.LastName,
                DateOfBirth = pd.DateOfBirth,
                Age = pd.Age,
                Gender = pd.Gender
            };

            return p;
        }

        public static object MapTo(object o)
        {
            var properties = o.GetType().GetProperties();
            var ob = new object();

            foreach (var item in properties.ToList())
            {
                ob.GetType().GetProperty(item.Name).SetValue(ob, item.GetValue(item));
            }
            return ob;
        }
    }
}
