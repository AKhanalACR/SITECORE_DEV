//using ACRHelix.Feature.Toolkits.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACRHelix.Feature.RhecContent.DAL
{
  interface IPledgeRepository : IDisposable
  {


    bool IsDuplicate(string email);
     int PledgesCount(string date);
    bool CreateIndividualPledge(string firstName, string lastName, string email, string country, string emailedTo);
    bool CreateFacilityPledge(string facilityName, string city, string country, string state, string zipCode, string firstName, string lastName, string email, string emailedTo);







  }
}
