using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Login.ViewModels
{
  public class LoginViewModel : Models.Login
  {
    public LoginViewModel()
    {
    }

    public LoginViewModel(Models.Login login) : base(login)
    {
      
    }

    public string HiddenCaptcha { get; set; }

    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }

    public bool RememberMe { get; set; } = false;

    public bool LoginError { get; set; } = false;

    public string LoginErrorCSS
    {
      get
      {
        if (!LoginError)
        {
          return "display:none";
        }
        return "";
      }
    }
  }
}