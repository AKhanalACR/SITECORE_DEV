using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Foundation.CustomCoveo
{
  public struct SitecoreConstants
  {
    public struct Templates
    {

      public struct ChapterMeeting
      {
        public const string TemplateID = "{54FC426B-53E5-4285-B8A6-07725D00B429}";

        public struct Fields
        {
          public const string MeetingTitle = "{8F0B3129-3B5F-4E75-8C6A-EB805A7D9050}";
          public const string StartDate = "{19A39E3B-B62A-4547-BB74-D86F2FDD5F10}";
          public const string EndDate = "{03DFB675-C94E-4BC3-B14B-01EEC1FDAD80}";
        }
      }

      public struct SocietyMeeting
      {
        public const string TemplateID = "{DE275A98-20B2-43B6-A3B3-9A159837057F}";

        public struct Fields
        {
          public const string MeetingTitle = "{8F0B3129-3B5F-4E75-8C6A-EB805A7D9050}";
          public const string SocietyName = "{2596F3E8-3CEE-4256-8C53-AE9C9A52C35E}";
          public const string StartDate = "{19A39E3B-B62A-4547-BB74-D86F2FDD5F10}";
          public const string EndDate = "{03DFB675-C94E-4BC3-B14B-01EEC1FDAD80}";
        }
      }

      public struct MeetingNoProductStub
      {
        public const string TemplateID = "{63E9A522-4173-4ECC-A0BC-52C0EEA7D241}";

        public struct Fields
        {
          public const string MeetingType = "{81B3E5E8-EA52-4AA5-B02E-09DDA233B48B}";
          public const string MeetingStartDate = "{F2AAA479-3273-4A41-908F-7FAF0EF51BE5}";
          public const string MeetingEndDate = "{02DBB1C3-0A32-4738-99EE-8425F8DF6263}";
        }
      }

      public struct MeetingOrCourse
      {
        public const string TemplateID = "{6C0A1097-31B1-4406-8922-D5D4BB9E8925}";

        public struct Fields
        {
          public const string Products = "{FBB0DEAC-8F2D-4BC6-A9B0-112C1057B44A}";
        }
      }

      public struct HasPageContent
      {
        public const string TemplateID = "{D7890554-C645-41C4-810B-0DB540324EF1}";
        public struct Fields
        {
          public const string Title = "{DF390237-372F-40BD-9419-EE9BA0F0C83D}";
          public const string SubTitle = "{901A4019-D702-4DBC-82FD-CD32B00DF273}";
          public const string RichText = "{5D712FBE-1F37-4F3C-B3E6-35CC5688AB5C}";
        }
      }

            public struct IdeasHasPageContent
            {
                public const string TemplateID = "{FD7904CD-8433-4310-8D9A-342729D5FA14}";
                public struct Fields
                {
                    public const string Title = "{F64AAD98-A0F4-4BC9-A018-DBAF091097F9}";
                    public const string SubTitle = "{A31B10B8-322A-436B-9177-E91CDA26F63E}";
                    public const string RichText = "{AD5EAA11-166E-48F6-B54E-5411A193CCAB}";
                    public const string IdeasDisplaySearchResults = "{F430FAAF-214A-44C8-9418-0418EC777D62}";
                }
            }
            public struct IdeasYoutubeVideoResources
            {
                public const string TemplateID = "{2EAD1608-9E8C-444F-AF66-766578E687F8}";
                public struct Fields
                {
                    public const string Title = "{66EE0701-A2AA-4235-8B54-6FA5D230F6C6}";
                    public const string SubTitle = "{B4046645-66DA-46D0-A3C4-7D1C14C7F5A9}";
                    public const string IsYoutubeVideo = "{B6ED88BE-5A7F-4BBF-A1BE-D435A978DC02}";
                }
            }
            //public struct IdeasOtherVideoResources
            //{
            //    public const string TemplateID = "{97021C60-4F16-47D3-B256-0D2AA6B10747}";
            //    public struct Fields
            //    {
            //        public const string Title = "{53943B68-1875-45C6-ABB9-81E35AB402F9}";
            //        public const string SubTitle = "{D95D2A49-675E-409B-8CD6-5E6D4DCCDE3F}";
            //        public const string IsVideo = "{FD169BFF-0123-4A55-A493-8088C60F8FC6}";

            //    }
            //}

            public struct TileContent
      {
        public const string TemplateID = "{8A90A5C2-CE1F-4117-82B1-392B42CABD8E}";
        public struct Fields
        {
          public const string TileText = "{E74D0264-754C-47BF-AD94-D3DFAAA9314E}";
        }
      }

      public struct MetaData
      {
        public const string TemplateID = "{4492C968-D3D5-401A-8792-7951960B2E24}";
        public struct Fields
        {
          public const string MetaDescription = "{8127ECE9-5B24-4C17-948C-D44CE9902371}";
        }
      }

      public struct ChapterNews
      {
        public const string TemplateID = "{CCC08FF8-7527-45E2-BEB7-6E9C6B70E087}";
        public struct Fields
        {
          public const string Date = "{D743A07B-7A9F-4DE9-A50B-7FF86DB39CD9}";
        }
      }

      public struct AccessandEntitlements
      {
        public const string TemplateID = "{C474EE7D-3B0C-483F-A578-8EF892A20F50}";
        public struct Fields
        {
          public const string DisplaySearchResults = "{A74141AE-844A-4F54-BE16-1432909001B9}";
        }
      }
      public struct Taxonomy
      {
        public struct Fields
        {
          public const string Interests = "{04A02384-9FA2-4F31-9119-DEF72149A072}";
          public const string Modailities = "{EB2BE46D-E0B1-4135-A4AD-82621684B9BF}";
          public const string Subspecialities = "{E751A12E-0D46-458F-A4B6-7378C0808CC9}";
        }
      }
      public struct ProductStub
      {
        public struct Fields
        {
          public const string IsRLICheckBox = "{A2BB2497-13E9-4637-96A9-828CED435E68}";
          public const string CreditType = "{0E4999A1-CD75-46C1-B1FD-15FEA1CBE270}";
          public const string DeliveryMethod = "{EBFB4E16-5BE3-44EB-BBE7-895E8B21A777}";
          public const string ProductClass = "{6FF99FD7-6B28-4550-82B7-3CFF62C8ED76}";
          public const string LargeImageUrl = "{6D71CDA6-CDD3-4581-AAF4-5FCD490AF8C8}";
          public const string MeetingEndDate = "{3055DBC3-CB19-487B-B23E-9199AFDC81E4}";
          public const string MeetingStartDate = "{7353E1E9-3C44-407F-AF24-1E99BF8E0A49}";
          public const string StockStatus = "{A50567E8-9086-445B-A274-0469A3245BB1}";
          public const string ProductType = "{1860CB72-1ADC-408B-8327-68E9482C89BA}";
          public const string WebDisplayEndDate = "{A81EA91B-6EF3-4C8D-939D-A6E90B0E20F3}";
          public const string WebDisplayStartDate = "{9E725FBC-6C6A-46D6-8CF7-0C0CC5CA2A18}";
          public const string LongName = "{BA108564-370C-4834-8335-A956BA0517F0}";
          public const string ShortDescription = "{A10DFC23-A546-427E-AC62-D4223863DA0E}";
        }
      }

      public struct NewsIssue
      {
        public const string TemplateID = "{DEA31E9E-89A7-4524-9D97-CED66286746F}";
      }

      public struct NewsItem
      {
        public const string TemplateID = "{CE0F48F7-65A2-4D60-BB97-0CBD290FAF7B}";
      }
    }
  }
}