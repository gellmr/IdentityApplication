using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gellmvc.Models
{
  /*
  * This pagination thanks to Jason Watmore's excellent example at his blog:
  * http://jasonwatmore.com/post/2015/10/30/aspnet-mvc-pagination-example-with-logic-like-google
  */
  public class Pager
  {
    public Pager(int totalItems, int? page, int pageSize = 10)
    {
      // Calculate total, start and end pages
      var totalPages = (int)Math.Ceiling((decimal)totalItems / (decimal)pageSize);
      var currentPage = page != null ? (int)page : 1;

      // Figure out where we will start displaying numbers. Eg
      // [First][Prev][2,3,4,CURRENT,6,7,8][Next][Last]   where startPage = 2

      var startPage = currentPage - 5; // start of our visible range.
      var endPage = currentPage + 4;   // end of our visible range.

      if (startPage <= 0)
      {
        endPage -= (startPage - 1);
        startPage = 1;
      }
      if (endPage > totalPages)
      {
        endPage = totalPages;
        if (endPage > 10)
        {
          startPage = endPage - 9;
        }
      }

      TotalItems = totalItems;
      CurrentPage = currentPage;
      PageSize = pageSize;
      TotalPages = totalPages;
      StartPage = startPage;
      EndPage = endPage;
    }

    public int TotalItems { get; private set; }
    public int CurrentPage { get; private set; }
    public int PageSize { get; private set; }
    public int TotalPages { get; private set; }
    public int StartPage { get; private set; }
    public int EndPage { get; private set; }
  }
}