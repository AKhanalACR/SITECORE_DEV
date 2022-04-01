using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using ACRHelix.Foundation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using Sitecore.Data;

namespace ACRHelix.Project.RadPAC.Models
{
    public class Login : ILogin
    {
        public Login() { }

        public Login(Login other)
        {
            Type log = typeof(Login);
            PropertyInfo[] props = log.GetProperties();
            foreach (var p in props)
            {
                p.SetValue(this, p.GetValue(other));
            }
        }

        public virtual ID Id { get; set; }

        public virtual string Title { get; set; }

        public virtual string SubTitle { get; set; }

        public virtual Link NeedHelpLink { get; set; }

        public virtual Link ForgotPasswordLink { get; set; }

        public virtual string RichText { get; set; }

        public virtual Link CreateAccountLink { get; set; }

        public virtual string LoginErrorMessage { get; set; }

    }
}