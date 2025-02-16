﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using App.Infrastructure.FileInteractions.Readers;
using DocumentFormat.OpenXml.Packaging;

namespace App.Implementation.FileInteractions.Readers
{
    public class FromDocReader : ILinesReader
    {
        private readonly string fileName;

        public FromDocReader(string fileName)
        {
            this.fileName = fileName;
        }

        public Result<IEnumerable<string>> ReadLines()
        {
            if (!File.Exists(fileName))
                return Result.Fail<IEnumerable<string>>($"File {fileName} is not found");

            return Result.Of(() => WordprocessingDocument
                    .Open(fileName, false)
                    .MainDocumentPart?
                    .Document
                    .Body?
                    .SelectMany(item => Regex.Split(item.InnerText, @"\P{L}+", RegexOptions.Compiled))
                    .Select(word => word))
                .RefineError($"Can not read lines from file {fileName}");
        }
    }
}