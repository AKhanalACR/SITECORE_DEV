using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore;
using Sitecore.Data;

namespace ACRHelix.Feature.MeetingsCalendar.Models
{
    public class RliEventTile : ICMSEntity
    {
        public ID Id { get; set; }

        [SitecoreField(" Name")]
        public string Name { get; set; }

        [SitecoreField("Meeting Label Name")]
        public string LabelName { get; set; }

        [SitecoreField("Web Display")]
        public bool WebDisplay { get; set; }

        [SitecoreField("Web Display Start Date")]
        public DateTime WebDispStartDate { get; set; }

        [SitecoreField("Web Display End Date")]
        public DateTime WebDispEndDate { get; set; }

        [SitecoreField("Product Url")]
        public string ProductUrl { get; set; }

        [SitecoreField("Product Class")]
        public string ProductClass { get; set; }

        [SitecoreField("Product Type")]
        public string ProductType { get; set; }

        [SitecoreField("Meeting Start Date")]
        public DateTime MeetingStartDate { get; set; }

        [SitecoreField("Meeting End Date")]
        public DateTime MeetingEndDate { get; set; }

        [SitecoreField("Meeting Facility Name")]
        public string MeetingFacilityName { get; set; }

        [SitecoreField("Meeting City")]
        public string MeetingCity { get; set; }

        [SitecoreField("Meeting State")]
        public string MeetingState { get; set; }

        [SitecoreField("Meeting Registration Form Url")]
        public string MeetingRegistrationLink { get; set; }

        public string Title
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(LabelName))
                    return LabelName;
                else
                    return Name;
            }
        }

        public string ContentUrl
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(MeetingRegistrationLink))
                    return MeetingRegistrationLink;
                else
                    return ProductUrl;

            }
        }

        public string Location
        {
            get
            {
                var location = !string.IsNullOrWhiteSpace(MeetingFacilityName) ? MeetingFacilityName + ", " : "";
                location = location + (!string.IsNullOrWhiteSpace(MeetingCity) ? MeetingCity + ", " : "");
                location = location + (!string.IsNullOrWhiteSpace(MeetingCity) ? MeetingState : "");
                return location;
            } 

        }

        public DateTime FilterDate
        {
            get
            {
                if (WebDispStartDate <= DateTime.Today && WebDispEndDate >= DateTime.Today)
                {
                    return MeetingStartDate;
                }
                else
                {
                    return DateTime.MinValue;
                }
                
            }
        }

        public string ProductTypeName
        {
            get
            {
                if (ProductType != null)                
                    return Sitecore.Context.Database.GetItem(new ID(ProductType)).Name;                
                else
                    return "";

            }
        }
        public string ProductClassName
        {
            get
            {
                if (ProductClass != null)
                    return Sitecore.Context.Database.GetItem(new ID(ProductClass)).Name;
                else
                    return "";

            }
        }

    }
}