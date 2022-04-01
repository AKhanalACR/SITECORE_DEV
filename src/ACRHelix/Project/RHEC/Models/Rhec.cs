using System;

namespace RHEC.Website.Models
{
  public class Rhec : IRhec
  {
    public Guid Id { get; set; }
    public string Title { get; set; }
  }
}