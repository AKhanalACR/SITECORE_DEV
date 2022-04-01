using ACRHelix.Feature.Toolkits.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACRHelix.Feature.Toolkits.DAL
{
  interface IToolkitsRepository : IDisposable
  {
    IEnumerable<FacetItem> GetFacets();
    IEnumerable<FacetItem> GetMesoFacets();

    string ChechCustomerType(string customerId);

    string CheckMesoCustomerType(string customerId);

    IEnumerable<Resource> GetResources(string csetting, string ctype, string rtype, string kword, int sindex, int count);

    IEnumerable<MesoResource> GetMesoResources(string tgtype, string cktype, string asctype, string rtype, string kword, int sindex, int count);

    IEnumerable<Resource> GetAdminAreaResources(string csetting, string ctype, string rtype, string kword, string customerId, int sindex, int count);
    
    bool AddNewResource(ResourceFormData resource);
    bool AddNewMesoData(MesoFormData data);
    ReviewFormData GetResourceByID(int toolId, int flag, string customerId);
    MesoReviewFormData GetMesoResourceByID(int toolId, int flag, string customerId);

    bool SubmitResourceReview(ReviewFormData resource);

    IEnumerable<Reviewer> GetReviewers();

    bool SetReviewer(Int64 toolId, string demographicid, string customerId);

    bool SetStatus(Int64 toolId, string status, string customerId);

    IEnumerable<Reviewer> GetMesoReviewers();

    bool SetMesoReviewer(Int64 toolId, string demographicid, string customerId);

    bool SetMesoStatus(Int64 toolId, string status, string customerId);

    bool SubmitMesoResourceReview(MesoReviewFormData resource);

  }
}
