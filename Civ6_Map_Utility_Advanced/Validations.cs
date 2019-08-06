using System;
using System.Collections.Generic;

namespace Civ6_Map_Utility_Advanced
{
    class Validations
    {
        public static string Validate_Default_Ranges(Dictionary<string, string> map_sizes_dictionary)
        {
            /*
            * ***********************************************************************
            * Default or checked values for GridWidth and GridHeight
            * ***********************************************************************
            */
            string warning_messages = "";

            int min_grid_size = 20; //needs testing
            int max_grid_size = 165; //needs testing

            int max_players = 20; //checked in database

            int max_CityStates = 24; //checked online 

            int max_NumNaturalWonders = 12; //checked database and online

            int max_PlateValue = 5; //guessing based on game files
            int min_PlateValue = 3; //guessing based on game files

            int max_Continents = 6; //guessing based on game files
            int min_Continents = 1; //guessing based on game files

            int max_MaxWorldInstances = 7; //guessing based on game files


            int tested_GridWidth = int.Parse(map_sizes_dictionary["GridWidth"]);
            int tested_GridHeight = int.Parse(map_sizes_dictionary["GridHeight"]);

            int tested_MinPlayers = int.Parse(map_sizes_dictionary["MinPlayers"]);
            int tested_MaxPlayers = int.Parse(map_sizes_dictionary["MaxPlayers"]);
            int tested_DefaultPlayers = int.Parse(map_sizes_dictionary["DefaultPlayers"]);

            int tested_MinCityStates = int.Parse(map_sizes_dictionary["MinCityStates"]);
            int tested_MaxCityStates = int.Parse(map_sizes_dictionary["MaxCityStates"]);
            int tested_DefaultCityStates = int.Parse(map_sizes_dictionary["DefaultCityStates"]);

            int tested_NumNaturalWonders = int.Parse(map_sizes_dictionary["NumNaturalWonders"]);
            int tested_PlateValue = int.Parse(map_sizes_dictionary["PlateValue"]);
            int tested_Continents = int.Parse(map_sizes_dictionary["Continents"]);
            int tested_MaxWorldInstances = int.Parse(map_sizes_dictionary["MaxWorldInstances"]);



            // if dimension are less than minimum tested output warning message
            if (tested_GridWidth < min_grid_size || tested_GridHeight < min_grid_size)
            {
                string min_grid_size_warning = String.Format("Minimum map dimension tested were: {0} x {0}.\nSmaller maps might crash the game.\n\n", min_grid_size);
                warning_messages += min_grid_size_warning;
            }

            // if dimension are more than maximum tested output warning message
            if (tested_GridWidth > max_grid_size || tested_GridHeight > max_grid_size)
            {
                string max_grid_size_warning = String.Format("Maximum map dimension tested were: {0} x {0}.\nLarger maps might load too long or crash the game.\n\n", max_grid_size);
                warning_messages += max_grid_size_warning;
            }

            // if players are too many
            if (tested_MinPlayers > max_players || tested_MaxPlayers > max_players || tested_DefaultPlayers > max_players)
            {
                string max_player_warning = String.Format("Default game features only {0} Civilizations.\nSetting this value higher with or without mods might cause crashing.\n\n", max_players);
                warning_messages += max_player_warning;
            }

            // if city states too many
            if (tested_MinCityStates > max_CityStates || tested_MaxCityStates > max_CityStates || tested_DefaultCityStates > max_CityStates)
            {
                string max_CityStates_warning = String.Format("Default game features only {0} City States.\nSetting this value higher with or without mods might cause crashing.\n\n", max_CityStates);
                warning_messages += max_CityStates_warning;
            }
            // if Natural Wonders Number too many
            if (tested_NumNaturalWonders > max_NumNaturalWonders)
            {
                string max_NumNaturalWonders_warning = String.Format("Default game features only {0} Natural Wonders.\nSetting this value higher with or without mods might cause crashing.\n\n", max_NumNaturalWonders);
                warning_messages += max_NumNaturalWonders_warning;
            }
            // if PlateValue
            if (tested_PlateValue > max_PlateValue)
            {
                string max_PlateValue_warning = String.Format("Default game uses PlateValue of up to {0}. Exact nature of this setting is unclear yet.\nSetting this value higher with or without mods might cause crashing.\n\n", max_PlateValue);
                warning_messages += max_PlateValue_warning;
            }
            // if PlateValue
            if (tested_PlateValue < min_PlateValue)
            {
                string min_PlateValue_warning = String.Format("Default game uses PlateValue of at least {0}. Exact nature of this setting is unclear yet.\nSetting this value lower with or without mods might cause crashing.\n\n", min_PlateValue);
                warning_messages += min_PlateValue_warning;
            }
            // if Continents
            if (tested_Continents > max_Continents)
            {
                string max_Continents_warning = String.Format("Default game up to {0} Continents.\nSetting this value higher with or without mods might cause crashing.\n\n", max_Continents);
                warning_messages += max_Continents_warning;
            }
            // if Continents
            if (tested_Continents < min_Continents)
            {
                string min_Continents_warning = String.Format("Default game uses at least {0} Continents.\nSetting this value lower with or without mods might cause crashing.\n\n", min_Continents);
                warning_messages += min_Continents_warning;
            }
            // if MaxWorldInstances Great Prophet
            if (tested_NumNaturalWonders > max_MaxWorldInstances)
            {
                string max_NumNaturalWonders_warning = String.Format("Prophets are additionally limited by the number of beliefs in the game, which may override values here if they are too large.\nExact numbers were not checked but default religions on Huge maps is {0}.\n\n", max_MaxWorldInstances);
                warning_messages += max_NumNaturalWonders_warning;
            }
            if (!String.IsNullOrEmpty(warning_messages))
            {
                string message_append = "\n\nThose are only warnings.\nFeel free to experiment with game settings and mods increasing those values.\n";
                warning_messages += message_append;
            }
            return warning_messages;
        }
    }
}
