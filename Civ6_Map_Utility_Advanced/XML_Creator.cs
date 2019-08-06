using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Windows.Forms;
using System.Linq;

namespace Civ6_Map_Utility_Advanced
{
    class XML_Creator
    {
        /*
        * =======================================================================
        * Compose MapSize file addition 
        * Based on original Civ6/Base/Assets/Configuration/Data/MapSizes.xml
        * =======================================================================
        */
        public static String Compose_File_MapSizes(Dictionary<string, string> map_sizes_dictionary)
        {
            XElement xml = new XElement("GameInfo",
                new XElement("MapSizes",
                    new XElement("Row",
                        new XAttribute("MapSizeType", map_sizes_dictionary["MapSizeType"]),
                        new XAttribute("Name", map_sizes_dictionary["Name"]),
                        new XAttribute("MinPlayers", map_sizes_dictionary["MinPlayers"]),
                        new XAttribute("MaxPlayers", map_sizes_dictionary["MaxPlayers"]),
                        new XAttribute("DefaultPlayers", map_sizes_dictionary["DefaultPlayers"]),
                        new XAttribute("MinCityStates", map_sizes_dictionary["MinCityStates"]),
                        new XAttribute("MaxCityStates", map_sizes_dictionary["MaxCityStates"]),
                        new XAttribute("DefaultCityStates", map_sizes_dictionary["DefaultCityStates"]),
                        new XAttribute("SortIndex", map_sizes_dictionary["SortIndex"])
                    )
                )
            );
            //Console.WriteLine(xml);
            return xml.ToString();
        }

        /*
        * =======================================================================
        * Compose Maps file addition 
        * Based on original Civ6/Base/Assets/Gameplay/Data/Maps.xml
        * =======================================================================
        */
        public static String Compose_File_Maps(Dictionary<string, string> map_sizes_dictionary)
        {
            XElement xml = new XElement("GameInfo",
                new XElement("Types",
                    new XElement("Row",
                        new XAttribute("Type", map_sizes_dictionary["Type"]),
                        new XAttribute("Kind", map_sizes_dictionary["Kind"])
                    )
                ),
                new XElement("Maps",
                    new XElement("Row",
                        new XAttribute("MapSizeType", map_sizes_dictionary["MapSizeType"]),
                        new XAttribute("Name", map_sizes_dictionary["Name"]),
                        new XAttribute("Description", map_sizes_dictionary["Description"]),
                        new XAttribute("DefaultPlayers", map_sizes_dictionary["DefaultPlayers"]),
                        new XAttribute("GridWidth", map_sizes_dictionary["GridWidth"]),
                        new XAttribute("GridHeight", map_sizes_dictionary["GridHeight"]),
                        new XAttribute("NumNaturalWonders", map_sizes_dictionary["NumNaturalWonders"]),
                        new XAttribute("PlateValue", map_sizes_dictionary["PlateValue"]),
                        new XAttribute("Continents", map_sizes_dictionary["Continents"])
                    )
                ),
                new XElement("Map_GreatPersonClasses",
                    new XElement("Row",
                        new XAttribute("MapSizeType", map_sizes_dictionary["MapSizeType"]),
                        new XAttribute("GreatPersonClassType", map_sizes_dictionary["GreatPersonClassType"]),
                        new XAttribute("MaxWorldInstances", map_sizes_dictionary["MaxWorldInstances"])
                    )
                )
            );
            //Console.WriteLine(xml);
            return xml.ToString();
        }
        /*
        * =======================================================================
        * Compose MapSettings file addition 
        * Based on original Civ6/Base/Assets/Configuration/Data/MapSettings.xml
        * =======================================================================
        */
        public static string Compose_File_Map_Settings(List<Dictionary<string, string>> list_of_settings)
        {
            List<XElement> xml_list = new List<XElement>(); //a list of xml entries of the same type

            XElement combined_map_settings;
            foreach (Dictionary<string, string> setting_instance in list_of_settings)
            {
                XElement tmp = XML_Creator.Compose_single_Map_Settings(setting_instance);
                xml_list.Add(tmp);
            }
            if (xml_list.Any())
            {
                combined_map_settings = combine_map_parameters(xml_list);
            }
            else
            {
                return ""; //return empty string if no lists are selected (no options)
            }
            return combined_map_settings.ToString();
        }

        private static XElement combine_map_parameters(List<XElement> xml_list)
        {
            XElement root = xml_list[0];

            foreach (var item in xml_list)
            {
                //Console.Write(item);
                if (item != root)
                {
                    root.Element("Parameters").Add(item.Descendants().Last()); //- Extracts last element (Row) from each XML object and appends it to the root XElement
                }
            }
            //Console.Write(root);
            return root;
        }

        /*
        * =======================================================================
        * Compose MapSettings file addition 
        * Based on original Civ6/Base/Assets/Configuration/Data/MapSettings.xml
        * =======================================================================
        */
        public static XElement Compose_single_Map_Settings(Dictionary<string, string> map_parameters_instance_dictionary)
        {
            XElement xml = new XElement("GameInfo",
                new XElement("Parameters",
                    new XElement("Row",
                        new XAttribute("Key1", map_parameters_instance_dictionary["Key1"]),
                        new XAttribute("Key2", map_parameters_instance_dictionary["Key2"]),
                        new XAttribute("ParameterId", map_parameters_instance_dictionary["ParameterId"]),
                        new XAttribute("Name", map_parameters_instance_dictionary["Name"]),
                        new XAttribute("Description", map_parameters_instance_dictionary["Description"]),
                        new XAttribute("DefaultValue", map_parameters_instance_dictionary["DefaultValue"]),
                        new XAttribute("Domain", map_parameters_instance_dictionary["Domain"]),
                        new XAttribute("ConfigurationGroup", map_parameters_instance_dictionary["ConfigurationGroup"]),
                        new XAttribute("ConfigurationId", map_parameters_instance_dictionary["ConfigurationId"]),
                        new XAttribute("GroupId", map_parameters_instance_dictionary["GroupId"]),
                        new XAttribute("Hash", map_parameters_instance_dictionary["Hash"]),
                        new XAttribute("SortIndex", map_parameters_instance_dictionary["SortIndex"])
                    )
                )
            );
            //Console.WriteLine(xml);
            return xml;
        }
        /*
        * =======================================================================
        * Compose StandardMaps file addition 
        * Based on original Civ6/Base/Assets/Configuration/Data/StandardMaps.xml
        * =======================================================================
        */
        public static String Compose_File_Standard_Maps(Dictionary<string, string> map_scripts_dictionary)
        {
            XElement xml = new XElement("GameInfo",
                new XElement("Maps",
                    new XElement("Row",
                        new XAttribute("File", map_scripts_dictionary["File"]),
                        new XAttribute("Name", map_scripts_dictionary["Name"]),
                        new XAttribute("Description", map_scripts_dictionary["Description"]),
                        new XAttribute("SortIndex", map_scripts_dictionary["SortIndex"])
                    )
                )
            );
            //Console.WriteLine(xml);
            return xml.ToString();
        }
    }
}
 