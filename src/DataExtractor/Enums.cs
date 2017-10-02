/*
Copyright 2017 Ryan Bales (https://github.com/ryanbales)
Date: 10/2/2017
Class: DataExtractor/Enums.cs

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

using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FLIRImageProcessor.DataExtractor
{
    public class Enums
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TemperatureUnit
        {
            [EnumMember(Value = "Celsius")]
            Celsius,
            [EnumMember(Value = "Fahrenheit")]
            Fahrenheit,
            [EnumMember(Value = "Kelvin")]
            Kelvin,
            [EnumMember(Value = "Signal")]
            Signal
        }
    }
}