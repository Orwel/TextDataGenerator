// Copyright 2016-2016 Cédric VERNOU. All rights reserved. See LICENCE.md in the project root for license information.

using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using TextDataGenerator.Core;

namespace TextDataGenerator.Factory
{
    internal class FactoryContainer : IDisposable
    {
        private readonly CompositionContainer container;

        public FactoryContainer()
        {
            var catalog = new AssemblyCatalog(System.Reflection.Assembly.GetExecutingAssembly());
            container = new CompositionContainer(catalog);
        }

        public IFactory CreateFactory(string type)
        {
            var exports = container.GetExports(new ContractBasedImportDefinition(
                type,
                AttributedModelServices.GetTypeIdentity(typeof(IFactory)),
                null,
                ImportCardinality.ZeroOrMore,
                false,
                false,
                CreationPolicy.NonShared)).ToList();

            if (exports == null || !exports.Any())
                throw new InvalidOperationException("Unknown tag type : " + type);
            if (exports.Count > 1)
                throw new InvalidOperationException("Know many tag type : " + type);

            return (IFactory)exports.FirstOrDefault()?.Value;
        }

        public void Dispose()
        {
            container.Dispose();
        }
    }
}