using System;
using System.Collections.Generic;
using Bogus;
using store_api.Models;

namespace store_api.Seed;

public static class FakeProductGenerator
{
    public static List<Product> GenerateProductList(int count = 20)
    {
        var categories = new[] { "Категория 1", "Категория 2", "Категория 3" };
        var specialTags = new[] { "Новинка", "Популярный", "Рекомендуемый" };

        return new Faker<Product>("ru")
            .RuleFor(m => m.Id, f => f.IndexFaker + 1)
            .RuleFor(m => m.Name, f => f.Commerce.ProductName())
            .RuleFor(m => m.Description, f => f.Commerce.ProductDescription())
            .RuleFor(m => m.SpecialTag, f => f.PickRandom(specialTags))
            .RuleFor(m => m.Category, f => f.PickRandom(categories))
            .RuleFor(m => m.Price, f => Math.Round(f.Random.Decimal(max: 1000M), 2))
            .RuleFor(m => m.Image,
                f => $"https://place-hold.it/{f.Random.Number(200, 500)}x{f.Random.Number(200, 500)}")
            .Generate(count);
    }
}