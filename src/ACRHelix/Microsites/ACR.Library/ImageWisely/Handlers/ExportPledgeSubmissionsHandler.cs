using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using ACR.Library.ImageWisely.CustomItems.ImageWisely.Components;
using ACR.Library.ImageWisely.CustomItems.ImageWisely.Pages;
using ACR.Library.ImageWisely.Data;
using ACR.Library.Reference;
using Common.Logging;
using Sitecore.Data;
using Sitecore.Data.Items;

namespace ACR.Library.ImageWisely.Handlers
{
    public class ExportPledgeSubmissionsHandler : IHttpHandler
    {
        private static ILog _logger;

        private static ILog Logger
        {
            get
            {
                _logger = _logger ?? LogManager.GetLogger(typeof(ExportPledgeSubmissionsHandler));
                return _logger;
            }
        }
        public static string Url = "/ExportPledgeSubmissions.axd";

        public void ProcessRequest(HttpContext context)
        {
            string id = context.Request["id"];
            Database db = Sitecore.Configuration.Factory.GetDatabase("master");
						if (id == null)
						{
							Logger.Error("Pledge submissions export request: Cannot get Pledge item. Context ID is null");
						}
						else
						{
							ID itemId = new ID(id);
							Item item = db.GetItem(itemId);
                            PledgeTypeItem pledgeTypeItem = null;

                            if (item != null)
							{
								Logger.Debug("Pledge item requesting export of submissions: " + item.Name);
								if (item.TemplateID.ToString() != PledgeFormItem.TemplateId)
								{
                                    var innerItem = item.Axes.GetDescendants().Where(t => t.TemplateID == new ID("{DB922FDE-1352-42F5-BB64-D5168C3B5813}")).SingleOrDefault();
                                    if (innerItem != null)
                                    {
                                        pledgeTypeItem = CustomFieldLookup(db, innerItem.Fields["Pledge Form Type"].Source, innerItem.Fields["Pledge Form Type"].Value);
                                    }
                                    else
                                    {
                                        Logger.Error("Pledge submissions export request: Context item is not a Pledge item. Item Name: " + item.Name);
                                        return;
                                    }                         
								}
									
								PledgeFormItem formItem = item;                               
                                if (pledgeTypeItem == null)
								    pledgeTypeItem = formItem.PledgeFormType.Item;

                                if (pledgeTypeItem == null) /*formItem.PledgeFormType.Item*/
                                {
                                    Logger.Error("Pledge submissions export request: Context item is a Pledge item, but does not have a Pledge Type selected. Item Name: " + item.Name);
                                    return;
                                }

                                //PledgeTypeItem pledgeTypeItem = formItem.PledgeFormType.Item;
                                string typeId = pledgeTypeItem.ID.ToString();
								string pledgeTypeName = pledgeTypeItem.Name;
								string csv = "";

								if (ItemReference.IW_Global_PledgeFormType_Association != null &&
									typeId == ItemReference.IW_Global_PledgeFormType_Association.Guid)
								{
									//Association table
									csv = DataHelper.GetAssociationPledgeSubmissions();
								}
								else if (ItemReference.IW_Global_PledgeFormType_Facility != null &&
									typeId == ItemReference.IW_Global_PledgeFormType_Facility.Guid)
								{
									//Facility
									csv = DataHelper.GetFacilityPledgeSubmissions();
								}
								else if (ItemReference.IW_Global_PledgeFormType_ReferringProvider != null &&
									typeId == ItemReference.IW_Global_PledgeFormType_ReferringProvider.Guid)
								{
									//Referring Provider/Practitioner
									csv = DataHelper.GetReferringPractitionerPledgeSubmissions();
								}
								else
								{
									//Imaging Professional
									csv = DataHelper.GetPledgeSubmissions();
								}
								
								Logger.Info(item.Name + " submissions csv string length: " + csv.Count());
								string fileName = "ImageWisely-" + pledgeTypeName + "-Pledge-Submissions-" + DateTime.Now.ToString("yyyyMMdd");

								String attachment = String.Format("attachment; filename={0}.{1}", fileName, "csv");
								context.Response.Clear();
								context.Response.ClearHeaders();
								context.Response.ClearContent();
								//Set encoding to Windows Latin-1 (codepage 1252) for proper Excel formatting
								context.Response.ContentEncoding = Encoding.GetEncoding(1252);
								context.Response.ContentType = "text/csv";
								context.Response.AddHeader("content-disposition", attachment);
								context.Response.Write(csv);
								context.Response.End();
							}
							else
							{
								Logger.Error("Pledge submissions export request: Cannot get Pledge item from HttpContext ID. ID = " + id);
							}
						}

        }

        public bool IsReusable
        {
            get { return false; }
        }

        private Item CustomFieldLookup(Database db, string source, string pledgeFormType)
        {
            Item pledgeType = db.GetItem(source).GetChildren().Where(i => i.Name == pledgeFormType).SingleOrDefault();
            return pledgeType;
        }

    }
}
