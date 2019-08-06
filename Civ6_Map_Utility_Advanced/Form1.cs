using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Civ6_Map_Utility_Advanced
{
    public partial class Civ6_Map_Utility : Form
    {
        public Civ6_Map_Utility()
        {
            InitializeComponent();
        }

        private void checkBox_experimental_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_experimental.Checked)
            {
                set_experimental_limits();
            }
            else
            {
                set_standard_limits();
            }
        }
        private void set_standard_limits()
        {
            /*Standard Limits For Size Settings*/
            int min_size = 26;
            int max_size = 106;

            this.numericUpDown_size_width.Minimum = min_size;
            this.numericUpDown_size_width.Maximum = max_size;


            this.numericUpDown_size_height.Minimum = min_size;
            this.numericUpDown_size_height.Maximum = max_size;

            /*Standard Limits For Player Settings*/
            int min_players = 2;
            int max_players = 20;

            this.numericUpDown_players_min.Minimum = min_players;
            this.numericUpDown_players_min.Maximum = max_players;

            this.numericUpDown_players_max.Minimum = min_players;
            this.numericUpDown_players_max.Maximum = max_players;

            this.numericUpDown_players_default.Minimum = min_players;
            this.numericUpDown_players_default.Maximum = max_players;

            /*Standard Limits For City States Settings*/
            int min_city_states = 0;
            int max_city_states = 24;

            this.numericUpDown_city_states_min.Minimum = min_city_states;
            this.numericUpDown_city_states_min.Maximum = max_city_states;

            this.numericUpDown_city_states_max.Minimum = min_city_states;
            this.numericUpDown_city_states_max.Maximum = max_city_states;

            this.numericUpDown_city_states_default.Minimum = min_city_states;
            this.numericUpDown_city_states_default.Maximum = max_city_states;

            /*Standard Limits Natural Wonders Settings*/
            int min_wonders = 0;
            int max_wonders = 12;

            this.numericUpDown_natural_wonders.Minimum = min_wonders;
            this.numericUpDown_natural_wonders.Maximum = max_wonders; //check if it's 12

            /*Standard Limits Continents Settings*/
            int min_continents = 1;
            int max_continents = 6;// over 6 or at 6 resouces seem to be broken

            this.numericUpDown_continents.Minimum = min_continents;
            this.numericUpDown_continents.Maximum = max_continents;

            /*Standard Limits PlateValue Settings*/
            int min_plate_value = 3;
            int max_plate_value = 5;  //as far as i know this has no effect on map

            this.numericUpDown_plate_value.Minimum = min_plate_value;
            this.numericUpDown_plate_value.Maximum = max_plate_value;

            /*Standard Limits Prophets Settings*/
            int min_prophets = 2;
            int max_prophets = 7; //this is limited by other things

            this.numericUpDown_prophets.Minimum = min_prophets;
            this.numericUpDown_prophets.Maximum = max_prophets;

        }
        private void set_experimental_limits()
        {
            /*Experimental Limits For Size Settings*/
            int min_size = 0;
            int max_size = 999;

            this.numericUpDown_size_width.Minimum = min_size;
            this.numericUpDown_size_width.Maximum = max_size;


            this.numericUpDown_size_height.Minimum = min_size;
            this.numericUpDown_size_height.Maximum = max_size;

            /*Experimental Limits For Player Settings*/
            int min_players = 0;
            int max_players = 99;

            this.numericUpDown_players_min.Minimum = min_players;
            this.numericUpDown_players_min.Maximum = max_players;

            this.numericUpDown_players_max.Minimum = min_players;
            this.numericUpDown_players_max.Maximum = max_players;

            this.numericUpDown_players_default.Minimum = min_players;
            this.numericUpDown_players_default.Maximum = max_players;

            /*Experimental Limits For City States Settings*/
            int min_city_states = 0;
            int max_city_states = 99;

            this.numericUpDown_city_states_min.Minimum = min_city_states;
            this.numericUpDown_city_states_min.Maximum = max_city_states;

            this.numericUpDown_city_states_max.Minimum = min_city_states;
            this.numericUpDown_city_states_max.Maximum = max_city_states;

            this.numericUpDown_city_states_default.Minimum = min_city_states;
            this.numericUpDown_city_states_default.Maximum = max_city_states;

            /*Experimental Limits Natural Wonders Settings*/
            int min_wonders = 0;
            int max_wonders = 99;

            this.numericUpDown_natural_wonders.Minimum = min_wonders;
            this.numericUpDown_natural_wonders.Maximum = max_wonders; //check if it's 12

            /*Experimental Limits Continents Settings*/
            int min_continents = 1;
            int max_continents = 99;// over 6 or at 6 resouces seem to be broken

            this.numericUpDown_continents.Minimum = min_continents;
            this.numericUpDown_continents.Maximum = max_continents;

            /*Experimental Limits PlateValue Settings*/
            int min_plate_value = 0;
            int max_plate_value = 99;  //as far as i know this has no effect on map

            this.numericUpDown_plate_value.Minimum = min_plate_value;
            this.numericUpDown_plate_value.Maximum = max_plate_value;

            /*Experimental Limits Prophets Settings*/
            int min_prophets = 0;
            int max_prophets = 99; //this is limited by other things

            this.numericUpDown_prophets.Minimum = min_prophets;
            this.numericUpDown_prophets.Maximum = max_prophets;
        }
        private void set_default_value_map_sizes()
        {
            set_standard_limits(); //set limits to on startup
            this.comboBox_preset_type.Text = "Huge";
            set_game_presets();


            /*Defaults For Experimental Values*/
            this.checkBox_experimental.Checked = false;

            /*Default for TextBoxes */
            this.textBox_size_name.Text = "";
            this.richTextBox_size_description.Text = "";

        }
        private void set_game_presets()
        {
            set_standard_limits(); //set limits to on startup

            int grid_Width;
            int grid_Height;

            int min_players;
            int max_players;
            int default_players;

            int min_city_states;
            int max_city_states;
            int default_city_states;

            int natural_wonders;
            int plate_value;
            int continents;

            int prophets;

            if (this.comboBox_preset_type.Text == "DUEL")
            {
                grid_Width = 44;
                grid_Height = 26;

                min_players = 2;
                max_players = 4;
                default_players = 2;

                min_city_states = 0;
                max_city_states = 6;
                default_city_states = 3;

                natural_wonders = 2;
                plate_value = 3;
                continents = 1;

                prophets = 2;
            }
            else if (this.comboBox_preset_type.Text == "TINY")
            {
                grid_Width = 60;
                grid_Height = 38;

                min_players = 2;
                max_players = 6;
                default_players = 4;

                min_city_states = 0;
                max_city_states = 10;
                default_city_states = 6;

                natural_wonders = 3;
                plate_value = 3;
                continents = 2;

                prophets = 3;
            }
            else if (this.comboBox_preset_type.Text == "SMALL")
            {
                grid_Width = 74;
                grid_Height = 46;

                min_players = 2;
                max_players = 10;
                default_players = 6;

                min_city_states = 0;
                max_city_states = 14;
                default_city_states = 9;

                natural_wonders = 4;
                plate_value = 4;
                continents = 3;

                prophets = 4;
            }
            else if (this.comboBox_preset_type.Text == "STANDARD")
            {
                grid_Width = 84;
                grid_Height = 54;

                min_players = 2;
                max_players = 14;
                default_players = 8;

                min_city_states = 0;
                max_city_states = 18;
                default_city_states = 12;

                natural_wonders = 5;
                plate_value = 4;
                continents = 4;

                prophets = 5;
            }
            else if (this.comboBox_preset_type.Text == "LARGE")
            {
                grid_Width = 96;
                grid_Height = 60;

                min_players = 2;
                max_players = 16;
                default_players = 10;

                min_city_states = 0;
                max_city_states = 22;
                default_city_states = 15;

                natural_wonders = 6;
                plate_value = 5;
                continents = 5;

                prophets = 6;
            }
            else if (this.comboBox_preset_type.Text == "HUGE")
            {
                grid_Width = 106;
                grid_Height = 66;

                min_players = 2;
                max_players = 20;
                default_players = 12;

                min_city_states = 0;
                max_city_states = 24;
                default_city_states = 18;

                natural_wonders = 7;
                plate_value = 5;
                continents = 6;

                prophets = 7;
            }
            else
            {
                grid_Width = 106;
                grid_Height = 66;

                min_players = 2;
                max_players = 20;
                default_players = 12;

                min_city_states = 0;
                max_city_states = 24;
                default_city_states = 18;

                natural_wonders = 7;
                plate_value = 5;
                continents = 6;

                prophets = 7;
            }
            set_map_size_fields(grid_Width, grid_Height, min_players, max_players, default_players, min_city_states, max_city_states, default_city_states, natural_wonders, plate_value, continents, prophets);

        }
        private void set_map_size_fields(int grid_Width, int grid_Height, int min_players, int max_players, int default_players, int min_city_states,
            int max_city_states, int default_city_states, int natural_wonders, int plate_value, int continents, int prophets)
        {

            /*Defaults For Size Settings*/
            this.numericUpDown_size_width.Value = grid_Width;

            this.numericUpDown_size_height.Value = grid_Height;

            /*Defaults For Player Settings*/

            this.numericUpDown_players_min.Value = min_players;

            this.numericUpDown_players_max.Value = max_players;

            this.numericUpDown_players_default.Value = default_players;

            /*Defaults City States Settings*/

            this.numericUpDown_city_states_min.Value = min_city_states;

            this.numericUpDown_city_states_max.Value = max_city_states;

            this.numericUpDown_city_states_default.Value = default_city_states;

            /*Defaults for Natural Wonders Settings*/
            this.numericUpDown_natural_wonders.Value = natural_wonders;

            /*Defaults for PlateValue Settings*/
            this.numericUpDown_plate_value.Value = plate_value;

            /*Defaults for Continents Settings*/
            this.numericUpDown_continents.Value = continents;

            /*Defaults for Prophets Settings*/
            this.numericUpDown_prophets.Value = prophets;
        }

        private void Civ6_Map_Utility_Load(object sender, EventArgs e)
        {
            set_default_value_map_sizes();
            set_default_map_scripts();
            form_formatting();
            //disable incomplete tab
            //this.tabControl1.TabPages.Remove(tabPage2);

        }
        private void button_reset_fields_Click(object sender, EventArgs e)
        {
            set_default_value_map_sizes();
        }

        private void button_browse_Click(object sender, EventArgs e)
        {
            //this.textBox_game_path.Text = Application.StartupPath;
            var dialog = new FolderSelectDialog
            {
                InitialDirectory = Application.StartupPath,
                Title = "Select a folder to import music from"
            };
            if (dialog.Show(Handle))
            {
                this.textBox_game_path.Text = dialog.FileName;
            }
        }

        private void button_add_to_game_Click(object sender, EventArgs e)
        {
            if (this.textBox_game_path.Text.Length != 0) //if string length is not 0
            {
                //check if files already exist
                string destination_path = this.textBox_game_path.Text;
                string config_path = "/Base/Assets/Configuration/Data/Civ6_Map_Utility/Map_Sizes/";
                string file1 = this.textBox_size_name.Text + "_MapSizes.xml";

                string gameplay_path = "/Base/Assets/Gameplay/Data/Civ6_Map_Utility/Map_Sizes/";
                string file2 = this.textBox_size_name.Text + "_Maps.xml";

                string user_message = "";
                bool proceed_file_saving = false;

                if (System.IO.File.Exists(destination_path + config_path + file1) == true)
                {
                    user_message += "File " + file1 + " already exists.\n";
                }
                if (System.IO.File.Exists(destination_path + gameplay_path + file2) == true)
                {
                    user_message += "File " + file2 + " already exists.\n"; //didn't get detected. check if made
                }
                if (user_message.Length != 0)
                {
                    user_message += "\nDo you want to overwrite them?";
                    proceed_file_saving = File_Handler.yes_no_message_box("Overwrite", user_message);
                }
                else
                {
                    proceed_file_saving = true;
                }

                if (proceed_file_saving)
                {
                    if (this.textBox_game_path.Text.Length != 0) //if string length is not 0
                    {
                        Dictionary<string, string> map_sizes_dictionary = generate_dictionary_from_map_size();
                        string path = this.textBox_game_path.Text;

                        File_Handler.create_map_size_files(path, map_sizes_dictionary);

                        MessageBox.Show("Files added to the Game path!");
                    }
                }
            }
        }
        
        private void form_formatting()
        {
            this.textBox_size_name.CharacterCasing = CharacterCasing.Upper;
            //TO DO ADD LENGTHS
            this.textBox_size_name.MaxLength = 20;
            this.richTextBox_size_description.MaxLength = 92;

            //disables add to game until name and paths are added
            this.button_add_to_game.Enabled = false; //map sizes add to game


            this.textBox_script_name.CharacterCasing = CharacterCasing.Upper;
            this.textBox_script_name.MaxLength = 20;
            this.richTextBox_script_description.MaxLength = 92;

            this.button_add_to_game2.Enabled = false; //map scripts add to game


            /*Disables buttons when Name is empty and Enables when it has content*/
            //this.button_save_locally.Enabled = !string.IsNullOrWhiteSpace(textBox_map_name.Text);
        }

        private void textBox_size_name_TextChanged(object sender, EventArgs e)
        {
            /* Character filtering */
            var currentPosition = this.textBox_size_name.SelectionStart;

            this.textBox_size_name.Text = this.textBox_size_name.Text.Replace(" ", "_");
            Regex rgx = new Regex("[^a-zA-Z0-9 _]");
            this.textBox_size_name.Text = rgx.Replace(this.textBox_size_name.Text, "");

            this.textBox_size_name.SelectionStart = currentPosition;

            /*Disables buttons when Name is empty and Enables when it has content*/
            //this.button_save_locally.Enabled = !string.IsNullOrWhiteSpace(textBox_map_name.Text);
            enable_add_to_game_button_map_sizes();
        }
        private void enable_add_to_game_button_map_sizes()
        {
            if (this.textBox_size_name.Text.Length == 0 || this.textBox_game_path.Text.Length == 0)
            {
                this.button_add_to_game.Enabled = false;
            }
            else
            {
                this.button_add_to_game.Enabled = true;
            }
        }
        private void richTextBox_size_description_TextChanged(object sender, EventArgs e)
        {
            /* Character filtering */
            var currentPosition = this.richTextBox_size_description.SelectionStart;

            Regex rgx = new Regex("[^a-zA-Z0-9 - , . @ _ -]");
            this.richTextBox_size_description.Text = rgx.Replace(this.richTextBox_size_description.Text, "");

            this.richTextBox_size_description.SelectionStart = currentPosition;

        }
        private void numericUpDown_players_controls()
        {
            //maximum that can be set is the current value of the maximum scrolly
            this.numericUpDown_players_min.Maximum = this.numericUpDown_players_max.Value;
            this.numericUpDown_players_default.Maximum = this.numericUpDown_players_max.Value;

            //minimum that can be set is the current value of the minimum scrolly
            this.numericUpDown_players_max.Minimum = this.numericUpDown_players_min.Value;
            this.numericUpDown_players_default.Minimum = this.numericUpDown_players_min.Value;
        }
        private void numericUpDown_players_min_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown_players_controls();

        }
        private void numericUpDown_players_max_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown_players_controls();
        }

        private void numericUpDown_players_default_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown_players_controls();
        }

        private void numericUpDown_city_states_controls()
        {
            //maximum that can be set is the current value of the maximum scrolly
            this.numericUpDown_city_states_min.Maximum = this.numericUpDown_city_states_max.Value;
            this.numericUpDown_city_states_default.Maximum = this.numericUpDown_city_states_max.Value;

            //minimum that can be set is the current value of the minimum scrolly
            this.numericUpDown_city_states_max.Minimum = this.numericUpDown_city_states_min.Value;
            this.numericUpDown_city_states_default.Minimum = this.numericUpDown_city_states_min.Value;
        }
        private void numericUpDown_city_states_min_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown_city_states_controls();
        }

        private void numericUpDown_city_states_max_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown_city_states_controls();
        }

        private void numericUpDown_city_states_default_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown_city_states_controls();
        }
        public Dictionary<string, string> generate_dictionary_from_map_size()
        {
            /*
            * =======================================================================
            * Read values from Input Form
            * =======================================================================
            */
            string Name = this.textBox_size_name.Text;
            string MapSizeType = "MAPSIZE_" + this.textBox_size_name.Text;
            string Description = this.richTextBox_size_description.Text;
            string GridWidth = numericUpDown_size_width.Value.ToString();
            string GridHeight = numericUpDown_size_height.Value.ToString();

            string MinPlayers = numericUpDown_players_min.Value.ToString();
            string MaxPlayers = numericUpDown_players_max.Value.ToString();
            string DefaultPlayers = numericUpDown_players_default.Value.ToString();

            string MinCityStates = numericUpDown_city_states_min.Value.ToString();
            string MaxCityStates = numericUpDown_city_states_max.Value.ToString();
            string DefaultCityStates = numericUpDown_city_states_default.Value.ToString();

            string NumNaturalWonders = numericUpDown_natural_wonders.Value.ToString();
            string PlateValue = numericUpDown_plate_value.Value.ToString();
            string Continents = numericUpDown_continents.Value.ToString();

            string MaxWorldInstances = numericUpDown_prophets.Value.ToString();

            Dictionary<string, string> map_sizes_dictionary = new Dictionary<string, string>();
            /*
            * ***********************************************************************
            * Map properties
            * ***********************************************************************
            */
            map_sizes_dictionary.Add("Name", Name);
            map_sizes_dictionary.Add("MapSizeType", MapSizeType);
            map_sizes_dictionary.Add("Type", MapSizeType);  //different entry for the same name as MapSizeType
            map_sizes_dictionary.Add("Kind", "KIND_MAPSIZE");
            map_sizes_dictionary.Add("Description", Description);
            map_sizes_dictionary.Add("GridWidth", GridWidth);
            map_sizes_dictionary.Add("GridHeight", GridHeight);
            /*
            * ***********************************************************************
            * Player properties
            * ***********************************************************************
            */
            map_sizes_dictionary.Add("MinPlayers", MinPlayers);
            map_sizes_dictionary.Add("MaxPlayers", MaxPlayers);
            map_sizes_dictionary.Add("DefaultPlayers", DefaultPlayers);
            /*
            * ***********************************************************************
            * City States properties
            * ***********************************************************************
            */
            map_sizes_dictionary.Add("MinCityStates", MinCityStates);
            map_sizes_dictionary.Add("MaxCityStates", MaxCityStates);
            map_sizes_dictionary.Add("DefaultCityStates", DefaultCityStates);
            /*
            * ***********************************************************************
            * Terrain properties
            * ***********************************************************************
            */
            map_sizes_dictionary.Add("NumNaturalWonders", NumNaturalWonders);
            map_sizes_dictionary.Add("PlateValue", PlateValue);
            map_sizes_dictionary.Add("Continents", Continents);
            /*
            * ***********************************************************************
            * Great Person properties
            * ***********************************************************************
            */
            map_sizes_dictionary.Add("GreatPersonClassType", "GREAT_PERSON_CLASS_PROPHET");
            map_sizes_dictionary.Add("MaxWorldInstances", MaxWorldInstances);
            /*
            * ***********************************************************************
            * Menu Position in Game
            * ***********************************************************************
            */
            map_sizes_dictionary.Add("SortIndex", "115914548340075"); //signature ascii to hex - hex to decimal value of word iluzek

            return map_sizes_dictionary;
        }

        private void textBox_game_path_TextChanged(object sender, EventArgs e)
        {
            enable_add_to_game_button_map_sizes();
        }

        private void button_set_values_Click(object sender, EventArgs e)
        {
            set_game_presets();
        }

        private void button_reset_values_Click_1(object sender, EventArgs e)
        {
            set_default_value_map_sizes();
        }

