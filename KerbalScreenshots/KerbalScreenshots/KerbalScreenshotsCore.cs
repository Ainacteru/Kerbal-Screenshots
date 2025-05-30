using System;
using System.IO;
using UnityEngine;

namespace KerbalScreenshots
{
    [KSPAddon(KSPAddon.Startup.AllGameScenes, false)]
    public class KerbalScreenshotsCore : MonoBehaviour
    {

        public KeyCode screenshotKey = KeyCode.F1;

        private void Update()
        {
            string filePath = Path.Combine(Directory.GetParent(Application.dataPath).FullName, "UserLoadingScreens/");

            if (Input.GetKeyDown(screenshotKey))
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