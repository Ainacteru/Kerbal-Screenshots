using UnityEngine;

namespace KerbalScreenshots
{
    [KSPAddon(KSPAddon.Startup.MainMenu, true)]
    public class KerbalScreenshotsCore : MonoBehaviour {

        public KeyCode screenshot = KeyCode.F2;

        private void Update() {

            if (Input.GetKey(screenshot)){
                Debug.Log("KERBAL SCREENSHOTS WORKS!!! yay");
            }
        }
    }
}