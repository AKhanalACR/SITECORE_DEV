using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace ACR.Foundation.Personify.Constants
{
  public struct ItemConstants
  {
    //these are the folders for taxonomy data, these should never change, only the child items will up updated

    public struct ProductFolders
    {
      public static ID ProductRoot = new ID("{F60C2402-92F0-4F82-90B0-4328770930A3}");
    }

    public struct TaxonomyFolders
    {
      public static ID TaxonomyRoot = new ID("{7B1D6D4B-2126-46DB-B4BE-C91C5B904EEE}");

      public static ID CommitteeRoot = new ID("{64630969-74E0-40CF-9611-887B4B48BA47}");

      public static ID ChaptersRoot = new ID("{B0386844-1D06-4F98-88BC-156CBF4BBD76}");

      public static ID ABRCodes = new ID("{29054777-C4CB-4777-996B-C49C4D0119DE}");

      public static ID CreditTypes = new ID("{E3599077-431D-43EE-89EF-87A435D4D227}");

      public static ID DeliveryMethods = new ID("{0FE4A712-0A70-4C77-8DA5-56C05F39090C}");

      public static ID Interests = new ID("{9E754C9D-9462-401B-AF54-15C461EDD99A}");

      public static ID Modalities = new ID("{A97D8225-EEF8-4C41-ADB8-190FB2058392}");

      public static ID ProductArea = new ID("{EEE414CD-DA31-43CC-AA19-E33DB691C138}");

      public static ID ProductClass = new ID("{5199A649-3894-46FE-8AF7-1ADC4BBAE276}");

      public static ID ProductTypes = new ID("{111FBF6D-3622-4C55-B71B-23F9496D549A}");

      public static ID Roles = new ID("{161E7722-6CC6-4D74-A102-999B3839A6E9}");

      public static ID Subspecialties = new ID("{8428CBFC-8B4D-4B2B-9415-3CC90067A6FC}");

      public static ID Topics = new ID("{4DE397EF-6D59-442C-A37A-F2067CB8518E}");

      public static ID RLIPersonifyFolder = new ID("{706D3DD5-A05D-4C30-B25F-8687B5204944}");
    }
  }

  public struct Templates
  {
    public struct AcrProtectedContent
    {
      public static ID ID = new ID("{C474EE7D-3B0C-483F-A578-8EF892A20F50}");

      public struct Fields
      {
        public static ID RequiredAccess = new ID("{4B7D4EE8-08C5-4D67-ADBB-73F85DB8E3AC}");
        public static ID RequiredProducts = new ID("{15FF3836-BC90-4F46-80FB-97F5BC177949}");
        public static ID RequiredRoles = new ID("{2CBA3E56-53E1-4D03-BC65-B21E28A0F467}");
        public static ID InheritFromParent = new ID("{66591E51-E10C-4C47-AF03-A1C31BF76844}");
      }

      public struct RequiredAccess
      {
        public const string None = "None";
        public const string AuthenticationRequired = "Authentication Required";
        public const string ACRMembershipRequired = "ACR Membership Required";
      }
    }
  

   
  }
  
}