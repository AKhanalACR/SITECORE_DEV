namespace ACR.Foundation.Personify.Models.Taxonomy.RLI.Data
{
  public class Code
  {
    public Code(PersonifyDS.PdsApplicationCode personifyCode)
    {
      CodeName = personifyCode.Code;
      Active = personifyCode.ActiveFlag ?? false;
      Description = personifyCode.Description;
      Option2 = personifyCode.Option2;
      HelpText = personifyCode.HelpText;
      AvailableToWeb = personifyCode.AvailableToWebFlag ?? false;
      DisplayOrder = personifyCode.DisplayOrder ?? 0;
    }

    public string CodeName { get; set; }
    public bool Active { get; set; }
    public string Description { get; set; }
    public string Option2 { get; set; }
    public string HelpText { get; set; }
    public bool AvailableToWeb { get; set; }
    public int DisplayOrder { get; set; }
  }
}