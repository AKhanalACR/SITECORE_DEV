using System.Data.SqlClient;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace ACRHelix.Feature.MyCtColonography.Models
{
    [DataContract]
    public class Location
    {
        [DataMember(Name = "FirstName")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DataMember(Name = "LastName")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DataMember(Name = "Store")]
        [DisplayName("Center Name")]
        public string Store { get; set; }

        [DataMember(Name = "Address1")]
        [DisplayName("Address 1")]
        public string Address1 { get; set; }

        [DataMember(Name = "Address2")]
        [DisplayName("Address 2")]
        public string Address2 { get; set; }

        [DataMember(Name = "City")]
        public string City { get; set; }

        [DataMember(Name = "State")]
        public string State { get; set; }

        [DataMember(Name = "Zip")]
        [DisplayName("Zipcode")]
        public string Zip { get; set; }

        [DataMember(Name = "Country")]
        public string Country { get; set; }

        [DataMember(Name = "Phone")]
        [DisplayName("Phone Number")]
        public string Phone { get; set; }

        [DataMember(Name = "Email")]
        [DisplayName("Primary Email Address")]
        public string Email { get; set; }

        [DataMember(Name = "Url")]
        [DisplayName("Website Url (if any)")]
        public string URL { get; set; }

        [DataMember(Name = "Latitude")]
        public string Latitude { get; set; }

        [DataMember(Name = "Longitude")]
        public string Longitude { get; set; }

        [DataMember(Name = "Miles")]
        public string Miles { get; set; }



        public void Load(SqlDataReader reader)
        {
            Store = reader["Store"].ToString();
            Address1 = reader["Address1"].ToString();
            Address2 = reader["Address2"].ToString();
            City = reader["city"].ToString();
            State = reader["State"].ToString();
            Zip = reader["Zip"].ToString();
            Country = reader["Country"].ToString();
            URL = reader["Url"].ToString();
            Phone = reader["Phone"].ToString();
            Latitude = reader["Latitude"].ToString();
            Longitude = reader["Longitude"].ToString();
            Miles = reader["Miles"].ToString();
        }
    }
}