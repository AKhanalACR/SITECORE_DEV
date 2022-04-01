using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACR.Foundation.Utilities.Session
{
  public interface ISessionManager
  {
    T GetValue<T>(string key);
    object GetValue(string key);
    void SetValue(string key, object obj);
  }
}
