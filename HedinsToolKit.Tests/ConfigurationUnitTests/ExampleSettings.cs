using System;
using System.Collections.Generic;
using System.Text;
using HedinsToolKit.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HedinsToolKit.Tests.ConfigurationUnitTests
{
    public class ExampleSettings : SettingsJson
    {
        public int Count { get; set; }

        public Uri Uri { get; set; }

        public string Text { get; set; }

        public double Value { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public TypeCode TypeCode { get; set; } 

        public override SettingsJson CreateDefault()
        {
            return new ExampleSettings
            {
                Count = 42,
                Text = "Example line",
                TypeCode = TypeCode.DateTime,
                Uri = new Uri("https://goolge.com"),
                Value = 0.56
            };
        }
    }
}
