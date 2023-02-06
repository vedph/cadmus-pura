﻿using Cadmus.Core;
using Cadmus.Core.Config;
using Cadmus.Pura.Parts;
using Fusi.Microsoft.Extensions.Configuration.InMemoryJson;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using Xunit;

namespace Cadmus.Seed.Pura.Parts.Test;

static internal class TestHelper
{
    static public Stream GetResourceStream(string name)
    {
        if (name == null) throw new ArgumentNullException(nameof(name));

        return Assembly.GetExecutingAssembly().GetManifestResourceStream(
                $"Cadmus.Seed.Pura.Parts.Test.Assets.{name}")!;
    }

    static public string LoadResourceText(string name)
    {
        if (name == null) throw new ArgumentNullException(nameof(name));

        using (StreamReader reader = new(GetResourceStream(name),
            Encoding.UTF8))
        {
            return reader.ReadToEnd();
        }
    }

    private static IHost GetHost(string config)
    {
        // map
        TagAttributeToTypeMap map = new();
        map.Add(new[]
        {
            // Cadmus.Core
            typeof(StandardItemSortKeyBuilder).Assembly,
            // Cadmus.Pura.Parts
            typeof(WordFormsPart).Assembly
        });

        return new HostBuilder().ConfigureServices((hostContext, services) =>
            {
                PartSeederFactory.ConfigureServices(services,
                    new StandardPartTypeProvider(map),
                    new[]
                    {
                        // Cadmus.Seed.Pura.Parts
                        typeof(WordFormsPartSeeder).Assembly
                    });
            })
            // extension method from Fusi library
            .AddInMemoryJson(config)
            .Build();
    }

    static public PartSeederFactory GetFactory()
    {
        return new PartSeederFactory(GetHost(LoadResourceText("SeedConfig.json")));
    }

    static public void AssertPartMetadata(IPart part)
    {
        Assert.NotNull(part.Id);
        Assert.NotNull(part.ItemId);
        Assert.NotNull(part.UserId);
        Assert.NotNull(part.CreatorId);
    }
}
