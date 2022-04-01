using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACR.Library.Utils
{
    public class BasePagination
    {
        public BasePagination(int totalItemCount, int pageSize, int currentPageNumber, int windowSize, bool showingAllResults)
        {
            _currentPageNumber = currentPageNumber;
            _totalItemCount = totalItemCount;
            _pageSize = pageSize;
            _windowSize = windowSize;
            ShowingAllResults = showingAllResults;
        }

        public List<PaginationNumber> GetPaginationItems()
        {
            if (ShowingAllResults)
            { return new List<PaginationNumber>(); }

            _totalPageCount = _totalItemCount / (_pageSize == 0 ? 10 : _pageSize);
            _totalPageCount += (_totalItemCount % _pageSize == 0) ? 0 : 1;
            var windowStartPage = _currentPageNumber - _windowSize / 2;
            windowStartPage -= (_currentPageNumber == _totalPageCount) ? 1 : 0;
            windowStartPage = windowStartPage < 1 ? 1 : windowStartPage;
            var windowEndPage = _currentPageNumber + _windowSize / 2;
            windowEndPage += (_currentPageNumber == 1) ? 1 : 0;
            windowEndPage = windowEndPage > _totalPageCount ? _totalPageCount : windowEndPage;

            var pageLinks = new List<PaginationNumber>();

            if (_currentPageNumber > 1)
            {
                var prevLink = new PaginationNumber();
                prevLink.DisplayNumber = PreviousString;
                prevLink.PageNumber = _currentPageNumber - 1;
                pageLinks.Add(prevLink);

                if (windowStartPage > 1)
                {
                    var firstLink = new PaginationNumber();
                    firstLink.PageNumber = 1;
                    firstLink.DisplayNumber = "1";
                    pageLinks.Add(firstLink);

                    if (windowStartPage > 2)
                    {
                        var ellipsis = new PaginationNumber();
                        ellipsis.DisplayNumber = EllipsisString;
                        ellipsis.NotALink = true;
                        pageLinks.Add(ellipsis);
                    }
                }
            }

            // writer page numbers
            for (var page = windowStartPage; page <= windowEndPage; page++)
            {
                var link = new PaginationNumber();
                link.DisplayNumber = page.ToString();
                link.PageNumber = page;
                link.NotALink = page == _currentPageNumber;

                pageLinks.Add(link);
            }

            // writer end links
            if (_currentPageNumber < _totalPageCount)
            {
                if (windowEndPage < _totalPageCount)
                {
                    if (windowEndPage < (_totalPageCount - 1))
                    {
                        var ellipsis = new PaginationNumber();
                        ellipsis.DisplayNumber = EllipsisString;
                        ellipsis.NotALink = true;
                        pageLinks.Add(ellipsis);
                    }

                    var lastLink = new PaginationNumber();
                    lastLink.DisplayNumber = _totalPageCount.ToString();
                    lastLink.PageNumber = _totalPageCount;

                    pageLinks.Add(lastLink);
                }
                // show NEXT link
                var nextLink = new PaginationNumber();
                nextLink.DisplayNumber = NextString;
                nextLink.PageNumber = _currentPageNumber + 1;
                pageLinks.Add(nextLink);
            }

            return pageLinks;
        }

        protected int _pageSize, _currentPageNumber, _windowSize, _totalPageCount, _totalItemCount;

        public bool ShowingAllResults { get; set; }

        public int TotalItemCount
        {
            get { return _totalItemCount; }
            set { _totalItemCount = value; }
        }

        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value; }
        }

        public int CurrentPageNumber
        {
            get { return _currentPageNumber; }
            set { _currentPageNumber = value; }
        }

        public int WindowSize
        {
            get { return _windowSize; }
            set { _windowSize = value; }
        }

        public int TotalPageCount
        {
            get
            {
                int totalPageCount = _totalItemCount / (_pageSize == 0 ? 10 : _pageSize);
                totalPageCount += (_totalItemCount % _pageSize == 0) ? 0 : 1;
                return totalPageCount;
            }
        }

        public static readonly string PreviousString = "Prev";
        public static readonly string NextString = "Next";
        public static readonly string LastString = "Last";
        public static readonly string EllipsisString = "...";
    }
}
