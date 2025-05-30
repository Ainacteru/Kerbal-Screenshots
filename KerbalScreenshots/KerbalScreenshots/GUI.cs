using System;
using System.Globalization;
using KSP.UI.Screens;
using UnityEngine;

// code taken STRAIGHT from physics range extender's source code. so kudos ig

namespace KerbalScreenshots
{
    [KSPAddon(KSPAddon.Startup.AllGameScenes, false)]
    public class Gui : MonoBehaviour
    {
        private const float WindowWidth = 250;
        private const float DraggableHeight = 40;
        private const float LeftIndent = 12;
        private const float ContentTop = 20;
        public static Gui Fetch;
        public static bool GuiEnabled;
        private ApplicationLauncherButton button = null;
        private readonly float contentWidth = WindowWidth - 2 * LeftIndent;
        private readonly float entryHeight = 20;

        private bool _gameUiToggle;

        private float _windowHeight = 250;
        private Rect _windowRect;

        private void Awake()
        {
            if (Fetch)
                Destroy(Fetch);

            Fetch = this;
        }

        private void Start()
        {
            _windowRect = new Rect(Screen.width - WindowWidth - 40, 100, WindowWidth, _windowHeight);
            AddToolbarButton();
            GameEvents.onHideUI.Add(GameUiDisable);
            GameEvents.onShowUI.Add(GameUiEnable);
            _gameUiToggle = true;
            KerbalScreenshotsCore.screenshotKey = Settings.ScreenshotKey;
        }

        private void OnDestroy()
        {
            GameEvents.onShowUI.Remove(GameUiEnable);
            GameEvents.onHideUI.Remove(GameUiDisable);
            ApplicationLauncher.Instance.RemoveModApplication(this.button);
            this.button = null;
        }

        // ReSharper disable once InconsistentNaming
        private void OnGUI()
        {
            if (!Settings.ConfigLoaded) return;
            if (GuiEnabled && _gameUiToggle)
                _windowRect = GUI.Window(320, _windowRect, GuiWindow, "");
        }

        private void GuiWindow(int windowId)
        {
            GUI.DragWindow(new Rect(0, 0, WindowWidth, DraggableHeight));
            float line = 0;


            DrawTitle();
            line++;
            DrawSaveButton(line);


            _windowHeight = ContentTop + line * entryHeight + entryHeight + entryHeight;
            _windowRect.height = _windowHeight;
        }

        
        private void DrawSaveButton(float line)
        {
            var saveRect = new Rect(LeftIndent, ContentTop + line * entryHeight, contentWidth / 2, entryHeight);
            if (GUI.Button(saveRect, "Change screenshot key"))
                Apply();
        }

        public void Apply()
        {
            try
            {
                KerbalScreenshotsCore.screenshotKey = Settings.ScreenshotKey;
            }
            catch (Exception e)
            {
                Debug.Log($"Kerbal Screenshots: Could not save new screenshot key!: {e}");
            }

            Settings.SaveConfig();
        }
        private void DrawTitle()
        {
            var centerLabel = new GUIStyle
            {
                alignment = TextAnchor.UpperCenter,
                normal = { textColor = Color.white }
            };
            var titleStyle = new GUIStyle(centerLabel)
            {
                fontSize = 10,
                alignment = TextAnchor.MiddleCenter
            };
            GUI.Label(new Rect(0, 0, WindowWidth, 20), "Kerbal Screenshots", titleStyle);
        }

        private void AddToolbarButton()
        {
            if (null == this.button)
            {
                Texture buttonTexture = GameDatabase.Instance.GetTexture("KerbalScreenshots/Textures/icon", false);
                this.button = ApplicationLauncher.Instance.AddModApplication(
                        EnableGui, DisableGui, Dummy, Dummy, Dummy, Dummy,
                        ApplicationLauncher.AppScenes.ALWAYS, buttonTexture
                    );
            }
        }

        private void EnableGui()
        {
            GuiEnabled = true;
            Debug.Log("Kerbal Screenshots: Showing GUI ('Courtesy' of lisias & Physics Range Extender!)");
        }

        private void DisableGui()
        {
            GuiEnabled = false;
            Debug.Log("Kerbal Screenshots: Hiding GUI");
        }

        private void Dummy()
        {
        }

        private void GameUiEnable()
        {
            _gameUiToggle = true;
        }

        private void GameUiDisable()
        {
            _gameUiToggle = false;
        }
    }
}
