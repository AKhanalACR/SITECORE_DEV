using ACR.Foundation.Personify.Helpers;
using ACR.Foundation.Personify.ProductSearch;
using ACR.Foundation.Personify.Services;
using ACR.Foundation.PersonifyCartService.Models;
using ACR.Foundation.SSO.Users;
using Newtonsoft.Json;
using System.Linq;

using System.Web.Mvc;
using ACR.Foundation.Personify.Settings;

namespace ACR.Foundation.PersonifyCartService
{
  public class PersonifyCartApiController : Controller
  {
    private SitecoreContentService _contentService;
    private ProductSearchManager _productSearchManger;


    public PersonifyCartApiController()
    {
      _contentService = new SitecoreContentService();
      _productSearchManger = new ProductSearchManager(ProductSearchManager.IndexEnum.Web);
    }

    [HttpPost]
    public ActionResult SaveForLater(string id)
    {
      var cartResult = new AddCartResult();
      ProductSearchResult product = _productSearchManger.GetProducts(id).FirstOrDefault();
      if (product != null)
      {
        var productStub = _contentService.GetProductStub(product.ItemId);
        if (productStub != null)
        {
          if (UserManager.CurrentUserContext.AddToCart(productStub, true))
          {
            cartResult.Added = true;
            cartResult.Result = string.Format("product {0} has been saved for later", productStub.PersonifyID);
            cartResult.ProductId = productStub.PersonifyID;
            cartResult.ProductImageUrl = ProductHelper.BuildProductImageUrl(productStub.ImageLargeUrl);
            cartResult.ProductName = productStub.LongName;
            cartResult.UnitPrice = productStub.ListPrice;
            cartResult.Quantity = 1;
            cartResult.CartUrl = ACRSettings.ShoppingCartUrl;
          }
          else
          {
            cartResult.Result = "Error adding product to cart";
          }
        }
      }
      string json = JsonConvert.SerializeObject(cartResult, Formatting.Indented);
      return Content(json, "application/json");
    }

    [HttpPost]
    public ActionResult GetShoppingCartCount()
    {
      var count = UserManager.CurrentUserContext.GetCartOrderLineCount();
      return Content(JsonConvert.SerializeObject(new CartCountResult() { CartCount = count}, Formatting.Indented), "application/json");
    }

    [HttpPost]
    public ActionResult AddProductToCart(string id)
    {
      var cartResult = new AddCartResult();
      //string id = "731499117";
      ProductSearchResult product = _productSearchManger.GetProducts(id).FirstOrDefault();
      if (product != null)
      {
        var productStub = _contentService.GetProductStub(product.ItemId);
        if (productStub != null)
        {
          if (UserManager.CurrentUserContext.AddToCart(productStub))
          {
            cartResult.Added = true;
            cartResult.Result = string.Format("product {0} added to cart", productStub.PersonifyID);
            cartResult.ProductId = productStub.PersonifyID;
            cartResult.ProductImageUrl = ProductHelper.BuildProductImageUrl(productStub.ImageLargeUrl);
            cartResult.ProductName = productStub.LongName;
            cartResult.UnitPrice = productStub.ListPrice;
            cartResult.Quantity = 1;
            cartResult.CartUrl = ACRSettings.ShoppingCartUrl;
          }
          else
          {
            cartResult.Result = "Error adding product to cart";
          }
        }
      }
      else
      {
        cartResult.Result = "error product does not exist";
      }
      string json = JsonConvert.SerializeObject(cartResult, Formatting.Indented);
      return Content(json, "application/json");
    }
  }
}