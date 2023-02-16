using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace Delete_File
{
    class Program
    {
        static void Main(string[] args)
        {
            var configBuilder = new ConfigurationBuilder().
            AddJsonFile("appsetting.json").Build();
            var configSection = configBuilder.GetSection("AppSettings");
            var path = configSection["Location"] ?? null;
            var X = configSection["NoOfDays"] ?? null;
            double val = Convert.ToDouble(X);

            if (Directory.Exists(path))
            {
                DirectoryInfo RootDir = new DirectoryInfo(path);
                foreach (FileInfo file in RootDir.GetFiles())
                    if (file.LastWriteTime < DateTime.Now.AddDays(val))
                        file.Delete();
                Console.WriteLine("The files created before "+ DateTime.Now.AddDays(val) + " are deleted.");
            }
            else
            {
                Console.WriteLine("The path does not exist.");
            }        
        }

    }
}