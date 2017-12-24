﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AMOFGameEngine.Utilities
{
    public class ConfigFileParser
    {
        public ConfigFile Load(string filePath)
        {
            ConfigFile conf = new ConfigFile();
            conf.Name = filePath;
            ConfigFileSection currentSection = null;
            int counter = 0;
            using (StreamReader sr = new StreamReader(filePath))
            {
                while (sr.Peek() != -1)
                {
                    string line = sr.ReadLine();
                    if (line.StartsWith("#"))//Skip comments
                    {
                        continue;
                    }
                    else if (line.StartsWith("[") && line.EndsWith("]"))
                    {
                        currentSection = new ConfigFileSection();
                        currentSection.Name = line.Substring(1, line.IndexOf(']') - 1);
                        conf.Sections.Add(currentSection);
                    }
                    else if (counter == 0 && line.Split('=').Length == 2)//No section
                    {
                        currentSection = new ConfigFileSection();
                        currentSection.Name = string.Empty;
                        currentSection.KeyValuePairs.Add(new ConfigFileKeyValuePair()
                            {
                                Key = line.Split('=')[0],
                                Value = line.Split('=')[1]
                            });
                        conf.Sections.Add(currentSection);
                    }
                    else if (line.Split('=').Length == 2)
                    {
                        currentSection.KeyValuePairs.Add(new ConfigFileKeyValuePair()
                        {
                            Key = line.Split('=')[0],
                            Value = line.Split('=')[1]
                        });
                    }
                    counter++;
                }
            }

            return conf;
        }
    }
}