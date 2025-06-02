using System;
using System.IO;
using UnityEngine;

// settings code ALSO taken straight from PRE's source code. thanks lisias

namespace KerbalScreenshots
{
    [KSPAddon(KSPAddon.Startup.Instantly, false)]
    public class Settings : MonoBehaviour
    {
        public static string SettingsConfigUrl = "GameData/KerbalScreenshots/settings.cfg";
        public static KeyCode ScreenshotKey { get; set; } = KeyCode.F1;
        public static bool ConfigLoaded { get; set; } = false;

        public static void LoadConfig()
        {
            try
            {
                Debug.Log("Kerbal Screenshots: Loading settings.cfg...");

                ConfigNode fileNode = ConfigNode.Load(SettingsConfigUrl);
                if (!fileNode.HasNode("KerbalScreenshotsSettings"))
                {
                    Debug.Log("Kerbal Screenshots: No `settings.cfg` file found @ " + SettingsConfigUrl);
                    return;
                }

                ConfigNode settings = fileNode.GetNode("KerbalScreenshotsSettings");
                ScreenshotKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), settings.GetValue("ScreenshotKey"));
                if (ScreenshotKey != KeyCode.None)
                {
                    KerbalScreenshotsCore.screenshotKey = ScreenshotKey;
                    Debug.Log("Kerbal Screenshots: Screenshot hotkey set to " + KerbalScreenshotsCore.screenshotKey);
                }
                else
                {
                    KerbalScreenshotsCore.screenshotKey = KeyCode.F1;
                    Debug.Log("Kerbal Screenshots: Screenshot hotkey set to default (F1)");
                }
            }
            catch (Exception ex)
            {
                Debug.Log("Kerbal Screenshots: Failed to load settings config:" + ex.Message);
            }
        }

        public static void SaveConfig()
        {
            try
            {
                ConfigNode fileNode = ConfigNode.Load(SettingsConfigUrl);
                if (!fileNode.HasNode("KerbalScreenshotsSettings"))
                {
                    Debug.Log("Kerbal Screenshots: No `settings.cfg` file found @ " + SettingsConfigUrl);
                    return;
                }
                ConfigNode settings = fileNode.GetNode("KerbalScreenshotsSettings");

                settings.SetValue("ScreenshotKey", ScreenshotKey.ToString());
                Debug.Log("Kerbal Screenshots: `settings.cfg` saved!");
                fileNode.Save(SettingsConfigUrl);

            }
            catch (Exception ex)
            {
                Debug.Log("Kerbal Screenshots: Failed to save settings config:" + ex.Message); throw;
            }
        }


    }
}
