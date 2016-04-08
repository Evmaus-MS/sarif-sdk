﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using Microsoft.CodeAnalysis.Sarif.Writers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Newtonsoft.Json;

namespace Microsoft.CodeAnalysis.Sarif.Readers
{
    [TestClass]

    public class AlgorithmKindConverterTests
    {
        private static readonly Run s_defaultRunInfo = new Run();
        private static readonly Tool s_defaultToolInfo = new Tool();
        private static readonly Result s_defaultResult = new Result();

        public AlgorithmKindConverterTests()
        {
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                ContractResolver = SarifContractResolver.Instance
            };
        }

        private static string GetJson(Action<ResultLogJsonWriter> testContent)
        {
            StringBuilder result = new StringBuilder();
            using (var str = new StringWriter(result))
            using (var json = new JsonTextWriter(str))
            using (var uut = new ResultLogJsonWriter(json))
            {
                testContent(uut);
            }

            return result.ToString();
        }

        [TestMethod]
        public void AlgorithmKindGroestl()
        {
            string expected = "{\"version\":\"1.0.0-beta.2\",\"runLogs\":[{\"tool\":{\"name\":null},\"run\":{\"files\":{\"http://abc/\":[{\"uri\":\"http://abc/\",\"hashes\":[{\"value\":null,\"algorithm\":\"Groestl\"}]}]}},\"results\":[{}]}]}";
            string actual = GetJson(uut =>
            {
                var run = new Run();

                run.Files = new Dictionary<Uri, IList<FileReference>> {
                    [new Uri("http://abc/")] = new List<FileReference>
                    {
                        new FileReference()
                        {
                            Uri = new Uri("http://abc/"),
                            Hashes = new[]
                            {
                                new Hash()
                                {
                                   Algorithm = AlgorithmKind.Groestl
                                }
                            }
                        }
                    }
                };

                uut.WriteTool(s_defaultToolInfo);
                uut.WriteRun(run);
                uut.WriteResult(s_defaultResult);
            });
            Assert.AreEqual(expected, actual);
        }
    }
}
