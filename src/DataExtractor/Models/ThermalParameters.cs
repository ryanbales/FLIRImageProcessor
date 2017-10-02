﻿/*
Copyright 2017 Ryan Bales (https://github.com/ryanbales)
Date: 10/2/2017
Class: DataExtractor/Models/ThermalParameters.cs

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


namespace FLIRImageProcessor.DataExtractor.Models
{
    public class ThermalParameters
    {
        public double AtmosphericTemperature { get; set; }
        public double Distance { get; set; }
        public double Emissivity { get; set; }
        public double ExternalOpticsTemperature { get; set; }
        public double ExternalOpticsTransmission { get; set; }
        public double ReferenceTemperature { get; set; }
        public double ReflectedTemperature { get; set; }
        public double RelativeHumidity { get; set; }
        public double Transmission { get; set; }
    }
}