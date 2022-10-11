﻿using Cadmus.Cli.Core;
using Cadmus.Core;
using Cadmus.Core.Config;
using Cadmus.Core.Storage;
using Cadmus.Mongo;
using Cadmus.Parts.General;
using Cadmus.Philology.Parts;
using Cadmus.Pura.Parts;
using Cadmus.Tgr.Parts.Codicology;
using Fusi.Tools.Config;
using System;
using System.Reflection;

namespace Cadmus.Cli.Plugin.Pura
{
    [Obsolete("Replace CLI providers with shared providers")]
    [Tag("cli-repository-provider.pura")]
    public sealed class PuraCliCadmusRepositoryProvider :
        ICliCadmusRepositoryProvider
    {
        private readonly IPartTypeProvider _partTypeProvider;

        public string ConnectionString { get; set; }

        public PuraCliCadmusRepositoryProvider()
        {
            var map = new TagAttributeToTypeMap();
            map.Add(new[]
            {
                // Cadmus.General.Parts
                typeof(NotePart).GetTypeInfo().Assembly,
                // Cadmus.Philology.Parts
                typeof(ApparatusLayerFragment).GetTypeInfo().Assembly,
                // Cadmus.Tgr.Parts
                typeof(MsUnit).GetTypeInfo().Assembly,
                // Cadmus.Pura.Parts
                typeof(WordFormsPart).GetTypeInfo().Assembly,
            });

            _partTypeProvider = new StandardPartTypeProvider(map);
        }

        public ICadmusRepository CreateRepository(string database)
        {
            if (database == null)
                throw new ArgumentNullException(nameof(database));

            // create the repository (no need to use container here)
            MongoCadmusRepository repository =
                new(_partTypeProvider, new StandardItemSortKeyBuilder());

            repository.Configure(new MongoCadmusRepositoryOptions
            {
                ConnectionString = string.Format(ConnectionString, database)
            });

            return repository;
        }
    }
}
