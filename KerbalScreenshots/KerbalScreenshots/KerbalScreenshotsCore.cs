using System;
using System.IO;
using UnityEngine;

namespace KerbalScreenshots
{
    [KSPAddon(KSPAddon.Startup.AllGameScenes, false)]
    public class KerbalScreenshotsCore : MonoBehaviour
    {

        public KeyCode screenshot = KeyCode.F2;

        private void Update()
        {
            string filePath = Path.Combine(Application.dataPath, "GameData/KerbalScreenshots/LoadingScreens/");

            if (Input.GetKeyDown(screenshot))
            {
                string finalFile;
                string time = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss.fff");
                if (time.Contains("000"))
                {
                    finalFile = filePath + "quiz_" + time + ".png";
                }
                else
                {
                    finalFile = filePath + "kerbalscrn_" + time + ".png";
                }
                ScreenCapture.CaptureScreenshot(finalFile);
                Debug.Log("Screenshot saved to " + finalFile);
            }
        }   
    }
}

// the geneva conventions?
// ...did we buy tickets this year?