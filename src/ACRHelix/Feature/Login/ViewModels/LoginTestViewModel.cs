using ACR.Foundation.Personify.Models.Taxonomy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Login.ViewModels
{
  public class LoginTestViewModel
  {
    //public string HiddenCapcha { get; set; }
    public List<string> PersonifyIDs { get; set; }
    public string CustomerToken { get; set; }
    public string UserData { get; set; }
    public string UserProfile { get; set; }

    public string Import { get; set; }

    public string ImportResults { get; set; } = string.Empty;

    public List<PersonifyTaxonomyItem> Interests { get; set; } = new List<PersonifyTaxonomyItem>();

    public List<PersonifyTaxonomyItem> Modalities { get; set; } = new List<PersonifyTaxonomyItem>();

    public List<PersonifyTaxonomyItem> Subspecialties { get; set; } = new List<PersonifyTaxonomyItem>();

    public List<KeyValuePair<string, string>> InfoPairs { get; set; } = new List<KeyValuePair<string, string>>();
  }
}