/*
* ***********************************************************************
* Map Scripts Tab
* ***********************************************************************
*/
        private void set_default_map_scripts()
        {
            this.comboBox_World_Age.SelectedIndex = this.comboBox_World_Age.FindStringExact("Standard");
            this.comboBox_Temperature.SelectedIndex = this.comboBox_Temperature.FindStringExact("Standard");
            this.comboBox_Rainfall.SelectedIndex = this.comboBox_Rainfall.FindStringExact("Standard");
            this.comboBox_Sea_level.SelectedIndex = this.comboBox_Sea_level.FindStringExact("Standard");
            this.comboBox_Resources.SelectedIndex = this.comboBox_Resources.FindStringExact("Standard");
            this.comboBox_Start_Position.SelectedIndex = this.comboBox_Start_Position.FindStringExact("Standard");

            this.checkBox_World_Age.Checked = true;
            this.checkBox_Temperature.Checked = true;
            this.checkBox_Rainfall.Checked = true;
            this.checkBox_Sea_level.Checked = true;
            this.checkBox_Resources.Checked = true;
            this.checkBox_Start_Position.Checked = true;
        }

        private void button_script_path_Click(object sender, EventArgs e)
        {
            // Displays an OpenFileDialog so the user can select a Cursor.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Lua Files|*.lua";
            openFileDialog1.Title = "Select a Lua File";

            // Show the Dialog.
            // If the user clicked OK in the dialog and
            // a .CUR file was selected, open it.
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //MessageBox.Show(openFileDialog1.FileName);
                this.textBox_script_path.Text = openFileDialog1.FileName;
                // Assign the cursor in the Stream to the Form's Cursor property.
                //this.Cursor = new Cursor(openFileDialog1.OpenFile());
            }

        }

        private void textBox_script_name_TextChanged(object sender, EventArgs e)
        {
            /* Character filtering */
            var currentPosition = this.textBox_script_name.SelectionStart;

            this.textBox_script_name.Text = this.textBox_script_name.Text.Replace(" ", "_");
            Regex rgx = new Regex("[^a-zA-Z0-9 _]");
            this.textBox_script_name.Text = rgx.Replace(this.textBox_script_name.Text, "");

            this.textBox_script_name.SelectionStart = currentPosition;

            /*Disables buttons when Name is empty and Enables when it has content*/
            //this.button_save_locally.Enabled = !string.IsNullOrWhiteSpace(textBox_map_name.Text);
            enable_add_to_game_button_map_scripts();
        }
        private void enable_add_to_game_button_map_scripts()
        {
            if (this.textBox_script_name.Text.Length == 0 || this.textBox_game_path2.Text.Length == 0 || this.textBox_script_path.Text.Length == 0)
            {
                this.button_add_to_game2.Enabled = false;
            }
            else
            {
                this.button_add_to_game2.Enabled = true;
            }
        }

        private void button_browse2_Click(object sender, EventArgs e)
        {
            //this.textBox_game_path.Text = Application.StartupPath;
            var dialog = new FolderSelectDialog
            {
                InitialDirectory = Application.StartupPath,
                Title = "Select a folder to import music from"
            };
            if (dialog.Show(Handle))
            {
                this.textBox_game_path2.Text = dialog.FileName;
            }

        }

        private void button_add_to_game2_Click(object sender, EventArgs e)
        {
            if (this.textBox_game_path2.Text.Length != 0) //if string length is not 0
            {
                //check if files already exist
                string destination_path = this.textBox_game_path2.Text;
                string config_path = "/Base/Assets/Configuration/Data/Civ6_Map_Utility/Map_Scripts/";
                string file1 = this.textBox_script_name.Text + ".lua";
                string file2 = this.textBox_script_name.Text + "_MapSettings.xml";
                string file3 = this.textBox_script_name.Text + "_StandardMaps.xml";

                string user_message = "";
                bool proceed_file_saving = false;
                if (System.IO.File.Exists(destination_path + config_path + file1) == true)
                {
                    user_message += "File " + file1 + " already exists.\n";
                }
                if (System.IO.File.Exists(destination_path + config_path + file2) == true)
                {
                    user_message += "File " + file2 + " already exists.\n";
                }
                if (System.IO.File.Exists(destination_path + config_path + file3) == true)
                {
                    user_message += "File " + file3 + " already exists.\n";
                }
                if (user_message.Length != 0)
                {
                    user_message += "\nDo you want to overwrite them?";
                    proceed_file_saving = File_Handler.yes_no_message_box("Overwrite", user_message);
                }
                else
                {
                    proceed_file_saving = true;
                }

                if (proceed_file_saving)
                {
                    Dictionary<string, string> map_scripts_dictionary = generate_dictionary_from_map_scripts();
                    string out_path = this.textBox_game_path2.Text;
                    string script_path = this.textBox_script_path.Text;

                    List<Dictionary<string, string>> map_scripts_options = generate_dictionary_lists_map_settings();

                    File_Handler.create_map_script_files(out_path, map_scripts_dictionary, map_scripts_options);
                    MessageBox.Show("Files added to the Game path!");
                }
            }
        }
        private Dictionary<string, string> generate_dictionary_from_map_settings(string parameterId_item)
        {
            Dictionary<string, string> map_parameters_instance_dictionary = new Dictionary<string, string>();
            string key1 = "Map";
            //string key2 = System.IO.Path.GetFileName(this.textBox_script_path.Text); //get last element from path - would be the file
            string key2 = this.textBox_script_name.Text + ".lua"; //script_name.lua
            string parameterId = parameterId_item.ToString(); // item parameterID string
            string name = "";
            string description = "";
            string domain = "";
            string defaultValue = "2"; //figure a programatic way to read this value from dropdown boxes inside if statements probably
            string configurationGroup = "Map";
            string ConfigurationId = "";
            string groupId = "MapOptions";
            string hash = "0";
            string sortIndex = "115914548340075";

            if (parameterId == "WorldAge")
            {
                name = "LOC_MAP_WORLD_AGE_NAME";
                description = "LOC_MAP_WORLD_AGE_DESCRIPTION";
                domain = "WorldAge";
                ConfigurationId = "world_age";
                defaultValue = (this.comboBox_World_Age.SelectedIndex + 1).ToString(); //plus 1 as index starts with 0 and not 1
            }
            else if (parameterId == "Temperature")
            {
                name = "LOC_MAP_TEMPERATURE_NAME";
                description = "LOC_MAP_WORLD_AGE_DESCRIPTION";
                domain = "Temperature";
                ConfigurationId = "temperature";
                defaultValue = (this.comboBox_Temperature.SelectedIndex + 1).ToString();

            }
            else if (parameterId == "Rainfall")
            {
                name = "LOC_MAP_RAINFALL_NAME";
                description = "LOC_MAP_WORLD_AGE_DESCRIPTION";
                domain = "Rainfall";
                ConfigurationId = "rainfall";
                defaultValue = (this.comboBox_Rainfall.SelectedIndex + 1).ToString();

            }
            else if (parameterId == "SeaLevel")
            {
                name = "LOC_MAP_SEA_LEVEL_NAME";
                description = "LOC_MAP_WORLD_AGE_DESCRIPTION";
                domain = "SeaLevel";
                ConfigurationId = "sea_level";
                defaultValue = (this.comboBox_Sea_level.SelectedIndex + 1).ToString();

            }
            else if (parameterId == "Resources")
            {
                name = "LOC_MAP_RESOURCES_NAME";
                description = "LOC_MAP_WORLD_AGE_DESCRIPTION";
                domain = "Resources";
                ConfigurationId = "resources";
                defaultValue = (this.comboBox_Resources.SelectedIndex + 1).ToString();

            }
            else if (parameterId == "StartPosition")
            {
                name = "LOC_MAP_START_POSITION_NAME";
                description = "LOC_MAP_WORLD_AGE_DESCRIPTION";
                domain = "StartPosition";
                ConfigurationId = "start";
                defaultValue = (this.comboBox_Start_Position.SelectedIndex + 1).ToString();

            }
            else
            {
                //leave blanks?
            }
            map_parameters_instance_dictionary.Add("Key1", key1);
            map_parameters_instance_dictionary.Add("Key2", key2);
            map_parameters_instance_dictionary.Add("ParameterId", parameterId);
            map_parameters_instance_dictionary.Add("Name", name);
            map_parameters_instance_dictionary.Add("Description", description);
            map_parameters_instance_dictionary.Add("Domain", domain);
            map_parameters_instance_dictionary.Add("DefaultValue", defaultValue);
            map_parameters_instance_dictionary.Add("ConfigurationGroup", configurationGroup);
            map_parameters_instance_dictionary.Add("ConfigurationId", ConfigurationId);
            map_parameters_instance_dictionary.Add("GroupId", groupId);
            map_parameters_instance_dictionary.Add("Hash", hash);
            map_parameters_instance_dictionary.Add("SortIndex", sortIndex);

            return map_parameters_instance_dictionary;
        }
        public Dictionary<string, string> generate_dictionary_from_map_scripts()
        {
            /*
            * =======================================================================
            * Read values from Input Form
            * =======================================================================
            */
            Dictionary<string, string> map_scripts_dictionary = new Dictionary<string, string>();
            /*
            * ***********************************************************************
            * Standard Maps info
            * ***********************************************************************
            */
            string Description = this.richTextBox_script_description.Text;
            string Name = this.textBox_script_name.Text;
            string FilePath = this.textBox_script_path.Text;
            //string File = System.IO.Path.GetFileName(FilePath);
            string File = Name + ".lua";

            map_scripts_dictionary.Add("Description", Description);
            map_scripts_dictionary.Add("Name", Name);
            map_scripts_dictionary.Add("FilePath", FilePath);
            map_scripts_dictionary.Add("File", File);
            map_scripts_dictionary.Add("SortIndex", "115914548340075");

            return map_scripts_dictionary;
        }

        private void textBox_game_path2_TextChanged(object sender, EventArgs e)
        {
            enable_add_to_game_button_map_scripts();

        }
        private List<Dictionary<string, string>> generate_dictionary_lists_map_settings()
        {
            //List<string> parameterId_list = new List<string>(); // list of parameter id's (taken from checked checkboxes)
            List<Dictionary<string, string>> all_dictionaries = new List<Dictionary<string, string>>(); //declare combined dictionary list that will be sent to xml converion

            if (this.checkBox_World_Age.Checked == true)
            {
                all_dictionaries.Add(generate_dictionary_from_map_settings("WorldAge")); //generates a dictionary entry for setting "World Age" and adds it to the overall list
            }
            if (this.checkBox_Temperature.Checked == true)
            {
                all_dictionaries.Add(generate_dictionary_from_map_settings("Temperature"));
            }
            if (this.checkBox_Rainfall.Checked == true)
            {
                all_dictionaries.Add(generate_dictionary_from_map_settings("Rainfall"));
            }
            if (this.checkBox_Sea_level.Checked == true)
            {
                all_dictionaries.Add(generate_dictionary_from_map_settings("SeaLevel"));
            }
            if (this.checkBox_Resources.Checked == true)
            {
                all_dictionaries.Add(generate_dictionary_from_map_settings("Resources"));
            }
            if (this.checkBox_Start_Position.Checked == true)
            {
                all_dictionaries.Add(generate_dictionary_from_map_settings("StartPosition"));
            }
            return all_dictionaries; //returns full list of settings
        }
    }
}

//TODO Managed to get all outputs using TEst button but need to figure out how to merge the output.