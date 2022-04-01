namespace ACR.Foundation.Personify.Models.Taxonomy.RLI.Data
{
  public class SubCode
  {
    public SubCode(PersonifyDS.PdsApplicationSubcode subcode)
    {
      CodeName = subcode.Code;
      SubCodeName = subcode.Subcode;
      Active = subcode.ActiveFlag ?? false;
      Description = subcode.Description;
      Option2 = subcode.Option2;
      AvailableToWeb = subcode.AvailableToWebFlag ?? false;
      DisplayOrder = subcode.DisplayOrder ?? 0;
      Option1 = subcode.Option1;
    }

    public string CodeName { get; set; }
    public string SubCodeName { get; set; }
    public bool Active { get; set; }
    public string Description { get; set; }
    public string Option1 { get; set; }
    public string Option2 { get; set; }
    public bool AvailableToWeb { get; set; }
    public int DisplayOrder { get; set; }
  }
}