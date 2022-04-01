using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using ACR.Library.Common;
using ACR.Library.Radpac.CustomItems.Radpac.Components;
using ACR.Library.Radpac.Data;
using ACR.Library.Reference;
using Common.Logging;
using PledgeSubmissionsDataContext = ACR.Library.Radpac.Data.PledgeSubmissionsDataContext;
namespace ACR.Library.Radpac.Data
{
    public static class DataHelper
    {
        private static ILog _logger;

        private static ILog Logger
        {
            get
            {
                _logger = _logger ?? LogManager.GetLogger(typeof(DataHelper));
                return _logger;
            }
        }

        private static string ConvertToCsv(DataTable dataTableToExport)
        {
            Deliminator deliminator = new Deliminator(",");

            String csv = deliminator.Deliminate(dataTableToExport);

            return csv;
        }

        private static DataTable LinqToDataTable<T>(IEnumerable<T> varlist)
        {
            DataTable dtReturn = new DataTable();
            // column names 
            PropertyInfo[] oProps = null;
            if (varlist == null) return dtReturn;

            foreach (T rec in varlist)
            {
                // Use reflection to get property names, to create table, Only first time, others will follow 
                if (oProps == null)
                {
                    oProps = ((Type)rec.GetType()).GetProperties();
                    foreach (PropertyInfo pi in oProps)
                    {
                        Type colType = pi.PropertyType;

                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }
                        if (colType == typeof(DateTime))
                            colType = typeof(String);
                        dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
                    }
                }

                DataRow dr = dtReturn.NewRow();

                foreach (PropertyInfo pi in oProps)
                {
                    if (pi.PropertyType == typeof(DateTime))
                    {
                        try
                        {
                            DateTime dttm = Convert.ToDateTime(pi.GetValue(rec, null));
                            dr[pi.Name] = dttm.ToShortDateString() + " " + dttm.ToString("hh:mm tt");
                        }
                        catch
                        {
                            dr[pi.Name] = String.Empty;
                        }
                    }
                    else
                    {
                        dr[pi.Name] = pi.GetValue(rec, null) ?? DBNull.Value;
                    }

                }

                dtReturn.Rows.Add(dr);
            }
            return dtReturn;
        }

        public static DataTable ToDataTable<T>(List<T> data)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            int propCount = props.Count - 6; //clearing out sitecore only properties
            for (int i = 0; i < propCount; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            object[] values = new object[propCount];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }

