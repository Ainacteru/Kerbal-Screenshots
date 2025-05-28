using UnityEngine;

namespace KerbalScreenshots
{
    [KSPAddon(KSPAddon.Startup.AllGameScenes, false)]
    public class KerbalScreenshotsCore : MonoBehaviour
    {

        public KeyCode screenshot = KeyCode.F2;

        private void Update()
        {
            string filePath = "GameData\\KerbalScreenshots\\LoadingScreens\\";
            string fileName = "test";

            if (Input.GetKeyDown(screenshot))
            {
                string finalFile = filePath + fileName + ".png";
                //ScreenCapture.CaptureScreenshot(finalFile);
                Debug.Log("Screenshot Taken at " + finalFile);
            }
        }
    }
}

// the geneva conventions?
// ...did we buy tickets this year?