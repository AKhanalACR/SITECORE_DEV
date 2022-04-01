using System.Data.SqlClient;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace ACRHelix.Feature.DecampFeatureRenderings.Models
{
  [DataContract]
  public class Location
    {

    [DataMember(Name = "SiteName")]
    public string SiteName { get; set; }

    [DataMember(Name = "SiteAddress")]
    public string SiteAddress { get; set; }

    [DataMember(Name = "State")]
    public string State { get; set; }

    [DataMember(Name = "PI1Name")]
    public string PI1Name { get; set; }

    [DataMember(Name = "PI1BioLink")]
    public string PI1BioLink { get; set; }

    [DataMember(Name = "PI2Name")]
    public string PI2Name { get; set; }

    [DataMember(Name = "PI2BioLink")]
    public string PI2BioLink { get; set; }

    [DataMember(Name = "ResearchAssociate")]
    public string ResearchAssociate { get; set; }

    [DataMember(Name = "Latitude")]
    public string Latitude { get; set; }

    [DataMember(Name = "Longtitude")]
    public string Longitude { get; set; }

    [DataMember(Name = "RAEmail")]
    public string RAEmail { get; set; }


    public void Load(SqlDataReader reader)
        {
            SiteName = reader["Site Name"].ToString();
            SiteAddress = reader["Site Address"].ToString();
            State = reader["State"].ToString();
            PI1Name = reader["PI 1 Name"].ToString();
            PI1BioLink = reader["PI 1 Bio Link"].ToString();
            PI2Name = reader["PI 2 Name"].ToString();
            PI2BioLink = reader["PI 2 Bio Link"].ToString();
            ResearchAssociate = reader["Research Associate"].ToString();

            Latitude = reader["Latitude"].ToString();
            Longitude = reader["Longitude"].ToString();

            RAEmail = reader["RA Email"].ToString();
      }
    }
}