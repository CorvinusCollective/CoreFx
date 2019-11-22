// <copyright file="StrongNameCatalog.cs" company="Corvinus Collective">
// Copyright (c) Corvinus Collective. All rights reserved.
// </copyright>

namespace Corvinus.ComponentModel.Composition
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition.Hosting;
    using System.ComponentModel.Composition.Primitives;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    /// <summary>StrongNameCatalog Class is a ComposiblePartCatalog that gathers assemblies
    /// from a path and validates them.</summary>
    public class StrongNameCatalog : ComposablePartCatalog
    {
        private AggregateCatalog aggregateCatalog = new AggregateCatalog();

        /// <summary>
        /// Initializes a new instance of the <see cref="StrongNameCatalog"/> class.
        /// </summary>
        /// <param name="path">Path assemblies to be loaded are in.</param>
        /// <param name="trustedKeys">An array of Byte Arrays containing trusted Keys for the catalog.</param>
        public StrongNameCatalog(string path, params byte[][] trustedKeys)
        {
            foreach (var file in Directory.GetFiles(path))
            {
                AssemblyName assemblyName = null;
                try
                {
                    assemblyName = AssemblyName.GetAssemblyName(file);
                }
                catch (ArgumentException)
                {
                }
                catch (BadImageFormatException)
                {
                }

                if (assemblyName != null)
                {
                    var publicKey = assemblyName.GetPublicKey();
                    if (publicKey != null)
                    {
                        bool trusted = false;
                        foreach (var trustedKey in trustedKeys)
                        {
                            if (assemblyName.GetPublicKey().SequenceEqual(trustedKey))
                            {
                                trusted = true;
                                break;
                            }
                        }

                        if (trusted)
                        {
                            this.aggregateCatalog.Catalogs.Add(new AssemblyCatalog(file));
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets a list of ComposablePartDefinition classes.
        /// </summary>
        public override IQueryable<ComposablePartDefinition> Parts
        {
            get
            {
                return this.aggregateCatalog.Parts;
            }
        }

        /// <summary>
        /// Returns a ist of Exports based on Import and Export Definitions.
        /// </summary>
        /// <param name="definition">Import Definition.</param>
        /// <returns><see cref="IEnumerable{Tuple{ComposablePartDefinition, ExportDefinition}}"/>.<</returns>
        public override IEnumerable<Tuple<ComposablePartDefinition, ExportDefinition>> GetExports(ImportDefinition definition)
        {
            return this.aggregateCatalog.GetExports(definition);
        }
    }
}