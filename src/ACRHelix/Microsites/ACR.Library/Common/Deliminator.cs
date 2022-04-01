using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ACR.Library.Common
{
    public class Deliminator
    {
        private readonly String _delimiter;

        private Func<string, string> StringPreparer
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Deliminator"/> class
        /// using the given string as the delimiter.  By default, this instance
        /// will prepare individual items by escaping the following characters:
        /// <c>"</c>, <c>delimiter</c>, <c>Environment.Newline</c>, and <c>
        /// <![CDATA[\n]]></c>
        /// </summary>
        /// <param name="delimiter"></param>
        /// <exception cref="ArgumentNullException">Delimiter is null</exception>
        public Deliminator(String delimiter)
        {
            if (delimiter == null)
            {
                throw new ArgumentNullException("delimiter");
            }

            _delimiter = delimiter;
            StringPreparer = DefaultPreparer;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Deliminator"/> class
        /// using the given string as the delimiter.  The <c>stringPreparer</c>
        /// delegate is used when preparing a delimited value.
        /// </summary>
        /// <param name="delimiter">The delimiter.</param>
        /// <param name="stringPreparer">The string preparer.</param>
        /// <exception cref="ArgumentNullException">delimiter is null</exception>
        /// <exception cref="ArgumentNullException">stringPreparer is null</exception>
        public Deliminator(string delimiter, Func<string, string> stringPreparer)
        {
            if (delimiter == null)
            {
                throw new ArgumentNullException("delimiter");
            }

            if (stringPreparer == null)
            {
                throw new ArgumentNullException("stringPreparer");
            }

            _delimiter = delimiter;
            StringPreparer = stringPreparer;
        }

        /// <summary>
        /// Retrieves the delimiter for this instance
        /// </summary>
        public String Delimiter
        {
            get { return _delimiter; }
        }

        /// <summary>
        /// Creates a deliminated string from the given data table.
        /// By default, the table column names are output with the 
        /// table data
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public String Deliminate(DataTable table)
        {
            return Deliminate(table, true);
        }

        ///<summary>
        /// Creates a deliminated string from the given data table, with the 
        /// option to include or not include the table column names in the
        /// first row
        ///</summary>
        ///<param name="table">The table to deliminate</param>
        ///<param name="includeColumnHeaders">if <c>true</c>, the table
        /// columns are output.  If <c>false</c>, the table colum names
        /// are not output</param>
        ///<returns>A deliminated string representing the table</returns>
        public String Deliminate(DataTable table, bool includeColumnHeaders)
        {
            // A null table or one without any columns produces an empty string
            if (table == null || table.Columns.Count == 0)
            {
                return String.Empty;
            }

            // Take a guess at the initial size of the resulting string
            int size = table.Columns.Count * table.Rows.Count * 8;
            StringBuilder delimited = new StringBuilder(size);

            if (includeColumnHeaders)
            {
                // Start by adding each column name
                delimited.Append(Deliminate(table.Columns)).Append(Environment.NewLine);
            }

            // Delimit each row
            foreach (DataRow row in table.Rows)
            {
                delimited.Append(Deliminate(row.ItemArray)).Append(Environment.NewLine);
            }

            return delimited.ToString();
        }

        /// <summary>
        /// Creates a deliminated string from a list of elements.
        /// </summary>
        /// <param name="elements"></param>
        /// <returns></returns>
        public String Deliminate(ICollection elements)
        {
            if (elements == null || elements.Count == 0)
            {
                return String.Empty;
            }

            StringBuilder sb = new StringBuilder();
            // Combine each element with the deliminator to divide them, making 
            // sure to prepare each element for use
            foreach(Object obj in elements)
            {
                if(obj == null)
                {
                    sb.Append(String.Empty + Delimiter);
                }
                else
                {
                    sb.Append(Prepare(obj.ToString()) + Delimiter);
                }
            }
            return sb.ToString();
            //return elements.ToString(Delimiter, item => item == null ? String.Empty : Prepare((string)item));
        }

        /// <summary>
        /// Prepares a string for being included in a deliminated
        /// file or other structure. Elements that contain quotes,
        /// newlines, or the delimiter will be wrapped in quotes.
        /// Null strings will be returned as empty strings.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public String Prepare(String value)
        {
            return (StringPreparer != null) ? StringPreparer(value) : DefaultPreparer(value);
        }

        /// <summary>
        /// The default string preparer for the Deliminator class.  This method
        /// will escape quote characters, the delimiter itself, and newlines
        /// </summary>
        /// <param name="value">The string value to prepare.</param>
        /// <returns>A prepared string with the appropriate characters escaped</returns>
        private string DefaultPreparer(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return String.Empty;
            }

            String prepared = value;
            if (value.Contains("\"") || value.Contains(Delimiter) || value.Contains(Environment.NewLine) || value.Contains("\n"))
            {
                prepared = "\"" + prepared + "\"";
            }
            return prepared;
        }
    }
}
