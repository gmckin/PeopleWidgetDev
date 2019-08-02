using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataClient.Models;
using DataAccess.DataAccessObjects;
using DataAccess.Crud;

namespace DataClient
{
    public class PeopleMapper
    {
        public static PersonDTO MapToPeopleDTO(PersonDTO person)
        {
            DataAccessHelper ah = new DataAccessHelper();
            var p = new PersonDTO
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                DateOfBirth = person.DateOfBirth,
                Gender = person.Gender
            };

            return p;
        }

        public static PersonDAO MapToPersonDAO(PersonDAO person)
        {
            var p = new PersonDAO
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                DateOfBirth = person.DateOfBirth,
                Age = person.Age,
                Gender = person.Gender
            };

            return p;
        }

        //internal static List<PersonDTO> MapToPeopleDTO(IEnumerable<PersonDTO> enumerable)
        //{

        //    var p = new PersonDTO
        //    {
        //        Id = person.Id,
        //        FirstName = person.FirstName,
        //        LastName = person.LastName,
        //        DateOfBirth = person.DateOfBirth,
        //        Gender = person.Gender
        //    };

        //    return p;
        //}

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