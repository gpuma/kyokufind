using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace kyokuFind
{
   /// <summary>
   /// Static class in charge of reading the configuration properties located
   /// on the config.ini file.
   /// </summary>
    public static class CONFIG
    {
        public static string CONFIG_FILE_PATH = "config.ini";
        //last.fm credentials
        public static string LASTFM_API_KEY;
        public static string LASTFM_API_SECRET;
        //where the index will be built and/or read
        public static string LUCENE_INDEX_PATH;
        /// <summary>
        /// Reads config.ini and sets the config attributes for this class
        /// </summary>
        public static void ReadConfigFile()
        {
            //read lines
            string[] configLines;
            using (var reader = new System.IO.StreamReader(CONFIG_FILE_PATH))
            {
                configLines = reader.ReadToEnd().Split(new string[] {
                    System.Environment.NewLine }, System.StringSplitOptions.None);
            }
            
            //build dictionary for properties from config file
            var configDict = new Dictionary<string, string>();
            foreach(var line in configLines)
            {
                var keyValuePair = line.Split('=');
                // in case there's a blank or incomplete line
                if (keyValuePair.Length < 2)
                    continue;
                configDict.Add(keyValuePair[0].Trim(), keyValuePair[1].Trim());
            }

            //set properties
            CONFIG.LASTFM_API_KEY = configDict["API_KEY"];
            CONFIG.LASTFM_API_SECRET = configDict["API_SECRET"];
            CONFIG.LUCENE_INDEX_PATH = configDict["INDEX_PATH"];
        }
    }
}
