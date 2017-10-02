/*
Copyright 2017 Ryan Bales (https://github.com/ryanbales)
Date: 10/2/2017
Class: DataExtractor/Models/CameraInfo.cs

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
    public class CameraInfo
    {
        public string Filter { get; set; }
        public double Fov { get; set; }
        public string Lens { get; set; }
        public string Model { get; set; }
        public double RangeMin { get; set; }
        public double RangeMax { get; set; }
        public string SerialNumber { get; set; }
    }
}