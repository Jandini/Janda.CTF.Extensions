using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace Janda.CTF
{
    public static class ChallengeExtensions
    {

        public static string[] MatchFlag(this string value, ILogger _logger = null)
        {
            var result = new List<string>();

            foreach (Match match in Regex.Matches(value, "(?:flag).[ a-zA-Z0-9_$!@#$%^&*()+.\\[\\]]+", RegexOptions.IgnoreCase))
            {
                _logger.LogTrace("Match: {value} {@match}", match.Value ?? "", new { match.Index, match.Length });
                result.Add(match.ToString());
            }

            return result.ToArray();
        }


        private static string FindDirectory(string path, string name, ILogger logger = null)
        {
            logger?.LogTrace("Searching for \"{directory}\" directory", name);
            var dirs = Directory.GetDirectories(path, name, SearchOption.AllDirectories);

            if (dirs.Length == 0)
                throw new Exception($"Directory \"{name}\" was not found.");

            return dirs.First();
        }

        private static string GetResourceFilePath(int frame, string name, string root = "Challenges", ILogger logger = null)
        {
            var methodInfo = new StackTrace().GetFrame(frame).GetMethod();
            var className = methodInfo.ReflectedType.Name;

            var sourceDir = Directory.GetCurrentDirectory();

            logger?.LogTrace("Locating resource file {name} for {className} in {dir}", name, className, sourceDir);

            string rootDirPath = FindDirectory(sourceDir, root, logger);
            var resourceDirPath = FindDirectory(rootDirPath, className, logger);

            var files = Directory.GetFiles(resourceDirPath, name);

            if (files.Length == 0)
                throw new Exception($"File \"{name}\" was not found in {resourceDirPath}");

            logger?.LogTrace("File {name} found in {path}", name, files.First());


            return files.First();
        }

        private static string LogResourceFilePathBytes(string name, string root = "Challenges", ILogger logger = null)
        {
            var path = GetResourceFilePath(4, name, root, logger);

            logger?.LogTrace("Loading {bytes} bytes from resource file {name}", new FileInfo(path).Length, path);

            return path;
        }

        private static T LoadResourceFile<T>(string name, Func<string, T> load, ILogger logger = null) => load(LogResourceFilePathBytes(name, logger:logger));

        public static string AsResourceFileNameGetFullPath(this string name, ILogger logger = null) => GetResourceFilePath(3, name, logger:logger);
        public static byte[] AsResourceFileNameReadAllBytes(this string name, ILogger logger = null) => LoadResourceFile(name, (path) => File.ReadAllBytes(path), logger);
        public static string AsResourceFileNameReadAllText(this string name, ILogger logger = null) => LoadResourceFile(name, (path) => File.ReadAllText(path), logger);
        public static string[] AsResourceFileNameReadAllLines(this string name, ILogger logger = null) => LoadResourceFile(name, (path) => File.ReadAllLines(path), logger);
    }
}
