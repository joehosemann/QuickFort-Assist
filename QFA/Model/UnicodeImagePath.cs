﻿using System;
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
    public class UnicodeImagePath
    {
        public string Unicode { get; set; }
        public string ImagePath { get; set; }
        public int Index { get; set; }

        /// <summary>
        /// Kept strictly for posterity sake.
        /// </summary>
        /// <returns></returns>


        public static List<UnicodeImagePath> UnicodeImagePaths()
        {
            var unicodeImagePaths = new List<UnicodeImagePath>();
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "0", ImagePath = "tile_0.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "263A", ImagePath = "tile_1.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "263B", ImagePath = "tile_2.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "2665", ImagePath = "tile_3.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "2666", ImagePath = "tile_4.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "2663", ImagePath = "tile_5.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "2660", ImagePath = "tile_6.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "2022", ImagePath = "tile_7.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "25D8", ImagePath = "tile_8.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "25CB", ImagePath = "tile_9.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "25D9", ImagePath = "tile_10.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "2642", ImagePath = "tile_11.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "2640", ImagePath = "tile_12.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "266A", ImagePath = "tile_13.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "266B", ImagePath = "tile_14.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "263C", ImagePath = "tile_15.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "25BA", ImagePath = "tile_16.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "25C4", ImagePath = "tile_17.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "2195", ImagePath = "tile_18.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "203C", ImagePath = "tile_19.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "B6", ImagePath = "tile_20.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "A7", ImagePath = "tile_21.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "25AC", ImagePath = "tile_22.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "21A8", ImagePath = "tile_23.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "2191", ImagePath = "tile_24.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "2193", ImagePath = "tile_25.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "2192", ImagePath = "tile_26.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "2190", ImagePath = "tile_27.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "221F", ImagePath = "tile_28.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "2194", ImagePath = "tile_29.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "25B2", ImagePath = "tile_30.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "25BC", ImagePath = "tile_31.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "20", ImagePath = "tile_32.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "21", ImagePath = "tile_33.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "22", ImagePath = "tile_34.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "23", ImagePath = "tile_35.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "24", ImagePath = "tile_36.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "25", ImagePath = "tile_37.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "26", ImagePath = "tile_38.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "27", ImagePath = "tile_39.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "28", ImagePath = "tile_40.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "29", ImagePath = "tile_41.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "2A", ImagePath = "tile_42.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "2B", ImagePath = "tile_43.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "2C", ImagePath = "tile_44.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "2D", ImagePath = "tile_45.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "2E", ImagePath = "tile_46.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "2F", ImagePath = "tile_47.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "30", ImagePath = "tile_48.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "31", ImagePath = "tile_49.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "32", ImagePath = "tile_50.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "33", ImagePath = "tile_51.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "34", ImagePath = "tile_52.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "35", ImagePath = "tile_53.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "36", ImagePath = "tile_54.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "37", ImagePath = "tile_55.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "38", ImagePath = "tile_56.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "39", ImagePath = "tile_57.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "3A", ImagePath = "tile_58.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "3B", ImagePath = "tile_59.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "3C", ImagePath = "tile_60.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "3D", ImagePath = "tile_61.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "3E", ImagePath = "tile_62.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "3F", ImagePath = "tile_63.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "40", ImagePath = "tile_64.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "41", ImagePath = "tile_65.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "42", ImagePath = "tile_66.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "43", ImagePath = "tile_67.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "44", ImagePath = "tile_68.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "45", ImagePath = "tile_69.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "46", ImagePath = "tile_70.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "47", ImagePath = "tile_71.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "48", ImagePath = "tile_72.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "49", ImagePath = "tile_73.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "4A", ImagePath = "tile_74.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "4B", ImagePath = "tile_75.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "4C", ImagePath = "tile_76.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "4D", ImagePath = "tile_77.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "4E", ImagePath = "tile_78.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "4F", ImagePath = "tile_79.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "50", ImagePath = "tile_80.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "51", ImagePath = "tile_81.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "52", ImagePath = "tile_82.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "53", ImagePath = "tile_83.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "54", ImagePath = "tile_84.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "55", ImagePath = "tile_85.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "56", ImagePath = "tile_86.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "57", ImagePath = "tile_87.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "58", ImagePath = "tile_88.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "59", ImagePath = "tile_89.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "5A", ImagePath = "tile_90.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "5B", ImagePath = "tile_91.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "5C", ImagePath = "tile_92.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "5D", ImagePath = "tile_93.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "5E", ImagePath = "tile_94.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "5F", ImagePath = "tile_95.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "60", ImagePath = "tile_96.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "61", ImagePath = "tile_97.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "62", ImagePath = "tile_98.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "63", ImagePath = "tile_99.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "64", ImagePath = "tile_100.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "65", ImagePath = "tile_101.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "66", ImagePath = "tile_102.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "67", ImagePath = "tile_103.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "68", ImagePath = "tile_104.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "69", ImagePath = "tile_105.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "6A", ImagePath = "tile_106.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "6B", ImagePath = "tile_107.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "6C", ImagePath = "tile_108.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "6D", ImagePath = "tile_109.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "6E", ImagePath = "tile_110.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "6F", ImagePath = "tile_111.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "70", ImagePath = "tile_112.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "71", ImagePath = "tile_113.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "72", ImagePath = "tile_114.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "73", ImagePath = "tile_115.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "74", ImagePath = "tile_116.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "75", ImagePath = "tile_117.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "76", ImagePath = "tile_118.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "77", ImagePath = "tile_119.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "78", ImagePath = "tile_120.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "79", ImagePath = "tile_121.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "7A", ImagePath = "tile_122.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "7B", ImagePath = "tile_123.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "7C", ImagePath = "tile_124.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "7D", ImagePath = "tile_125.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "7E", ImagePath = "tile_126.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "2302", ImagePath = "tile_127.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "C7", ImagePath = "tile_128.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "FC", ImagePath = "tile_129.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "E9", ImagePath = "tile_130.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "E2", ImagePath = "tile_131.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "E4", ImagePath = "tile_132.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "E0", ImagePath = "tile_133.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "E5", ImagePath = "tile_134.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "E7", ImagePath = "tile_135.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "EA", ImagePath = "tile_136.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "EB", ImagePath = "tile_137.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "E8", ImagePath = "tile_138.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "EF", ImagePath = "tile_139.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "EE", ImagePath = "tile_140.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "EC", ImagePath = "tile_141.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "C4", ImagePath = "tile_142.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "C5", ImagePath = "tile_143.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "C9", ImagePath = "tile_144.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "E6", ImagePath = "tile_145.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "C6", ImagePath = "tile_146.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "F4", ImagePath = "tile_147.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "F6", ImagePath = "tile_148.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "F2", ImagePath = "tile_149.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "FB", ImagePath = "tile_150.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "F9", ImagePath = "tile_151.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "FF", ImagePath = "tile_152.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "D6", ImagePath = "tile_153.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "DC", ImagePath = "tile_154.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "A2", ImagePath = "tile_155.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "A3", ImagePath = "tile_156.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "A5", ImagePath = "tile_157.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "20A7", ImagePath = "tile_158.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "192", ImagePath = "tile_159.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "E1", ImagePath = "tile_160.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "ED", ImagePath = "tile_161.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "F3", ImagePath = "tile_162.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "FA", ImagePath = "tile_163.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "F1", ImagePath = "tile_164.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "D1", ImagePath = "tile_165.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "AA", ImagePath = "tile_166.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "BA", ImagePath = "tile_167.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "BF", ImagePath = "tile_168.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "2310", ImagePath = "tile_169.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "AC", ImagePath = "tile_170.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "BD", ImagePath = "tile_171.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "BC", ImagePath = "tile_172.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "A1", ImagePath = "tile_173.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "AB", ImagePath = "tile_174.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "BB", ImagePath = "tile_175.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "2591", ImagePath = "tile_176.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "2592", ImagePath = "tile_177.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "2593", ImagePath = "tile_178.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "2502", ImagePath = "tile_179.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "2524", ImagePath = "tile_180.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "2561", ImagePath = "tile_181.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "2562", ImagePath = "tile_182.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "2556", ImagePath = "tile_183.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "2555", ImagePath = "tile_184.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "2563", ImagePath = "tile_185.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "2551", ImagePath = "tile_186.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "2557", ImagePath = "tile_187.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "255D", ImagePath = "tile_188.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "255C", ImagePath = "tile_189.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "255B", ImagePath = "tile_190.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "2510", ImagePath = "tile_191.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "2514", ImagePath = "tile_192.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "2534", ImagePath = "tile_193.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "252C", ImagePath = "tile_194.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "251C", ImagePath = "tile_195.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "2500", ImagePath = "tile_196.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "253C", ImagePath = "tile_197.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "255E", ImagePath = "tile_198.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "255F", ImagePath = "tile_199.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "255A", ImagePath = "tile_200.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "2554", ImagePath = "tile_201.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "2569", ImagePath = "tile_202.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "2566", ImagePath = "tile_203.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "2560", ImagePath = "tile_204.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "2550", ImagePath = "tile_205.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "256C", ImagePath = "tile_206.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "2567", ImagePath = "tile_207.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "2568", ImagePath = "tile_208.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "2564", ImagePath = "tile_209.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "2565", ImagePath = "tile_210.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "2559", ImagePath = "tile_211.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "2558", ImagePath = "tile_212.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "2552", ImagePath = "tile_213.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "2553", ImagePath = "tile_214.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "256B", ImagePath = "tile_215.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "256A", ImagePath = "tile_216.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "2518", ImagePath = "tile_217.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "250C", ImagePath = "tile_218.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "2588", ImagePath = "tile_219.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "2584", ImagePath = "tile_220.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "258C", ImagePath = "tile_221.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "2590", ImagePath = "tile_222.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "2580", ImagePath = "tile_223.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "3B1", ImagePath = "tile_224.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "DF", ImagePath = "tile_225.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "393", ImagePath = "tile_226.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "3C0", ImagePath = "tile_227.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "3A3", ImagePath = "tile_228.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "3C3", ImagePath = "tile_229.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "B5", ImagePath = "tile_230.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "3C4", ImagePath = "tile_231.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "3A6", ImagePath = "tile_232.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "398", ImagePath = "tile_233.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "3A9", ImagePath = "tile_234.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "3B4", ImagePath = "tile_235.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "221E", ImagePath = "tile_236.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "3C6", ImagePath = "tile_237.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "3B5", ImagePath = "tile_238.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "2229", ImagePath = "tile_239.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "2261", ImagePath = "tile_240.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "B1", ImagePath = "tile_241.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "2265", ImagePath = "tile_242.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "2264", ImagePath = "tile_243.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "2320", ImagePath = "tile_244.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "2321", ImagePath = "tile_245.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "F7", ImagePath = "tile_246.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "2248", ImagePath = "tile_247.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "B0", ImagePath = "tile_248.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "2219", ImagePath = "tile_249.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "B7", ImagePath = "tile_250.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "221A", ImagePath = "tile_251.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "207F", ImagePath = "tile_252.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "B2", ImagePath = "tile_253.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "25A0", ImagePath = "tile_254.png" });
            unicodeImagePaths.Add(new UnicodeImagePath { Unicode = "A0", ImagePath = "tile_255.png" });


            return unicodeImagePaths;
        }
    }
}
