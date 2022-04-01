using ACRHelix.Feature.IdeasContent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.IdeasContent.Services
{
    public interface IContentService
    {
        IIdeasPageContent GetIdeasPageContentContent(string contentGuid);

        IIdeasRichText GetIdeasRichTextContent(string contentGuid);

        Models.IdeasSelectedLinks GetSelectedLinksContent(string contentGuid);

        Models.IdeasMapWidget GetMapWidgetContent(string contentGuid);
    Models.IdeasMapWidgetText GetMapWidgetTextContent(string contentGuid);

    IIdeasMapDetails GetMapDetailsContent(string contentGuid);

        Models.IdeasHero GetIdeasHeroContent(string contentGuid);
        Models.IdeasPatientTitleTilesButton GetIdeasPatientTilesContent(string contentGuid);
      IdeasTextImageSection GetTextImageContent(string contentGuid);
    Models.IdeasPatientTitle2Column IdeasPatientTitleTwoColumn(string contentGuid);
    Models.IdeasPatientTwoImagesColumn IdeasPatientTwoImagesColumn(string contentGuid);
  }
}