﻿using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace LojaDiscosAPI.Util
{
    static class ConfigurationManager
    {
        public static IConfiguration AppSetting { get; }
        static ConfigurationManager()
        {
            AppSetting = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("settings.json")
                    .Build();
        }
    }
}
