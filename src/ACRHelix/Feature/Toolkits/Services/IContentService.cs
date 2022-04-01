using ACRHelix.Feature.Toolkits.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Toolkits.Services
{
    public interface IContentService
    {
        IPfccToolkit GetPfccToolkitContent(string contentGuid);

        IPfccToolkit GetPfccToolkitFormContent(string contentGuid);

        IPfccToolkit GetMesoToolkitContent(string contentGuid);

        ISignupWithEmail GetSignupWithEmailContent(string contentGuid);

        IMediaItemList GetMesoFilesContent(string contentGuid);

        string CreateMediaItem(IPfccMediaItem mediaItem);
        string CreateMesoMediaItem(IPfccMediaItem mediaItem);

  }
}