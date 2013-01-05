using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace QFA.Model
{
    public class Command
    {
        #region Properties

        /// <summary>
        /// Name of tile.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Value of tile [to be] stored in CSV.
        /// </summary>
        public string Letter { get; set; }

        /// <summary>
        /// Location of the tile image.
        /// </summary>
        public string ImagePath { get; set; }

        /// <summary>
        /// Keyboard hotkey for tile.
        /// </summary>
        public Key Hotkey { get; set; }

        /// <summary>
        /// Designation = 1, Build = 2, Traps = 3, Machines = 4
        /// </summary>
        public int Mode { get; set; }

        /// <summary>
        /// Foreground color. To be fully implemented later.
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Background color of tile.
        /// </summary>
        public string BackgroundColor { get; set; }

        /// <summary>
        /// Is the tile an individual or part of a block?
        /// 'indiv' or 'block'
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Number of tiles on Y axis.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Number of tiles on X axis.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Unicode value of tile.  Kept for posterity.
        /// </summary>
        public string Unicode { get; set; }

        /// <summary>
        /// Index value of command.
        /// </summary>
        public int Index { get; set; }

        #endregion



        public Command GetCommandByLetter(string letter, int mode)
        {
            return (from x in Commands
                    where x.Letter == letter && x.Mode == mode
                    select x).FirstOrDefault();

        }

        #region Commands
        
        public static readonly List<Command> Commands = new List<Command>
            {
                (new Command { Index = 0, Name = "Blank", Color = "FF000000", BackgroundColor = "FF000000", Hotkey = Key.Space, ImagePath = "tile_0.png", Letter = "", Mode = 0, Type = "indiv", Width = 1, Height = 1, Unicode = "0" }),
                (new Command { Index = 1, Name = "Mine", Color = "FF888800", BackgroundColor = "FF888800", Hotkey = Key.D, ImagePath = "tile_219.png", Letter = "d", Mode = 0, Type = "indiv", Width = 1, Height = 1, Unicode = "2588" }),
                (new Command { Index = 2, Name = "Channel", Color = "FF888800", BackgroundColor = "FF000000", Hotkey = Key.H, ImagePath = "tile_95.png", Letter = "h", Mode = 0, Type = "indiv", Width = 1, Height = 1, Unicode = "5F" }),
                (new Command { Index = 3, Name = "Remove Up Stairs/Ramps", Color = "FFFFFF00", BackgroundColor = "FF000000", Hotkey = Key.U, ImagePath = "tile_60.png", Letter = "u", Mode = 0, Type = "indiv", Width = 1, Height = 1, Unicode = "3C" }),
                (new Command { Index = 4, Name = "Upward Stairway", Color = "FF888800", BackgroundColor = "FF000000", Hotkey = Key.U, ImagePath = "tile_60.png", Letter = "u", Mode = 0, Type = "indiv", Width = 1, Height = 1, Unicode = "3C" }),
                (new Command { Index = 5, Name = "Downward Stairway", Color = "FF888800", BackgroundColor = "FF000000", Hotkey = Key.J, ImagePath = "tile_62.png", Letter = "j", Mode = 0, Type = "indiv", Width = 1, Height = 1, Unicode = "3E" }),
                (new Command { Index = 6, Name = "Up/Down Stairway", Color = "FF888800", BackgroundColor = "FF000000", Hotkey = Key.I, ImagePath = "tile_88.png", Letter = "i", Mode = 0, Type = "indiv", Width = 1, Height = 1, Unicode = "58" }),
                (new Command { Index = 7, Name = "Upward Ramp", Color = "FF888800", BackgroundColor = "FF000000", Hotkey = Key.R, ImagePath = "tile_30.png", Letter = "r", Mode = 0, Type = "indiv", Width = 1, Height = 1, Unicode = "25B2" }),
                (new Command { Index = 8, Name = "Chop Down Trees", Color = "FF888800", BackgroundColor = "FF000000", Hotkey = Key.T, ImagePath = "tile_6.png", Letter = "t", Mode = 0, Type = "indiv", Width = 1, Height = 1, Unicode = "2660" }),
                (new Command { Index = 9, Name = "Gather Plants", Color = "FF888800", BackgroundColor = "FF000000", Hotkey = Key.P, ImagePath = "tile_34.png", Letter = "p", Mode = 0, Type = "indiv", Width = 1, Height = 1, Unicode = "22" }),
                (new Command { Index = 10, Name = "Smooth Stone", Color = "FF888800", BackgroundColor = "FF000000", Hotkey = Key.S, ImagePath = "tile_43.png", Letter = "s", Mode = 0, Type = "indiv", Width = 1, Height = 1, Unicode = "2B" }),
                (new Command { Index = 11, Name = "Engrave Stone", Color = "FFFFFF00", BackgroundColor = "FF000000", Hotkey = Key.E, ImagePath = "tile_206.png", Letter = "e", Mode = 0, Type = "indiv", Width = 1, Height = 1, Unicode = "256C" }),
                (new Command { Index = 12, Name = "Carve Fortifications", Color = "FF888800", BackgroundColor = "FF000000", Hotkey = Key.A, ImagePath = "tile_206.png", Letter = "a", Mode = 0, Type = "indiv", Width = 1, Height = 1, Unicode = "256C" }),
                (new Command { Index = 13, Name = "Toggle Engravings", Color = "FF888800", BackgroundColor = "FF000000", Hotkey = Key.V, ImagePath = "tile_206.png", Letter = "v", Mode = 0, Type = "indiv", Width = 1, Height = 1, Unicode = "256C" }),
                (new Command { Index = 14, Name = "Remove Designation", Color = "FFFFFF00", BackgroundColor = "FFFFFF00", Hotkey = Key.X, ImagePath = "tile_0.png", Letter = "x", Mode = 0, Type = "indiv", Width = 1, Height = 1, Unicode = "2588" }),
                (new Command { Index = 15, Name = "Remove Construction", Color = "FFFFFF00", BackgroundColor = "FF000000", Hotkey = Key.N, ImagePath = "tile_111.png", Letter = "n", Mode = 0, Type = "indiv", Width = 1, Height = 1, Unicode = "6F" }),
                (new Command { Index = 16, Name = "Armor Stand", Color = "FF888800", BackgroundColor = "FF000000", Hotkey = Key.A, ImagePath = "tile_14.png", Letter = "a", Mode = 1, Type = "indiv", Width = 1, Height = 1, Unicode = "266B" }),
                (new Command { Index = 17, Name = "Bed", Color = "FF888800", BackgroundColor = "FF000000", Hotkey = Key.B, ImagePath = "tile_233.png", Letter = "b", Mode = 1, Type = "indiv", Width = 1, Height = 1, Unicode = "398" }),
                (new Command { Index = 18, Name = "Seat", Color = "FF888800", BackgroundColor = "FF000000", Hotkey = Key.C, ImagePath = "tile_210.png", Letter = "c", Mode = 1, Type = "indiv", Width = 1, Height = 1, Unicode = "2565" }),
                (new Command { Index = 19, Name = "Burial Receptacle", Color = "FF888800", BackgroundColor = "FF000000", Hotkey = Key.N, ImagePath = "tile_60.png", Letter = "n", Mode = 1, Type = "indiv", Width = 1, Height = 1, Unicode = "3C" }),
                (new Command { Index = 20, Name = "Door", Color = "FF888800", BackgroundColor = "FF000000", Hotkey = Key.D, ImagePath = "tile_197.png", Letter = "d", Mode = 1, Type = "indiv", Width = 1, Height = 1, Unicode = "253C" }),
                (new Command { Index = 21, Name = "Floodgate", Color = "FF888800", BackgroundColor = "FF000000", Hotkey = Key.X, ImagePath = "tile_88.png", Letter = "x", Mode = 1, Type = "indiv", Width = 1, Height = 1, Unicode = "58" }),
                (new Command { Index = 22, Name = "Floor Hatch", Color = "FF888800", BackgroundColor = "FF000000", Hotkey = Key.H, ImagePath = "tile_155.png", Letter = "H", Mode = 1, Type = "indiv", Width = 1, Height = 1, Unicode = "A2" }),
                (new Command { Index = 23, Name = "Wall Grate", Color = "FF888800", BackgroundColor = "FF000000", Hotkey = Key.W, ImagePath = "tile_215.png", Letter = "W", Mode = 1, Type = "indiv", Width = 1, Height = 1, Unicode = "256B" }),
                (new Command { Index = 24, Name = "Floor Grate", Color = "FF888800", BackgroundColor = "FF000000", Hotkey = Key.G, ImagePath = "tile_35.png", Letter = "G", Mode = 1, Type = "indiv", Width = 1, Height = 1, Unicode = "23" }),
                (new Command { Index = 25, Name = "Vertical Bars", Color = "FF888800", BackgroundColor = "FF000000", Hotkey = Key.B, ImagePath = "tile_19.png", Letter = "B", Mode = 1, Type = "indiv", Width = 1, Height = 1, Unicode = "203C" }),
                (new Command { Index = 26, Name = "Floor Bars", Color = "FF888800", BackgroundColor = "FF000000", Hotkey = Key.None, ImagePath = "tile_240.png", Letter = "Alt+b", Mode = 1, Type = "indiv", Width = 1, Height = 1, Unicode = "2261" }),
                (new Command { Index = 27, Name = "Cabinet", Color = "FF888800", BackgroundColor = "FF000000", Hotkey = Key.F, ImagePath = "tile_227.png", Letter = "f", Mode = 1, Type = "indiv", Width = 1, Height = 1, Unicode = "3C0" }),
                (new Command { Index = 28, Name = "Container", Color = "FFFFFF00", BackgroundColor = "FF000000", Hotkey = Key.H, ImagePath = "tile_88.png", Letter = "h", Mode = 1, Type = "indiv", Width = 1, Height = 1, Unicode = "58" }),
                (new Command { Index = 29, Name = "Weapon Rack", Color = "FF888800", BackgroundColor = "FF000000", Hotkey = Key.R, ImagePath = "tile_251.png", Letter = "r", Mode = 1, Type = "indiv", Width = 1, Height = 1, Unicode = "221A" }),
                (new Command { Index = 30, Name = "Statue", Color = "FF888800", BackgroundColor = "FF000000", Hotkey = Key.S, ImagePath = "tile_234.png", Letter = "s", Mode = 1, Type = "indiv", Width = 1, Height = 1, Unicode = "3A9" }),
                (new Command { Index = 31, Name = "Table", Color = "FF888800", BackgroundColor = "FF000000", Hotkey = Key.T, ImagePath = "tile_209.png", Letter = "t", Mode = 1, Type = "indiv", Width = 1, Height = 1, Unicode = "2564" }),
                (new Command { Index = 32, Name = "Paved Road", Color = "FF888800", BackgroundColor = "FF000000", Hotkey = Key.O, ImagePath = "tile_241.png", Letter = "o", Mode = 1, Type = "indiv", Width = 1, Height = 1, Unicode = "B1" }),
                (new Command { Index = 33, Name = "Dirt Road", Color = "FF888800", BackgroundColor = "FF000000", Hotkey = Key.O, ImagePath = "tile_126.png", Letter = "O", Mode = 1, Type = "indiv", Width = 1, Height = 1, Unicode = "7E" }),
                (new Command { Index = 34, Name = "Well", Color = "FF888800", BackgroundColor = "FF000000", Hotkey = Key.L, ImagePath = "tile_9.png", Letter = "l", Mode = 1, Type = "indiv", Width = 1, Height = 1, Unicode = "25CB" }),
                (new Command { Index = 35, Name = "Glass Window", Color = "FF888800", BackgroundColor = "FF000000", Hotkey = Key.Y, ImagePath = "tile_176.png", Letter = "y", Mode = 1, Type = "indiv", Width = 1, Height = 1, Unicode = "2591" }),
                (new Command { Index = 36, Name = "Gem Window", Color = "FF8888CC", BackgroundColor = "FF000000", Hotkey = Key.Y, ImagePath = "tile_176.png", Letter = "Y", Mode = 1, Type = "indiv", Width = 1, Height = 1, Unicode = "2591" }),
                (new Command { Index = 37, Name = "Support", Color = "FF888800", BackgroundColor = "FF000000", Hotkey = Key.S, ImagePath = "tile_73.png", Letter = "S", Mode = 1, Type = "indiv", Width = 1, Height = 1, Unicode = "49" }),
                (new Command { Index = 38, Name = "Animal Trap", Color = "FF888800", BackgroundColor = "FF000000", Hotkey = Key.M, ImagePath = "tile_127.png", Letter = "m", Mode = 1, Type = "indiv", Width = 1, Height = 1, Unicode = "2302" }),
                (new Command { Index = 39, Name = "Restraint", Color = "FF888800", BackgroundColor = "FF000000", Hotkey = Key.V, ImagePath = "tile_21.png", Letter = "v", Mode = 1, Type = "indiv", Width = 1, Height = 1, Unicode = "A7" }),
                (new Command { Index = 40, Name = "Cage", Color = "FF8888CC", BackgroundColor = "FF000000", Hotkey = Key.J, ImagePath = "tile_19.png", Letter = "j", Mode = 1, Type = "indiv", Width = 1, Height = 1, Unicode = "203C" }),
                (new Command { Index = 41, Name = "Archery Target", Color = "FF8888CC", BackgroundColor = "FF000000", Hotkey = Key.A, ImagePath = "tile_246.png", Letter = "A", Mode = 1, Type = "indiv", Width = 1, Height = 1, Unicode = "F7" }),
                (new Command { Index = 42, Name = "Traction Bench", Color = "FF888800", BackgroundColor = "FF000000", Hotkey = Key.R, ImagePath = "tile_232.png", Letter = "R", Mode = 1, Type = "indiv", Width = 1, Height = 1, Unicode = "3A6" }),
                (new Command { Index = 43, Name = "Wall", Color = "FF888800", BackgroundColor = "FF000000", Hotkey = Key.W, ImagePath = "tile_186.png", Letter = "Cw", Mode = 2, Type = "indiv", Width = 1, Height = 1, Unicode = "2551" }),
                (new Command { Index = 44, Name = "Floor", Color = "FF888800", BackgroundColor = "FF000000", Hotkey = Key.F, ImagePath = "tile_43.png", Letter = "Cf", Mode = 2, Type = "indiv", Width = 1, Height = 1, Unicode = "2B" }),
                (new Command { Index = 45, Name = "Ramp", Color = "FF888800", BackgroundColor = "FF000000", Hotkey = Key.R, ImagePath = "tile_30.png", Letter = "Cr", Mode = 2, Type = "indiv", Width = 1, Height = 1, Unicode = "25B2" }),
                (new Command { Index = 46, Name = "Up Stair", Color = "FF888800", BackgroundColor = "FF000000", Hotkey = Key.U, ImagePath = "tile_60.png", Letter = "Cu", Mode = 2, Type = "indiv", Width = 1, Height = 1, Unicode = "3C" }),
                (new Command { Index = 47, Name = "Down Stair", Color = "FF888800", BackgroundColor = "FF000000", Hotkey = Key.D, ImagePath = "tile_62.png", Letter = "Cd", Mode = 2, Type = "indiv", Width = 1, Height = 1, Unicode = "3E" }),
                (new Command { Index = 48, Name = "Up/Down Stair", Color = "FF888800", BackgroundColor = "FF000000", Hotkey = Key.X, ImagePath = "tile_88.png", Letter = "Cx", Mode = 2, Type = "indiv", Width = 1, Height = 1, Unicode = "58" }),
                (new Command { Index = 49, Name = "Fortification", Color = "FF888800", BackgroundColor = "FF000000", Hotkey = Key.F, ImagePath = "tile_206.png", Letter = "CF", Mode = 2, Type = "indiv", Width = 1, Height = 1, Unicode = "256C" }),
                (new Command { Index = 50, Name = "Stone Fall", Color = "FF888800", BackgroundColor = "FF000000", Hotkey = Key.S, ImagePath = "tile_94.png", Letter = "Ts", Mode = 3, Type = "indiv", Width = 1, Height = 1, Unicode = "5E" }),
                (new Command { Index = 51, Name = "Weapon Trap", Color = "FF888800", BackgroundColor = "FF000000", Hotkey = Key.W, ImagePath = "tile_228.png", Letter = "Tw", Mode = 3, Type = "indiv", Width = 1, Height = 1, Unicode = "3A3" }),
                (new Command { Index = 52, Name = "Lever", Color = "FF888800", BackgroundColor = "FF000000", Hotkey = Key.L, ImagePath = "tile_149.png", Letter = "Tl", Mode = 3, Type = "indiv", Width = 1, Height = 1, Unicode = "F2" }),
                (new Command { Index = 53, Name = "Cage Trap", Color = "FFFFFF00", BackgroundColor = "FF000000", Hotkey = Key.C, ImagePath = "tile_19.png", Letter = "Tc", Mode = 3, Type = "indiv", Width = 1, Height = 1, Unicode = "203C" }),
                (new Command { Index = 54, Name = "Upright Spear", Color = "FF8888CC", BackgroundColor = "FF000000", Hotkey = Key.S, ImagePath = "tile_94.png", Letter = "TS", Mode = 3, Type = "indiv", Width = 1, Height = 1, Unicode = "5E" }),
                (new Command { Index = 55, Name = "Gear Assembly", Color = "FF888800", BackgroundColor = "FF000000", Hotkey = Key.G, ImagePath = "tile_15.png", Letter = "Mg", Mode = 4, Type = "indiv", Width = 1, Height = 1, Unicode = "263C" }),
                (new Command { Index = 56, Name = "Waterwheel N/S", Color = "FF000000", BackgroundColor = "FFFFFF00", Hotkey = Key.W, ImagePath = "tile_205.png", Letter = "Mw", Mode = 4, Type = "block", Width = 1, Height = 4, Unicode = "2550" }),
                (new Command { Index = 57, Name = "Waterwheel E/W", Color = "FF000000", BackgroundColor = "FFFFFF00", Hotkey = Key.S, ImagePath = "tile_186.png", Letter = "Mws", Mode = 4, Type = "block", Width = 3, Height = 1, Unicode = "2551" }),
                (new Command { Index = 58, Name = "Windmill", Color = "FFFFFF00", BackgroundColor = "FF000000", Hotkey = Key.S, ImagePath = "tile_186.png", Letter = "Mm", Mode = 4, Type = "block", Width = 3, Height = 4, Unicode = "2551" }),
                (new Command { Index = 59, Name = "Vertical Axle", Color = "FF888800", BackgroundColor = "FF000000", Hotkey = Key.M, ImagePath = "tile_9.png", Letter = "M", Mode = 4, Type = "indiv", Width = 1, Height = 1, Unicode = "25CB" }),
                (new Command { Index = 60, Name = "Axle N/S", Color = "FFFFFF00", BackgroundColor = "FF000000", Hotkey = Key.S, ImagePath = "tile_205.png", Letter = "Mhs", Mode = 4, Type = "indiv", Width = 1, Height = 1, Unicode = "2550" }),
                (new Command { Index = 61, Name = "Axle E/W", Color = "FFFFFF00", BackgroundColor = "FF000000", Hotkey = Key.H, ImagePath = "tile_186.png", Letter = "Mh", Mode = 4, Type = "indiv", Width = 1, Height = 1, Unicode = "2551" }),
                (new Command { Index = 62, Name = "Blank", Color = "FF000000", BackgroundColor = "FF000000", Hotkey = Key.Space, ImagePath = "tile_0.png", Letter = "", Mode = 1, Type = "indiv", Width = 1, Height = 1, Unicode = "0" })
            };
        #endregion
    }

   
}
