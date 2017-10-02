/*
Copyright 2017 Ryan Bales (https://github.com/ryanbales)
Date: 10/2/2017
Class: App/Program.cs

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/


using System;
using System.IO;
using FLIRImageProcessor.DataExtractor;
using FLIRImageProcessor.DataExtractor.Models;

namespace FLIRImageProcessor.App
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Validate Input Paramters
            if (args.Length == 0 || args[0] == null)
            {
                Console.WriteLine("Input File not specified.");

                // Wait for User Input
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();

                Environment.Exit(-1);
            }

            string imagePath = args[0];

            // Validate that the input file exists
            if (!File.Exists(imagePath))
            {
                Console.WriteLine("Input File: " + imagePath + " does not exist.");
                Console.WriteLine("Unable to Process File");

                // Wait for User Input
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();

                Environment.Exit(-1);
            }

            Console.WriteLine("Processing File: " + imagePath);

            // Process Image
            ImageProcessor imageProcesser = new ImageProcessor(imagePath);
            FlirImage flirImage = imageProcesser.FlirImageData;

            // Generate JSON output objecdt
            string json = imageProcesser.ToJson(flirImage);

            // Save JSON file
            string diretoryPath = Path.GetDirectoryName(imagePath);
            string fileName = Path.GetFileNameWithoutExtension(imagePath);
            string outputFilePath = diretoryPath + "\\" + fileName + ".json";
            File.WriteAllText(outputFilePath, json);
            Console.WriteLine("Data Saved to " + outputFilePath);

            // Wait for User Input
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        
            Environment.Exit(0);
        }
    }
}