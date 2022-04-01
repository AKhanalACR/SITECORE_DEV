using Lucene.Net.Documents;

namespace ACR.Lucene.Util
{
   public class SearchField
   {
      public SearchField()
      {
      }

      public SearchField(string storageType, string indexType, string vectorType, string boost)
      {
         SetStorageType(storageType);
         SetIndexType(indexType);
         SetVectorType(vectorType);
         SetBoost(boost);
      }

      #region Public Properties

			public Field.Store StorageType { get; set; }

      public Field.Index IndexType { get; set; }

      public Field.TermVector VectorType { get; set; }

      public float Boost { get; set; }

      #endregion

      #region Setters

      public void SetStorageType(string storageType)
      {
         switch (storageType)
         {
            case "YES":
               {
                  StorageType = Field.Store.YES;
                  break;
               }
            case "NO":
               {
                  StorageType = Field.Store.NO;
                  break;
               }
            case "COMPRESS":
               {
                  StorageType = Field.Store.YES;
                  break;
               }
            default:
               break;
         }
      }

      public void SetIndexType(string indexType)
      {
         switch (indexType)
         {
            case "NO":
               {
                  IndexType = Field.Index.NO;
                  break;
               }
            case "NO_NORMS":
               {
                  IndexType = Field.Index.NOT_ANALYZED_NO_NORMS;
                  break;
               }
            case "TOKENIZED":
               {
                  IndexType = Field.Index.ANALYZED;
                  break;
               }
            case "UN_TOKENIZED":
               {
                  IndexType = Field.Index.NOT_ANALYZED_NO_NORMS;
                  break;
               }
            default:
               break;
         }
      }

      public void SetVectorType(string vectorType)
      {
         switch (vectorType)
         {
            case "NO":
               {
                  VectorType = Field.TermVector.NO;
                  break;
               }
            case "WITH_OFFSETS":
               {
                  VectorType = Field.TermVector.WITH_OFFSETS;
                  break;
               }
            case "WITH_POSITIONS":
               {
                  VectorType = Field.TermVector.WITH_POSITIONS;
                  break;
               }
            case "WITH_POSITIONS_OFFSETS":
               {
                  VectorType = Field.TermVector.WITH_POSITIONS_OFFSETS;
                  break;
               }
            case "YES":
               {
                  VectorType = Field.TermVector.YES;
                  break;
               }
            default:
               break;
         }
      }

      public void SetBoost(string boost)
      {
         float boostReturn;

         if (float.TryParse(boost, out boostReturn))
         {
            Boost = boostReturn;
         }

         Boost = 1;
      }

      #endregion
   }
}