        public static string GetPledgeSubmissions()
        {
            DataTable dataTableToExport;
            Logger.Info("Start getting Pledge Submissions");
            try
            {
                using (PledgeSubmissionsDataContext db = new PledgeSubmissionsDataContext())
                {
                    Logger.Info("Data Context connection string: " + db.Connection.ConnectionString);
                    var results = from p in db.PledgeSubmissions
                                  select new
                                             {
                                                 p.ID,
                                                 p.First_Name,
                                                 p.Last_Name,
                                                 p.Email,
                                                 p.Profession_Role,
                                                 p.Primary_Institution,
                                                 p.Country_of_Practice,
                                                 p.Primary_Practice_Type,
                                                 p.How_Learned_About_Image_Wisely,
                                                 p.Contact_With_Updates,
                                                 p.Participate_in_Follow_Up_Survey,
                                                 p.SubmissionEmailedTo,
                                                 p.TimeSubmitted,
                                                 p.Status
                                             };
                    dataTableToExport = LinqToDataTable(results);
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Could not get PledgeSubmissionsDataContext, or the table PledgeSubmissions from that context.", ex);
                return "";
            }
            Logger.Info("End getting Pledge Submissions");
            return ConvertToCsv(dataTableToExport);
        }

				public static string GetReferringPractitionerPledgeSubmissions()
				{
					DataTable dataTableToExport;
					Logger.Info("Start getting Referring Practitioner Pledge Submissions");
					try
					{
						using (PledgeSubmissionsDataContext db = new PledgeSubmissionsDataContext())
						{
							Logger.Info("Data Context connection string: " + db.Connection.ConnectionString);
							var results = from p in db.ReferringPractitionerPledgeSubmissions
														select new
														{
															p.ID,
															p.First_Name,
															p.Last_Name,
															p.Email,
															p.Profession_Role,
															p.Primary_Institution,
															p.Country_of_Practice,
															p.Primary_Practice_Type,
															p.How_Learned_About_Image_Wisely,
															p.Contact_With_Updates,
															p.Participate_in_Follow_Up_Survey,
															p.SubmissionEmailedTo,
															p.TimeSubmitted,
															p.Status
														};
							dataTableToExport = LinqToDataTable(results);
						}
					}
					catch (Exception ex)
					{
						Logger.Error("Could not get PledgeSubmissionsDataContext, or the table ReferringPractitionerPledgeSubmissions from that context.", ex);
						return "";
					}
					Logger.Info("End getting Referring Practitioner Pledge Submissions");
					return ConvertToCsv(dataTableToExport);
				}

				public static string GetAssociationPledgeSubmissions()
				{
					DataTable dataTableToExport;
					Logger.Info("Start getting Association Pledge Submissions");
					try
					{
						using (PledgeSubmissionsDataContext db = new PledgeSubmissionsDataContext())
						{
							Logger.Info("Data Context connection string: " + db.Connection.ConnectionString);
							var results = from p in db.AssociationPledgeSubmissions
														select new
														{
															p.ID,
															p.Association,
															p.City,
															p.State,
															p.Country,
															p.First_Name,
															p.Last_Name,
															p.Title,
															p.Email,
															p.TimeSubmitted,
															p.SubmissionEmailedTo,
															p.Status
														};
							dataTableToExport = LinqToDataTable(results);
						}
					}
					catch (Exception ex)
					{
						Logger.Error("Could not get PledgeSubmissionsDataContext, or the table AssociationPledgeSubmissions from that context.", ex);
						return "";
					}
					Logger.Info("End getting Association Pledge Submissions");
					return ConvertToCsv(dataTableToExport);
				}

				public static string GetFacilityPledgeSubmissions()
				{
					DataTable dataTableToExport;
					Logger.Info("Start getting Facility Pledge Submissions");
					try
					{
						using (PledgeSubmissionsDataContext db = new PledgeSubmissionsDataContext())
						{
							Logger.Info("Data Context connection string: " + db.Connection.ConnectionString);
							var results = from p in db.FacilityPledgeSubmissions
														select new
														{
															p.ID,
															p.Facility,
															p.City,
															p.State,
															p.Country,
															p.First_Name,
															p.Last_Name,
															p.Title,
															p.Email,
															p.TimeSubmitted,
															p.SubmissionEmailedTo,
															p.Status
														};
							dataTableToExport = LinqToDataTable(results);
						}
					}
					catch (Exception ex)
					{
						Logger.Error("Could not get PledgeSubmissionsDataContext, or the table FacilityPledgeSubmissions from that context.", ex);
						return "";
					}
					Logger.Info("End getting Facility Pledge Submissions");
					return ConvertToCsv(dataTableToExport);
				}

        public static int GetPledgeCount()
        {
            Logger.Info("Start getting Pledge Count");
            int pledgeCount = 0;
            try
            {
                using (PledgeSubmissionsDataContext db = new PledgeSubmissionsDataContext())
                {
                    Logger.Info("Data Context connection string: " + db.Connection.ConnectionString);
                    pledgeCount = db.PledgeSubmissions.Count();
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Could not get PledgeSubmissionsDataContext, or the table PledgeSubmissions from that context.", ex);
                return 0;
            }
            Logger.Info("End getting Pledge Count");
            return pledgeCount;
        }

				public static bool IsDuplicateSubmission(string emailAddr, PledgeTypeItem pledgeTypeItem)
        {
					string typeId = pledgeTypeItem.ID.ToString();
					using (PledgeSubmissionsDataContext db = new PledgeSubmissionsDataContext())
					{
						if (ItemReference.IW_Global_PledgeFormType_Association != null &&
						    typeId == ItemReference.IW_Global_PledgeFormType_Association.Guid)
						{
							//Association table
							AssociationPledgeSubmission pledgeSubmission =
							db.AssociationPledgeSubmissions.Where(p => p.Email == emailAddr).FirstOrDefault();
							return (pledgeSubmission != null);
						}
						else if (ItemReference.IW_Global_PledgeFormType_Facility != null &&
						         typeId == ItemReference.IW_Global_PledgeFormType_Facility.Guid)
						{
							//Facility
							FacilityPledgeSubmission pledgeSubmission =
							db.FacilityPledgeSubmissions.Where(p => p.Email == emailAddr).FirstOrDefault();
							return (pledgeSubmission != null);
						}
						else if (ItemReference.IW_Global_PledgeFormType_ReferringProvider != null &&
						         typeId == ItemReference.IW_Global_PledgeFormType_ReferringProvider.Guid)
						{
							//Referring Provider/Practitioner
							ReferringPractitionerPledgeSubmission pledgeSubmission =
							db.ReferringPractitionerPledgeSubmissions.Where(p => p.Email == emailAddr).FirstOrDefault();
							return (pledgeSubmission != null);
						}
						else
						{
							//Imaging Professional
							PledgeSubmission pledgeSubmission =
							db.PledgeSubmissions.Where(p => p.Email == emailAddr).FirstOrDefault();
							return (pledgeSubmission != null);
						}

						
					}
        }
    }
}
