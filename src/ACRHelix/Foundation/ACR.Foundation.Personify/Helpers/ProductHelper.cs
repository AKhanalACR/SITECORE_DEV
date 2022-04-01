using ACR.Foundation.Personify.MeetingSearch;
using ACR.Foundation.Personify.Models.Products;
using ACR.Foundation.Personify.Models.Taxonomy;
using ACR.Foundation.Personify.Settings;
using Sitecore.Sites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACR.Foundation.Personify.Helpers
{
  public static class ProductHelper
  {
    public static string GetDisplayName(this PersonifyTaxonomyItem taxonomy)
    {
      string name = string.Empty;
      if (taxonomy != null)
      {
        name = taxonomy.DisplayName;
      }
      return name;
    }

    public enum StockStatusEnum
    {
      InStock,
      SoldOut,
      Available,
      WaitList,
      Full,
      BackOrder,
      NA
    }

    public static string BuildProductImageUrl(string productImage)
    {
      return ACRSettings.AcrShopUrl + ACRSettings.AcrImagePath + productImage;
    }

    public static string GetProductSubsytem(this ProductStubItem productStub)
    {
      return productStub.Parent.Parent.Name;
    }

    public static string GetRLISubCode(this Personify.Models.Taxonomy.RLI.RLIPersonifySubCode code)
    {
      string value = string.Empty;
      if (code != null)
      {
        value = code.Description;
        string option1 = code.Option1;

        if (!string.IsNullOrWhiteSpace(option1))
        {
          value = option1;
        }
        if (string.IsNullOrWhiteSpace(value))
        {
          value = code.SubCode;
        }
      }
      return value;
    }

    public static string GetStockStatusText(this ProductStubItem productStub)
    {
      return GetStockStatusText(productStub.GetStockStatusEnum());
    }

    public static string GetStockStatusText(StockStatusEnum status)
    {
      string stockStatusText = string.Empty;

      switch (status)
      {
        case StockStatusEnum.Available:
          stockStatusText = "Available";
          break;
        case StockStatusEnum.InStock:
          stockStatusText = "In Stock";
          break;
        case StockStatusEnum.WaitList:
          stockStatusText = "Waitlist";
          break;
        case StockStatusEnum.Full:
          stockStatusText = "Full";
          break;
        case StockStatusEnum.SoldOut:
          stockStatusText = "Sold Out";
          break;
        case StockStatusEnum.BackOrder:
          stockStatusText = "Backordered";
          break;
        default:
          break;
      }

      return stockStatusText;
    }

    public static string GetStockStatusCssClass(this ProductStubItem productStub)
    {
      return GetStockStatusCssClass(productStub.GetStockStatusEnum());
    }

    public static string GetStockStatusCssClass(StockStatusEnum stockStatus)
    {
      string cssClass = string.Empty;

      switch (stockStatus)
      {
        case StockStatusEnum.InStock:
        case StockStatusEnum.Available:
          cssClass = " stock";
          break;
        case StockStatusEnum.SoldOut:
        case StockStatusEnum.Full:
          cssClass = " sold";
          break;
        case StockStatusEnum.WaitList:
        case StockStatusEnum.BackOrder:
          cssClass = " waitlist";
          break;
        default:
          break;
      }
      return cssClass;
    }

    public static StockStatusEnum GetStockStatusEnum(string stockStatusValue)
    {
      StockStatusEnum stockStatus = StockStatusEnum.NA;

      switch (stockStatusValue.ToLower())
      {
        case "in stock":
        case "in_stock":
        case "instock":
          stockStatus = StockStatusEnum.InStock;
          break;
        case "out of stock":
        case "out_of_stock":
        case "outofstock":
          stockStatus = StockStatusEnum.SoldOut;
          break;
        case "available":
          stockStatus = StockStatusEnum.Available;
          break;
        case "wait list":
        case "wait_list":
        case "waitlist":
          stockStatus = StockStatusEnum.WaitList;
          break;
        case "full":
          stockStatus = StockStatusEnum.Full;
          break;
        case "back_order":
        case "backorder":
        case "back order":
          stockStatus = StockStatusEnum.BackOrder;
          break;
        default:
          stockStatus = StockStatusEnum.NA;
          break;
      }
      return stockStatus;
    }

    public static StockStatusEnum GetStockStatusEnum(this ProductStubItem productStub)
    {
      return GetStockStatusEnum(productStub.StockStatus);
    }

    public static bool ProductHasMeetingUrl(this ProductStubItem product)
    {
      if (product.ProductIsMeetingOrCourse())
      {
        //probably just care about published web db meetings
        MeetingSearchManager meetingSearcher = new MeetingSearchManager(MeetingSearchManager.IndexEnum.Web);
        var meeting = meetingSearcher.GetMeetings(product.ID).FirstOrDefault();
        if (meeting != null)
        {
          return true;
        }
      }
      return false;
    }

    public static string GetProductPersonifyUrl(this ProductStubItem product)
    {    
      if (product.ProductIsAcrMeeting())
      {
        return product.MeetingRegistrationFormUrl;
      }
      if (product.ProductIsEducationCenterMeeting())
      {
        return ACRSettings.CourseMeetingUrlRoot + "&ProductId=" + product.PersonifyID;
      }
      return ACRSettings.ProductUrlRoot + "&ProductId=" + product.PersonifyID;
    }

    public static string GetProductDetailUrl(this ProductStubItem product)
    {
      if (product.ProductIsMeetingOrCourse())
      {
        //probably just care about published web db meetings
        MeetingSearchManager meetingSearcher = new MeetingSearchManager(MeetingSearchManager.IndexEnum.Web);
        var meeting = meetingSearcher.GetMeetings(product.ID).FirstOrDefault();
        if (meeting != null)
        {
          var meetingItem = meeting.GetItem();
          if (meetingItem != null)
          {
          
              return FixLink(Sitecore.Links.LinkManager.GetItemUrl(meetingItem));
            
          }
        }
      }
      if (product.ProductIsAcrMeeting())
      {
        return product.MeetingRegistrationFormUrl;
      }
      if (product.ProductIsEducationCenterMeeting())
      {
        return ACRSettings.CourseMeetingUrlRoot + "&ProductId=" + product.PersonifyID;
      }
      return ACRSettings.ProductUrlRoot + "&ProductId=" + product.PersonifyID;
    }

    public static string GetProductMeetingType(this ProductStubItem product)
    {
      if (product.ProductIsMeetingOrCourse())
      {
        MeetingSearchManager meetingSearcher = new MeetingSearchManager(MeetingSearchManager.IndexEnum.Web);
        var meeting = meetingSearcher.GetMeetings(product.ID).FirstOrDefault();
        if (meeting != null)
        {
          if (!string.IsNullOrWhiteSpace(meeting.MeetingType))
          {
            string meetingType = meeting.MeetingType;
            switch (meeting.MeetingType)
            {
              case "ACR":
                meetingType = "ACR Meeting";
                break;
              case "Education Center":
                meetingType = "Education Center Course";
                break;
              default:
                break;
            }
            return meetingType;
          }
        }
        if (product.ProductClass != null)
        {
          if (product.ProductClass.DisplayName == "ACR")
          {
            return "ACR Meeting";
          }
          else if (product.ProductClass.DisplayName == "RLI" || product.ProductClass.DisplayName == "AIRP")
          {
            return product.ProductClass.DisplayName;
          }

          //else if(!string.IsNullOrWhiteSpace(product.ProductClass.DisplayName))
          //{
          //  return product.ProductClass.DisplayName;
          //}        
        }
      }
      return null;
    }

    public static bool ProductBuyNow(this ProductStubItem product)
    {
      return !product.ProductIsMeetingOrCourse();
    }

    public static bool ProductIsEducationCenterMeeting(this ProductStubItem productStub)
    {
      return productStub.ProductIsMeetingOrCourse() && string.IsNullOrWhiteSpace(productStub.MeetingRegistrationFormUrl);
    }

    public static bool ProductIsAcrMeeting(this ProductStubItem productStub)
    {
      return productStub.ProductIsMeetingOrCourse() && !string.IsNullOrWhiteSpace(productStub.MeetingRegistrationFormUrl);
    }

    public static bool ProductIsMeetingOrCourse(this ProductStubItem productStub)
    {
      if (productStub.ProductArea != null)
      {
        return productStub.ProductArea.PersonifyID == "MTG";
      }
      return false;
    }

    private static string FixLink(string link)
    {
      string match = "/sitecore/shell/ACR";
      int index = link.IndexOf(match, StringComparison.OrdinalIgnoreCase);
      if (index == 0)
      {
        link = link.Substring(match.Length);
      }
      return link;
    }
  }
}