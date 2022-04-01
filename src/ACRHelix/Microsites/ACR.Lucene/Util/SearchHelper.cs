#region Usings

using System.Collections.Generic;
using Lucene.Net.Documents;
using Sitecore.Data;
using Sitecore.Search;
using Sitecore.Data.Items;
using Sitecore.Collections;
using System;
using System.Linq;

#endregion

namespace ACR.Lucene.Util
{
   public class SearchHelper
   {
      public static string FormatNumber(int number)
      {
         return number.ToString().PadLeft(int.MaxValue.ToString().ToCharArray().Count(), '0');
      }

      public static List<Item> GetItemListFromInformationCollection(List<LightweightItem> skinnyItems)
      {
         return skinnyItems.Select(skinnyItem => skinnyItem.GetItem()).ToList();
      }

      public static SafeDictionary<string> CreateFilters(string fieldName, string fieldValue)
      {
         var filters = new SafeDictionary<string>();

         if (!String.IsNullOrEmpty(fieldValue) && !String.IsNullOrEmpty(fieldValue))
         {
            if (fieldName.Contains("|"))
            {
               var fieldNames = fieldName.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

               foreach (var name in fieldNames)
               {
                  filters.Add(name, fieldValue);
               }
            }
            else
            {
               filters.Add(fieldName, fieldValue);
            }
         }

         return filters;
      }

      public static void GetItemsFromSearchResult(IEnumerable<Document> searchResults, List<LightweightItem> items)
      {
         foreach (var result in searchResults)
         {
            var uriField = result.GetField(BuiltinFields.Url);
            if (uriField != null && !String.IsNullOrEmpty(uriField.StringValue))
            {
               var itemUri = new ItemUri(uriField.StringValue);

               var itemInfo = new LightweightItem(itemUri);

               foreach (Field field in result.GetFields())
               {
                  itemInfo.Fields[field.Name] = field.StringValue;
               }

               items.Add(itemInfo);
            }
         }
      }

      /// <summary>
      /// Converts SearchResultCollection object into List<Item> collection.
      /// </summary>
      /// <param name="searchResults">SearchResultCollection object.</param>
      /// <returns></returns>
      //public static List<Item> GetItemsFromSearchResult(SearchResultCollection searchResults)
      //{
      //   var resultingSet = new List<Item>();

      //   foreach (var result in searchResults)
      //   {
      //      var itemObject = SearchManager.GetObject(result);

      //      if (itemObject != null && itemObject is Item)
      //      {
      //         resultingSet.Add(itemObject as Item);
      //      }
      //   }

      //   return resultingSet;
      //}

      //public static List<T> GetItemsFromSearchResult<T>(SearchResultCollection searchResults) where T : class
      //{
      //   var resultingSet = new List<T>();

      //   foreach (var result in searchResults)
      //   {
      //      var itemObject = SearchManager.GetObject(result);

      //      if (itemObject != null && itemObject is Item)
      //      {
      //         var item = itemObject as Item;
      //         // This is not gonna work unless T type is derived from "item"'s type.
      //         T source = (T)(object)item;
      //         resultingSet.Add(source);
      //      }
      //   }

      //   return resultingSet;
      //}
   }
}
