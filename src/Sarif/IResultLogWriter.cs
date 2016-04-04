﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;

namespace Microsoft.CodeAnalysis.Sarif
{
    /// <summary>This interface serves as a sink for <see cref="SarifLog"/> format issues.</summary>
    public interface IResultLogWriter
    {
        /// <summary>
        /// Initialize the current output log.
        /// </summary>
        void Initialize();

        /// <summary>Writes tool information to the log.</summary>
        /// <exception cref="IOException">A file IO error occured. Clients implementing
        /// <see cref="IToolFileConverter"/> should allow these exceptions to propagate.</exception>
        /// <exception cref="InvalidOperationException">Thrown if the tool info block has already been
        /// written.</exception>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="info"/> is null.</exception>
        /// <param name="toolInfo">The tool information to write.</param>
        void WriteToolInfo(ToolInfo toolInfo);

        /// <summary>Writes run information to the log. This information may appear after
        /// the results, as it can contain data that can't be computed (such as the run
        /// end time) until all results have been generated.</summary>
        /// <exception cref="IOException">A file IO error occured. Clients implementing
        /// <see cref="IToolFileConverter"/> should allow these exceptions to propagate.</exception>
        /// <exception cref="InvalidOperationException">Thrown if the tool info block has already been
        /// written.</exception>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="info"/> is null.</exception>
        /// <param name="runInfo">The run information to write.</param>
        void WriteRunInfo(RunInfo runInfo);

        /// <summary>
        /// Initialize the results array associated with the current output log. SARIF producers that
        /// are explicitly generating results (as opposed to other SARIF scenarios such as publishing
        /// rules metadata) should proactively call this method in order to ensure that an explicit 
        /// (but empty) results array exists in the log when no literal results were produced.
        /// </summary>
        void OpenResults();

        /// <summary>
        /// Writes a result to the log. The log must have tool and run info written first by calling
        /// <see cref="M:WriteToolAndRunInfo" />.
        /// </summary>
        /// <remarks>
        /// This function makes a copy of the data stored in <paramref name="result"/>; if a
        /// client wishes to reuse the result instance to avoid allocations they can do so. (This function
        /// may invoke an internal copy of the result or serialize it in place to disk, etc.)
        /// </remarks>
        /// <exception cref="IOException">
        /// A file IO error occured. Clients implementing
        /// <see cref="IToolFileConverter"/> should allow these exceptions to propagate.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the tool info is not yet written.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="result"/> is null.
        /// </exception>
        ///  <param name="result">
        ///  The result to write.
        ///  </param>
        void WriteResult(Result result);

        /// <summary>
        /// Close out the results array
        /// </summary>
        void CloseResults();

        /// <summary>
        /// Writes a set of results to the log. The log must have tool and run info written first by calling
        /// <see cref="M:WriteToolAndRunInfo" />.
        /// </summary>
        /// <remarks>
        /// This function makes a copy of the data stored in <paramref name="results"/>; if a
        /// client wishes to reuse the result instance to avoid allocations they can do so. (This function
        /// may invoke an internal copy of the result or serialize it in place to disk, etc.)
        /// </remarks>
        /// <exception cref="IOException">
        /// A file IO error occured. Clients implementing
        /// <see cref="IToolFileConverter"/> should allow these exceptions to propagate.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the tool info is not yet written.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="result"/> is null.
        /// </exception>
        ///  <param name="results">
        ///  The results to write.
        ///  </param>
        void WriteResults(IEnumerable<Result> results);
    }
}
