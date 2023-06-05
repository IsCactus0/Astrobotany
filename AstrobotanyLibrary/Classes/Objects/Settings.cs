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
            VSync = false;
            TargetFPS = 0;
            SavePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "Astrobotany/Settings/");
        }

        public Point Resolution { get; set; }
        public WindowMode WindowMode { get; set; }
        public bool VSync { get; set; }
        public int TargetFPS { get; set; }
        public int MultiSampleCount { get; set; }
        public string SavePath { get; set; }

        public void ApplySettings()
        {
            SetResolution();
            SetWindowMode();
            SetFramerate();
            Main.Graphics.ApplyChanges();
        }
        public void SetResolution()
        {
            Main.RenderTarget = new RenderTarget2D(Main.Graphics.GraphicsDevice, Resolution.X, Resolution.Y);
            Main.Graphics.GraphicsDevice.Clear(Color.Transparent);
            Main.Graphics.PreferredBackBufferWidth = Resolution.X;
            Main.Graphics.PreferredBackBufferHeight = Resolution.Y;

            Main.Camera.Viewport = new Viewport(Resolution.X / 2, Resolution.Y / 2, Resolution.X, Resolution.Y);
            Main.Camera.Scale = 1f;
        }
        public void SetWindowMode()
        {
            switch (WindowMode)
            {
                default:
                    Main.Graphics.IsFullScreen = false;
                    Main.Graphics.HardwareModeSwitch = true;
                    break;
                case WindowMode.Borderless:
                    Main.Graphics.IsFullScreen = true;
                    Main.Graphics.HardwareModeSwitch = false;
                    break;
                case WindowMode.Fullscreen:
                    Main.Graphics.IsFullScreen = true;
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
            Main.Graphics.PreferMultiSampling = true;
            e.GraphicsDeviceInformation.PresentationParameters.MultiSampleCount = MultiSampleCount;
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
                SaveSettings();

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