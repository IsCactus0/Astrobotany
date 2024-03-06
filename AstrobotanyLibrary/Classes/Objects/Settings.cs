using AstrobotanyLibrary.Classes.Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace AstrobotanyLibrary.Classes.Objects
{
    public class Settings
    {
        public Settings()
        {
            Resolution = new Point(1920, 1080);
            WindowMode = WindowMode.Windowed;
            Brightness = 1f;
            VSync = false;
            TargetFPS = 0;
            MultiSampleCount = 8;
            GameSpeed = true;
            ScreenShake = true;
            PauseOnLoseFocus = false;
            UseSystemCursor = false;
            SavePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "Astrobotany/Settings/");

            Main.Self.Activated += (sender, args) => { OnFocus(); };
            Main.Self.Deactivated += (sender, args) => { OnLoseFocus(); };
        }

        public Point Resolution { get; set; }
        public WindowMode WindowMode { get; set; }
        public float Brightness { get; set; }
        public bool VSync { get; set; }
        public int TargetFPS { get; set; }
        public int MultiSampleCount { get; set; }
        public bool GameSpeed { get; set; }
        public bool ScreenShake { get; set; }
        public bool PauseOnLoseFocus { get; set; }
        public bool UseSystemCursor { get; set; }
        public string SavePath { get; set; }
        public Rectangle WindowSize
        {
            get
            {
                if (WindowMode == WindowMode.Borderless)
                    return new Rectangle(0, 0, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height);
                
                return new Rectangle(0, 0, Main.Graphics.PreferredBackBufferWidth, Main.Graphics.PreferredBackBufferHeight);
            }
        }

        public void ApplySettings()
        {
            SetResolution();
            SetWindowMode();
            SetFramerate();

            Main.Self.IsMouseVisible = UseSystemCursor;

            Main.Graphics.ApplyChanges();
        }
        public void SetResolution()
        {
            Point resolution = Resolution;

            Main.RenderTarget = new RenderTarget2D(Main.Graphics.GraphicsDevice, resolution.X, resolution.Y);
            Main.LightsRenderTarget = new RenderTarget2D(Main.Graphics.GraphicsDevice, resolution.X, resolution.Y);
            Main.Graphics.GraphicsDevice.Clear(Color.Black);
            Main.Graphics.PreferredBackBufferWidth = resolution.X;
            Main.Graphics.PreferredBackBufferHeight = resolution.Y;

            Main.Camera.Viewport = new Viewport(resolution.X / 2, resolution.Y / 2, resolution.X, resolution.Y);
        }
        public void NextResolution()
        {
            DisplayModeCollection collection = GraphicsAdapter.DefaultAdapter.SupportedDisplayModes;
            int index = collection.ToList().FindIndex(x => Resolution.X == x.Width && Resolution.Y == x.Height) + 1;
            if (index >= collection.Count())
                index = 0;

            DisplayMode resolution = collection.ToArray()[index];
            Resolution = new Point(resolution.Width, resolution.Height);

            SetResolution();
            Main.Graphics.ApplyChanges();
        }
        public void SetWindowMode()
        {
            switch (WindowMode)
            {
                default:
                    Main.Graphics.IsFullScreen = false;
                    Main.Self.Window.IsBorderless = false;
                    Main.Graphics.HardwareModeSwitch = true;
                    break;
                case WindowMode.Borderless:
                    Main.Graphics.IsFullScreen = true;
                    Main.Self.Window.IsBorderless = true;
                    Main.Graphics.HardwareModeSwitch = false;
                    break;
                case WindowMode.Fullscreen:
                    Main.Graphics.IsFullScreen = true;
                    Main.Self.Window.IsBorderless = true;
                    Main.Graphics.HardwareModeSwitch = true;
                    break;
            }
        }
        public void SetFramerate()
        {
            Main.Self.IsFixedTimeStep = VSync;
            Main.Graphics.SynchronizeWithVerticalRetrace = VSync;

            if (!VSync && TargetFPS > 0)
            {
                Main.Self.IsFixedTimeStep = true;
                Main.Self.TargetElapsedTime = TimeSpan.FromTicks(TimeSpan.TicksPerSecond / TargetFPS);
            }
        }
        private void Graphics_PreparingDeviceSettings(object sender, PreparingDeviceSettingsEventArgs e)
        {
            Main.Graphics.GraphicsProfile = GraphicsProfile.Reach;
            Main.Graphics.PreferMultiSampling = false;
            e.GraphicsDeviceInformation.PresentationParameters.MultiSampleCount = 0;
        }
        private void OnFocus()
        {
            Main.Self.IsMouseVisible = false;
        }
        private void OnLoseFocus()
        {
            Main.Self.IsMouseVisible = true;
        }
        public bool LoadControls()
        {
            try
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(Dictionary<Enums.Action, List<Keys>>));
                using (XmlReader reader = XmlReader.Create($@"{SavePath}/controls_keyboard.xml"))
                    Main.InputManager.KeyboardControls = (Dictionary<Enums.Action, List<Keys>>)serializer.ReadObject(reader);

                serializer = new DataContractSerializer(typeof(Dictionary<Enums.Action, List<Buttons>>));
                using (XmlReader reader = XmlReader.Create($@"{SavePath}/controls_gamepad.xml"))
                    Main.InputManager.GamePadControls = (Dictionary<Enums.Action, List<Buttons>>)serializer.ReadObject(reader);

                SaveControls();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error while reading controls from file:\n{e.Message}");
                return false;
            }
        }
        public void SaveControls()
        {
            try
            {
                if (!Directory.Exists($@"{SavePath}"))
                    Directory.CreateDirectory($@"{SavePath}");

                DataContractSerializer serializer = new DataContractSerializer(typeof(Dictionary<Enums.Action, List<Keys>>));
                using (XmlWriter writer = XmlWriter.Create($@"{SavePath}/controls_keyboard.xml"))
                    serializer.WriteObject(writer, Main.InputManager.KeyboardControls);

                serializer = new DataContractSerializer(typeof(Dictionary<Enums.Action, List<Buttons>>));
                using (XmlWriter writer = XmlWriter.Create($@"{SavePath}/controls_gamepad.xml"))
                    serializer.WriteObject(writer, Main.InputManager.GamePadControls);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error while writing controls to file:\n{e.Message}");
                return;
            }
        }
        public bool LoadSettings()
        {
            if (!File.Exists($@"{SavePath}/settings.xml"))
            {
                SaveSettings();
                ApplySettings();
                return true;
            } 

            XmlSerializer serializer = new XmlSerializer(typeof(Settings));
            using (XmlReader reader = XmlReader.Create($@"{SavePath}/settings.xml"))
                Main.Settings = (Settings)serializer.Deserialize(reader);

            ApplySettings();
            return true;
        }
        public void SaveSettings()
        {
            if (!Directory.Exists($@"{SavePath}"))
                Directory.CreateDirectory($@"{SavePath}");

            XmlSerializer serializer = new XmlSerializer(typeof(Settings));
            using (StreamWriter writer = new StreamWriter($@"{SavePath}/settings.xml"))
                serializer.Serialize(writer, this);
        }
    }
}