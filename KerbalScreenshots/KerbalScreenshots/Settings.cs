using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

// settings code ALSO taken straight from PRE's source code. thanks lisias

namespace KerbalScreenshots
{
    [KSPAddon(KSPAddon.Startup.Instantly, false)]
    public class Settings : MonoBehaviour
    {
        public static string SettingsConfigUrl = "GameData/KerbalScreenshots/settings.cfg";
        public static KeyCode ScreenshotKey { get; set; }
        public static bool ConfigLoaded { get; set; } = false;

        void Awake()
        {
            LoadConfig();
            ConfigLoaded = true;
        }

        public static void LoadConfig()
        {
            try
            {
                Debug.Log("Kerbal Screenshots: Loading settings.cfg ==");

                ConfigNode fileNode = ConfigNode.Load(SettingsConfigUrl);
                if (!fileNode.HasNode("KerbalScreenshotsSettings")) return;

                ConfigNode settings = fileNode.GetNode("KerbalScreenshotsSettings");
                ScreenshotKey = (KeyCode) System.Enum.Parse(typeof(KeyCode), settings.GetValue("ScreenshotKey"));
            }
            catch (Exception ex)
            {
                Debug.Log("Kerbal Screenshots: failed to load settings config:" + ex.Message);
            }
        }

        public static void SaveConfig()
        {
            try
            {
                Debug.Log("Kerbal Screenshots: saving settings.cfg ==");
                ConfigNode fileNode = ConfigNode.Load(SettingsConfigUrl);
                if (!fileNode.HasNode("KerbalScreenshotsSettings")) return;
                ConfigNode settings = fileNode.GetNode("KerbalScreenshotsSettings");

                settings.SetValue("ScreenshotKey", ScreenshotKey.ToString());
                fileNode.Save(SettingsConfigUrl);
            }
            catch (Exception ex)
            {
                Debug.Log("Kerbal Screenshots: Failed to save settings config:" + ex.Message); throw;
            }
        }


    }
}
