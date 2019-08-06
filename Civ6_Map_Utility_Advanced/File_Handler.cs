using System.Collections.Generic;
using System.Windows.Forms;

namespace Civ6_Map_Utility_Advanced
{
    class File_Handler
    {
        private static void create_file(string path, string data)
        {
            System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(path));
            System.IO.StreamWriter file = new System.IO.StreamWriter(path);

            file.WriteLine(data);

            file.Close();
        }
        private static void copy_file(string path_src, string path_dst)
        {
            System.IO.File.Copy(path_src, path_dst, true);
        }
        public static bool yes_no_message_box(string title, string message)
        {
            DialogResult dialogResult = MessageBox.Show(message, title, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /* Map Sizes Functions */
        private static void create_Maps_xml(string path, string size_name, string data)
        {
            string save_path = path + "/Base/Assets/Gameplay/Data/Civ6_Map_Utility/Map_Sizes/" + size_name + "_Maps.xml";
            create_file(save_path, data);

        }
        private static void create_MapSizes_xml(string path, string size_name, string data)
        {
            string save_path = path + "/Base/Assets/Configuration/Data/Civ6_Map_Utility/Map_Sizes/" + size_name + "_MapSizes.xml";
            create_file(save_path, data);
        }
        public static void create_map_size_files(string path, Dictionary<string, string> map_sizes_dictionary)
        {
            string name = map_sizes_dictionary["Name"];

            string maps_contents = XML_Creator.Compose_File_Maps(map_sizes_dictionary);
            string map_sizes_contents = XML_Creator.Compose_File_MapSizes(map_sizes_dictionary);

            create_Maps_xml(path, name, maps_contents);
            create_MapSizes_xml(path, name, map_sizes_contents);
        }


        /* Map Scripts Functions */
        private static void create_StandardMaps_xml(string path, string script_name, string data)
        {
            string save_path = path + "/Base/Assets/Configuration/Data/Civ6_Map_Utility/Map_Scripts/" + script_name + "_StandardMaps.xml";
            create_file(save_path, data);
        }

        private static void create_MapSettings_xml(string path, string script_name, string data)
        {
            string save_path = path + "/Base/Assets/Configuration/Data/Civ6_Map_Utility/Map_Scripts/" + script_name + "_MapSettings.xml";
            create_file(save_path, data);
        }

        private static void copy_script_file(string src_path, string dst_path, string script_name)
        {
            string file_name = System.IO.Path.GetFileName(src_path);
            string save_path = dst_path + "/Base/Assets/Configuration/Data/Civ6_Map_Utility/Map_Scripts/" + script_name +".lua";
            copy_file(src_path, save_path);
        }

        public static void create_map_script_files(string dst_path, Dictionary<string, string> map_scripts_dictionary, List<Dictionary<string,string>> map_scripts_options)
        {
            /*Generate Standard_Maps File */
            string name = map_scripts_dictionary["Name"];
            string standard_maps_contents = XML_Creator.Compose_File_Standard_Maps(map_scripts_dictionary);
            //create StandardMaps_xml file
            create_StandardMaps_xml(dst_path, name, standard_maps_contents);

            /*Copy Script File */
            copy_script_file(map_scripts_dictionary["FilePath"], dst_path, name);


            /*Generate MapSettings file */
            string mapSettings_xml = XML_Creator.Compose_File_Map_Settings(map_scripts_options); //returns combined input for xml file
            create_MapSettings_xml(dst_path, name, mapSettings_xml);

        }

    }
}
