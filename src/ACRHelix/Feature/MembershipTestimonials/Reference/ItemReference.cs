using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.MembershipTestimonials.Reference
{
    public static class ItemReference
    {
        public static string MtPageItemId
        {
            get
            {
                return "{7E849CBA-2E97-495A-B339-272537446D43}";
            }
        }
        public static string ImageFolderItemId
        {
            get
            {
                return "{323805CC-FFE6-448E-A27D-43EAD84E4967}"; 
            }
        }

        public static string TestimonialsFolderItemId
        {
            get
            {
                return "{23D426F1-6A69-4D8D-B472-DBDA09575BE2}";
            }
        }

        public static string LoginPageItemId
        {
            get
            {
                return "{464B2C60-1D19-4D85-9EF9-281B36CF008F}";
            }
        }

        public static string ConfirmationPageItemId
        {
            get
            {
                return "{DDB990E3-21CA-4952-B4A4-2FF350056095}";
            }
        }

        public static string NotAuthorizedPageItemId
        {
            get
            {
                return "{38A89A80-0903-4EFE-BC17-BBAA76FD715E}";
            }
        }

        //public static string ImageFolderPath { get { return ((NameValueCollection)ConfigurationManager.GetSection("MTSiteReference/ItemReference"))["ImageFolderPath"]; } }
    }
}