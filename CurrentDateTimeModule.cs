using System;
using Nancy;

namespace ShoppingCart
{
    public class CurrentDateTimeModule : NancyModule
    {
      public CurrentDateTimeModule() => Get("/", _ => DateTime.Now);
    }
}