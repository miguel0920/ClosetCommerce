using Catalog.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace Catalog.Persistence.Database.Configuration
{
    public class ProductConfiguration
    {
        public ProductConfiguration(EntityTypeBuilder<Product> typeBuilder)
        {
            typeBuilder.HasIndex(x => x.ProductId);
            typeBuilder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            typeBuilder.Property(x => x.Description).IsRequired().HasMaxLength(500);

            List<Product> products = new();
            Random random = new();
            for (int i = 1; i <= 100; i++)
            {
                products.Add(new Product
                {
                    ProductId = i,
                    Name = $"product {i}",
                    Description = $"description for product {i}",
                    Price = random.Next(100, 1000)
                });
            }

            typeBuilder.HasData(products);
        }
    }
}