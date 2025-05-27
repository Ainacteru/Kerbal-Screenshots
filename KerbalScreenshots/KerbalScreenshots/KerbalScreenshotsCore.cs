using UnityEngine;

namespace KerbalScreenshots
{
    [KSPAddon(KSPAddon.Startup.MainMenu, true)]

    public class KerbalScreenshotsCore : MonoBehaviour {

        private void Start() {
            Debug.Log("KERBAL SCREENSHOTS WORKS!!! yay");
        }
    }
}
