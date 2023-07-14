using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Entities;

namespace Infrastructure.Helper;

public class ProductExpressionsDictionary
{
    private Dictionary<string, Expression<Func<Product, object>>> dictionary;

    public ProductExpressionsDictionary()
    {
        dictionary = new Dictionary<string, Expression<Func<Product, object>>>();
        dictionary.Add("price", x => x.Price);
        dictionary.Add("productName", x => x.ProductName);
        dictionary.Add("", x => x.ProductName);
    }


    public Expression<Func<Product, object>> GetValue(string key)
    {
        return dictionary[key];
    }
}