using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using HedinsToolKit.Configuration;
using Xunit;

namespace HedinsToolKit.Tests.ConfigurationUnitTests
{
    public class SettingsJsonUnitTests
    {
        public string SettingsPath = "settings.json";

        [Fact]
        public void ReturnDefaultSettingsTest()
        {
            //Remove file from old tests.
            RemoveFileIfExsist(SettingsPath);
            // Create default settings (because the file does not exist).
            var exampleSettings = SettingsJson.Load<ExampleSettings>(SettingsPath);
            // Explicitly create default settings.
            var defaultExampleSettings = (ExampleSettings) exampleSettings.CreateDefault();
            // Compare
            СompareSettings(exampleSettings, defaultExampleSettings);

        }

        [Fact]
        public void SaveSettingsTest()
        {
            //Remove file from old tests
            RemoveFileIfExsist(SettingsPath);
            // Create nwe non-default settings
            var exampleSettings = new ExampleSettings
            {
                Count = 24,
                Text = "New example line",
                TypeCode = TypeCode.Boolean,
                Uri = new Uri("https://stackoverflow.com"),
                Value = 1.93
            };
            // Set path to file.
            exampleSettings.SetFilePath(SettingsPath);
            // Save settings to file.
            exampleSettings.Save();
            // Load settings
            var loadedSettings = SettingsJson.Load<ExampleSettings>(SettingsPath);
            // Compare
            СompareSettings(exampleSettings, loadedSettings);

        }


        #region Helpers

        private static void RemoveFileIfExsist(string path)
        {
            if (File.Exists(path))
                File.Delete(path);
        }
        private static void СompareSettings(ExampleSettings originSettings, ExampleSettings newSettings)
        {
            Assert.Equal(originSettings.Count, newSettings.Count);
            Assert.Equal(originSettings.Value, newSettings.Value);
            Assert.Equal(originSettings.TypeCode, newSettings.TypeCode);
            Assert.Equal(originSettings.Uri.AbsoluteUri, newSettings.Uri.AbsoluteUri);
            Assert.Equal(originSettings.TypeCode, newSettings.TypeCode);
        }

        #endregion

    }
}
