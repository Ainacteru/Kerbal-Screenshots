using UnityEngine;

namespace KerbalScreenshots
{
    [KSPAddon(KSPAddon.Startup.AllGameScenes, false)]
    public class KerbalScreenshotsCore : MonoBehaviour
    {

        public KeyCode screenshot = KeyCode.F2;
        private void Update()
        {
            if (Input.GetKeyDown(screenshot))
            {
                Debug.Log("KERBAL SCREENSHOTS WORKS!!! yay");
            }
        }
    }
}

// the geneva conventions?
// ...did we buy tickets this year?