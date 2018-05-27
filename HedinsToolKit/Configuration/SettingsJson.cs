using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace HedinsToolKit.Configuration
{
    public abstract class SettingsJson
    {
      
        #region Properties

        /// <summary>
        /// Default file path.
        /// </summary>
        [JsonIgnore]
        public string FilePath { get; private set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Create default settings.
        /// </summary>
        /// <returns>Default settings</returns>
        public abstract SettingsJson CreateDefault();

        /// <summary>
        /// Save settings to <see cref="FilePath"/>
        /// </summary>
        public virtual void Save() => Save(this);
        /// <summary>
        /// Save settings to custom path.
        /// <see cref="FilePath"/> does not change.
        /// </summary>
        /// <param name="filePath">Path to file</param>
        public virtual void Save(string filePath)
        {
            Save(this, filePath);
        }

        /// <summary>
        /// Set defualt path to file.
        /// </summary>
        /// <param name="filePath"></param>
        public void SetFilePath(string filePath)
        {
            FilePath = filePath;
        }
        #endregion

        #region Static Methods

        /// <summary>
        /// Store settings to file.
        /// </summary>
        /// <param name="settings">Settings to save</param>
        public static void Save(SettingsJson settings) => Save(settings, settings.FilePath);

        /// <summary>
        /// Store settings to custom file.
        /// </summary>
        /// <param name="settings">Settings to save</param>
        /// <param name="filePath">Custom path</param>
        public static void Save(SettingsJson settings, string filePath)
        {
            var jsonStringResult = JsonConvert.SerializeObject(settings, Formatting.Indented);
            if (File.Exists(filePath))
                File.Delete(filePath);
            File.AppendAllText(filePath,jsonStringResult);
        }

        /// <summary>
        /// Load setting from file.
        /// Set <see cref="FilePath"/> to <paramref name="filePath"/>.
        /// </summary>
        /// <typeparam name="TSettings">Type of settings class</typeparam>
        /// <param name="filePath">Path to file</param>
        /// <returns>Parsed settings. If file is not exist - return default</returns>
        public static TSettings Load<TSettings>(string filePath)
        where TSettings : SettingsJson, new()
        {
            if (File.Exists(filePath))
            {
                var jsonStringSettings = File.ReadAllText(filePath);
                var settings = JsonConvert.DeserializeObject<TSettings>(jsonStringSettings);
                settings.FilePath = filePath;
                return settings;
            }
            else
            {
                var settings = new TSettings();
                return settings.CreateDefault() as TSettings;
            }
        }
        #endregion
        
    }
}
