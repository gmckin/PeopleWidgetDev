using DataAccess.Crud;
using DataClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using DataClient;


namespace DataClient
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DataService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select DataService.svc or DataService.svc.cs at the Solution Explorer and start debugging.
    public class DataService : IDataService
    {

        public List<PersonDTO> GetPeople()
        {
            DataAccessHelper ah = new DataAccessHelper();
            var s = ah.GetPeople();
            var p = new List<PersonDTO>();

            foreach(var item in s)
            {
               // p.Add(PeopleMapper.MapToPeopleDTO(item));
            }
            return null;
        }       
    }
}
