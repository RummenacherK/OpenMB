﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AMOFGameEngine.Utilities
{
    public class ConfigFileKeyValuePair
    {
        private string key;
        private string val;
        public string Key
        {
            get
            {
                return key;
            }
            set
            {
                key = value;
            }
        }
        public string Value
        {
            get
            {
                return val;
            }
            set
            {
                val = value;
            }
        }
    }

    public class ConfigFileSection
    {
        private string name;
        private List<ConfigFileKeyValuePair> keyValuePairs;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public List<ConfigFileKeyValuePair> KeyValuePairs
        {
            get
            {
                return keyValuePairs;
            }
            set
            {
                keyValuePairs = value;
            }
        }
        public ConfigFileSection()
        {
            keyValuePairs = new List<ConfigFileKeyValuePair>();
        }
        public string this[string key]
        {
            get
            {
                string resultValue;
                var resultKeyValuePair = from kpl in keyValuePairs
                                         where kpl.Key == key
                                         select kpl;
                if (resultKeyValuePair.Count() > 0)
                {
                    resultValue = resultKeyValuePair.ElementAt(0).Value;
                }
                else
                {
                    resultValue = null;
                }
                return resultValue;
            }
        }
        public string GetValueByKey(string key)
        {
            string resultValue;
            var resultKeyValuePair = from kpl in keyValuePairs
                                     where kpl.Key == key
                                     select kpl;
            if (resultKeyValuePair.Count() > 0)
            {
                resultValue = resultKeyValuePair.ElementAt(0).Value;
            }
            else
            {
                resultValue = null;
            }
            return resultValue;
        }
    }

    public class ConfigFile
    {
        private string name;
        private List<ConfigFileSection> sections;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public List<ConfigFileSection> Sections
        {
            get
            {
                return sections;
            }
            set
            {
                sections = value;
            }
        }
        public ConfigFile()
        {
            sections = new List<ConfigFileSection>();
        }

        public ConfigFileSection this[string sectionName]
        {
            get
            {
                ConfigFileSection resultSection;

                var resultSections = from section in sections
                                     where section.Name == sectionName
                                     select section;
                if (resultSections.Count() > 0)
                {
                    resultSection = resultSections.ElementAt(0);
                }
                else
                {
                    resultSection = null;
                }

                return resultSection;
            }
        }

        public ConfigFileSection GetSectionByName(string sectionName)
        {
            ConfigFileSection resultSection;

            var resultSections = from section in sections
                                 where section.Name == sectionName
                                 select section;
            if (resultSections.Count() > 0)
            {
                resultSection = resultSections.ElementAt(0);
            }
            else
            {
                resultSection = null;
            }

            return resultSection;
        }
    }
}