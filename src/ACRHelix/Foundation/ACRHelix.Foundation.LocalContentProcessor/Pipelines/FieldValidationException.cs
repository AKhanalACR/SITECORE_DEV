using System;
using System.Runtime.Serialization;

namespace Sitecore.ExperienceEditor.Speak.Server.Requests
{
  [Serializable]
  internal class FieldValidationException : Exception
  {
    public FieldValidationException()
    {
    }

    public FieldValidationException(string message) : base(message)
    {
    }

    public FieldValidationException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected FieldValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
  }
}