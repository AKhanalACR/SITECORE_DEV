using ACRHelix.Feature.Navigation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Navigation.Services
{
  public interface IContentService
  {
    ILinkMenu GetLinkMenuContent(string contentGuid);
    INavigationRoot GetMainNavigationContent();
    INavigationRoot GetNavigationContentByItem(string itemId);

    IBreadcrumbs GetBreadcrumbsContent(string contentGuid);

        IIWNavigationRoot GetIWMainNavigationContent();
        IBreadcrumbs GetIWBreadcrumbsContent(string contentGuid);

        IIWNavigationRoot GetIdeasMainNavigationContent();
    }
}