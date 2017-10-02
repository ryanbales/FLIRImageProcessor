/*
Copyright 2017 Ryan Bales (https://github.com/ryanbales)
Date: 10/2/2017
Class: DataExtractor/ImageProcessor.cs

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
using System.Collections.Generic;
using System.Drawing;
using Flir.Atlas.Image;
using FLIRImageProcessor.DataExtractor.Models;
using Newtonsoft.Json;


namespace FLIRImageProcessor.DataExtractor
{
    public class ImageProcessor
    {
        private readonly FlirImage _flirImageData;

        public ImageProcessor()
        {
        }

        public ImageProcessor(string imageFilePath)
        {
            FlirImageFile = new ThermalImageFile(imageFilePath);
            _flirImageData = ProcessImage(FlirImageFile);
        }

        public ThermalImageFile FlirImageFile { get; }

        public FlirImage FlirImageData
        {
            get { return _flirImageData; }
        }

        private FlirImage ProcessImage(ThermalImageFile thermalImage)
        {
            FlirImage flirImageData = new FlirImage
            {
                DateTaken = thermalImage.DateTaken,
                Description = thermalImage.Description,
                Height = thermalImage.Height,
                MaxSignalValue = thermalImage.MaxSignalValue,
                MinSignalValue = thermalImage.MinSignalValue,
                Precision = thermalImage.Precision,
                TemperatureUnit = (Enums.TemperatureUnit) Enum.Parse(typeof(Enums.TemperatureUnit),
                    thermalImage.TemperatureUnit.ToString()),
                Width = thermalImage.Width,
                ThermalData = ExtractTemperatureReadings(thermalImage),
                Title = thermalImage.Title
            };

            if (thermalImage.CameraInformation != null)
                flirImageData.CameraInfo = new CameraInfo
                {
                    Filter = thermalImage.CameraInformation.Filter,
                    Fov = thermalImage.CameraInformation.Fov,
                    Lens = thermalImage.CameraInformation.Lens,
                    Model = thermalImage.CameraInformation.Model,
                    RangeMax = thermalImage.CameraInformation.Range.Maximum,
                    RangeMin = thermalImage.CameraInformation.Range.Minimum,
                    SerialNumber = thermalImage.CameraInformation.SerialNumber
                };

            if (thermalImage.CompassInformation != null)
                flirImageData.CompassInfo = new Models.CompassInfo
                {
                    Degrees = thermalImage.CompassInformation.Degrees,
                    Pitch = thermalImage.CompassInformation.Pitch,
                    Roll = thermalImage.CompassInformation.Roll
                };

            if (thermalImage.GpsInformation != null)
                flirImageData.GpsInfo = new GpsInfo
                {
                    Altitude = thermalImage.GpsInformation.Altitude,
                    Dop = thermalImage.GpsInformation.Dop,
                    Latitude = thermalImage.GpsInformation.Latitude,
                    Longitude = thermalImage.GpsInformation.Longitude,
                    MapDatum = thermalImage.GpsInformation.MapDatum,
                    Satellites = thermalImage.GpsInformation.Satellites
                };

            if (thermalImage.ThermalParameters != null)
                flirImageData.ThermalParameters = new ThermalParameters
                {
                    AtmosphericTemperature = thermalImage.ThermalParameters.AtmosphericTemperature,
                    Distance = thermalImage.ThermalParameters.Distance,
                    Emissivity = thermalImage.ThermalParameters.Emissivity,
                    ExternalOpticsTemperature = thermalImage.ThermalParameters.ExternalOpticsTemperature,
                    ExternalOpticsTransmission = thermalImage.ThermalParameters.ExternalOpticsTransmission,
                    ReferenceTemperature = thermalImage.ThermalParameters.ReferenceTemperature,
                    ReflectedTemperature = thermalImage.ThermalParameters.ReflectedTemperature,
                    RelativeHumidity = thermalImage.ThermalParameters.RelativeHumidity,
                    Transmission = thermalImage.ThermalParameters.Transmission
                };

            return flirImageData;
        }

        private IList<ThermalData> ExtractTemperatureReadings(ThermalImageFile thermalImage)
        {
            IList<ThermalData> thermalData = new List<ThermalData>();

            // Load Raw PixelData
            double[,] rawThermalData = thermalImage.ImageProcessing.GetPixelsArray();

            for (int y = 0; y <= thermalImage.Size.Height - 1; y++)
            for (int x = 0; x <= thermalImage.Size.Width - 1; x++)
            {
                // Get ThermalValue from Image
                ThermalValue thermalValue = thermalImage.GetValueAt(new Point(x, y));

                // Build Data Object and Add to ThermalData List
                thermalData.Add(new ThermalData
                {
                    X = x,
                    Y = y,
                    RawValue = rawThermalData[y, x],
                    TemperatureValue = thermalValue.Value,
                    TemperatureUnit = (Enums.TemperatureUnit) Enum.Parse(typeof(Enums.TemperatureUnit),
                        thermalImage.TemperatureUnit.ToString())
                });
            }

            return thermalData;
        }

        public string ToJson(FlirImage flirImageData)
        {
            return JsonConvert.SerializeObject(flirImageData);
        }
    }
}