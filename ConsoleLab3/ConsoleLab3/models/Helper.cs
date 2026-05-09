﻿using System;
using System.Text;

namespace SpaceStationModel
{
    public static class Helper
    {
        public static string GetString(string prompt)
        {
            string value;

            do
            {
                Console.Write(prompt);
                value = Console.ReadLine();

                if (string.IsNullOrEmpty(value))
                    Console.WriteLine("|Error: value cannot be empty.");
            }
            while (string.IsNullOrEmpty(value));

            return value;
        }
    }
}