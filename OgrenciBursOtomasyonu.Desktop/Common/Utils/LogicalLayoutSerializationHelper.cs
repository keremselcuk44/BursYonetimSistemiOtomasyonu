using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OgrenciBursOtomasyonu.Desktop.Common.Utils
{
    /// <summary>
    /// Helper class for serializing/deserializing logical layout dictionaries.
    /// </summary>
    public static class LogicalLayoutSerializationHelper
    {
        /// <summary>
        /// Deserializes a layout dictionary from a string.
        /// </summary>
        public static Dictionary<string, string> Deserialize(string serialized)
        {
            var result = new Dictionary<string, string>();
            if (string.IsNullOrEmpty(serialized))
                return result;

            try
            {
                // Simple format: "key1=value1|key2=value2|..."
                var pairs = serialized.Split('|');
                foreach (var pair in pairs)
                {
                    var parts = pair.Split(new[] { '=' }, 2);
                    if (parts.Length == 2)
                    {
                        result[parts[0]] = parts[1];
                    }
                }
            }
            catch
            {
                // Return empty dictionary on error
            }

            return result;
        }

        /// <summary>
        /// Serializes a layout dictionary to a string.
        /// </summary>
        public static string Serialize(Dictionary<string, string> dictionary)
        {
            if (dictionary == null || dictionary.Count == 0)
                return string.Empty;

            try
            {
                // Simple format: "key1=value1|key2=value2|..."
                return string.Join("|", dictionary.Select(kvp => $"{kvp.Key}={kvp.Value}"));
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}

