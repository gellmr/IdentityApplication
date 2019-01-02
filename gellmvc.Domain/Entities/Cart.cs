using System;
using System.Collections.Generic;
using System.Linq;

namespace gellmvc.Domain.Entities
{
  public class Cart
  {
    private List<CartLine> lineCollection = new List<CartLine>();

    public class CartLine
    {
      public Product Product { get; set; }  // eg $10 each
      public int Quantity { get; set; }     // eg   5
      public decimal SubTotal { get; set; } // eg   5 x $10 == $50
    }

    public IEnumerable<CartLine> Lines
    {
      get{ return lineCollection; }
    }
    
    public int TotalItemsInCart()
    {
      return lineCollection.Sum(e => e.Quantity);
    }

    // Total Amount Payable for all the items in the cart.
    public decimal GrandTotal()
    {
      return lineCollection.Sum(e => e.Product.UnitPrice * e.Quantity);
    }

    public void RemoveLine(Product product)
    {
      lineCollection.RemoveAll(l => l.Product.Id == product.Id);
    }

    public void Clear()
    {
      lineCollection.Clear();
    }

    // Returns how many of the given product is in the cart, or zero.
    public int GetQuantity(Product product)
    {
      foreach (CartLine line in lineCollection)
      {
        if (line.Product.Id == product.Id)
        {
          return line.Quantity;
        }
      }
      return 0;
    }

    // Update a line quantity in the cart
    public CartLine SetLineQuantity(Product product, int quantity)
    {
      // Check if we already have one of these in the cart.
      CartLine line = lineCollection
        .Where(p => p.Product.Id == product.Id)
        .FirstOrDefault();

      // If we already have one of these items in the cart, increment its quantity.
      // Otherwise, add the new item to the cart.
      if (line != null)
      {
        line.Quantity = quantity;
        line.SubTotal = product.UnitPrice * quantity;
      }
      else
      {
        line = new CartLine { Product = product, Quantity = quantity, SubTotal = product.UnitPrice * quantity };
        lineCollection.Add(line);
      }
      return line;
    }
  }
}
