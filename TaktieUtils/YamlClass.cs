using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YamlDotNet.Core;
using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.Serialization;

namespace TaktieUtils
{
    internal class YamlClass
    {
        public static ConfigClass LoadYaml(string filePath)
        {
            try
            {
                var deserializer = new DeserializerBuilder()
                    .WithNamingConvention(CamelCaseNamingConvention.Instance) // YAMLのキャメルケースサポート
                .Build();

                using (var reader = new StreamReader(filePath))
                {
                    return deserializer.Deserialize<ConfigClass>(reader);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading YAML: {ex.Message}");
                return null;
            }
        }

        public static void SaveYaml(string filePath, ConfigClass config)
        {
            try
            {
                var serializer = new SerializerBuilder()
                    .WithNamingConvention(CamelCaseNamingConvention.Instance) // YAMLのキャメルケースサポート
                    .Build();

                using (var writer = new StreamWriter(filePath))
                {
                    serializer.Serialize(writer, config);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error writing YAML: {ex.Message}");
            }
        }
    }
}
