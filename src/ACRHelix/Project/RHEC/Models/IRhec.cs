using ACRHelix.Foundation.Model;
using System;

namespace RHEC.Website.Models
{
  public interface IRhec : ICMSEntity
  {
    Guid Id { get; set; }
    string Title { get; set; }
  }
}