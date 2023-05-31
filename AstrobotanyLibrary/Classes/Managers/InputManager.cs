using AstrobotanyLibrary.Classes.Enums;
using AstrobotanyLibrary.Classes.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace AstrobotanyLibrary.Classes.Managers
{
    public class InputManager : GameComponent
    {
        public InputManager(Game game): base(game)
        {
            KeyboardControls = new Dictionary<Enums.Action, List<Keys>>()
            {
                { Enums.Action.MoveUp, new List<Keys>()     { Keys.Up, Keys.W } },
                { Enums.Action.MoveDown, new List<Keys>()   { Keys.Down, Keys.S } },
                { Enums.Action.MoveLeft, new List<Keys>()   { Keys.Left, Keys.A } },
                { Enums.Action.MoveRight, new List<Keys>()  { Keys.Right, Keys.D } },
                { Enums.Action.Interact, new List<Keys>()   { Keys.F } },
                { Enums.Action.Sprint, new List<Keys>()     { Keys.LeftShift } },

                { Enums.Action.Exit, new List<Keys>()       { Keys.Escape } },
                { Enums.Action.MenuUp, new List<Keys>()     { Keys.Up, Keys.W } },
                { Enums.Action.MenuDown, new List<Keys>()   { Keys.Down, Keys.S } },
                { Enums.Action.MenuLeft, new List<Keys>()   { Keys.Left, Keys.A } },
                { Enums.Action.MenuRight, new List<Keys>()  { Keys.Right, Keys.D } },
                { Enums.Action.MenuEnter, new List<Keys>()  { Keys.Enter } },
                { Enums.Action.MenuBack, new List<Keys>()   { Keys.Escape, Keys.Back } },

                { Enums.Action.ZoomIn, new List<Keys>()     { Keys.Add, Keys.OemPlus } },
                { Enums.Action.ZoomOut, new List<Keys>()    { Keys.Subtract, Keys.OemMinus } },
            };
            GamePadControls = new Dictionary<Enums.Action, List<Buttons>>()
            {
                { Enums.Action.MoveUp, new List<Buttons>()      { Buttons.LeftThumbstickUp } },
                { Enums.Action.MoveDown, new List<Buttons>()    { Buttons.LeftThumbstickDown } },
                { Enums.Action.MoveLeft, new List<Buttons>()    { Buttons.LeftThumbstickLeft } },
                { Enums.Action.MoveRight, new List<Buttons>()   { Buttons.LeftThumbstickRight } },
                { Enums.Action.Interact, new List<Buttons>()    { Buttons.A } },
                { Enums.Action.Sprint, new List<Buttons>()      { Buttons.LeftStick } },

                { Enums.Action.Exit, new List<Buttons>()        { Buttons.Start } },
                { Enums.Action.ZoomIn, new List<Buttons>()      { Buttons.DPadUp } },
                { Enums.Action.ZoomOut, new List<Buttons>()     { Buttons.DPadDown } }
            };
        }

        private Dictionary<Enums.Action, List<Keys>> KeyboardControls { get; set; }
        private Dictionary<Enums.Action, List<Buttons>> GamePadControls { get; set; }
        public KeyboardState KeyboardState { get; private set; }
        public KeyboardState LastKeyboardState { get; private set; }
        public MouseState MouseState { get; private set; }
        public MouseState LastMouseState { get; private set; }
        public GamePadState GamePadState { get; private set; }
        public GamePadState LastGamePadState { get; private set; }
        public Vector2 SelectionStart { get; private set; }
        public Vector2 SelectionEnd { get; private set; }

        public override void Update(GameTime gameTime)
        {
            LastKeyboardState = KeyboardState;
            KeyboardState = Keyboard.GetState();
            LastMouseState = MouseState;
            MouseState = Mouse.GetState();
            LastGamePadState = GamePadState;
            GamePadState = GamePad.GetState(PlayerIndex.One);

            base.Update(gameTime);
        }
        
        public bool MousePressed(MouseButton button = MouseButton.Left)
        {
            switch (button)
            {
                default:
                    return MouseState.LeftButton == ButtonState.Pressed;
                case MouseButton.Right:
                    return MouseState.RightButton == ButtonState.Pressed;
                case MouseButton.Middle:
                    return MouseState.MiddleButton == ButtonState.Pressed;
            }
        }
        public bool MouseFirstPressed(MouseButton button = MouseButton.Left)
        {
            switch (button)
            {
                default:
                    return LastMouseState.LeftButton == ButtonState.Released &&
                        MouseState.LeftButton == ButtonState.Pressed;
                case MouseButton.Right:
                    return LastMouseState.RightButton == ButtonState.Released &&
                        MouseState.RightButton == ButtonState.Pressed;
                case MouseButton.Middle:
                    return LastMouseState.MiddleButton == ButtonState.Released &&
                        MouseState.MiddleButton == ButtonState.Pressed;
            }
        }
        public bool MouseReleased(MouseButton button = MouseButton.Left)
        {
            switch (button)
            {
                default:
                    return MouseState.LeftButton == ButtonState.Released;
                case MouseButton.Right:
                    return MouseState.RightButton == ButtonState.Released;
                case MouseButton.Middle:
                    return MouseState.MiddleButton == ButtonState.Released;
            }
        }
        public bool MouseFirstReleased(MouseButton button = MouseButton.Left)
        {
            switch (button)
            {
                default:
                    return LastMouseState.LeftButton == ButtonState.Pressed &&
                        MouseState.LeftButton == ButtonState.Released;
                case MouseButton.Right:
                    return LastMouseState.RightButton == ButtonState.Pressed &&
                        MouseState.RightButton == ButtonState.Released;
                case MouseButton.Middle:
                    return LastMouseState.MiddleButton == ButtonState.Pressed &&
                        MouseState.MiddleButton == ButtonState.Released;
            }
        }

        public bool KeyPressed(Keys key)
        {
            return KeyboardState.IsKeyDown(key);
        }
        public bool KeyFirstPressed(Keys key)
        {
            return KeyboardState.IsKeyDown(key) &&
                LastKeyboardState.IsKeyUp(key);
        }
        public bool KeyReleased(Keys key)
        {
            return KeyboardState.IsKeyUp(key);
        }
        public bool KeyFirstReleased(Keys key)
        {
            return KeyboardState.IsKeyUp(key) &&
                LastKeyboardState.IsKeyDown(key);
        }
        public bool AnyKeyPressed()
        {
            return KeyboardState.GetPressedKeyCount() > 0;
        }

        public bool ButtonPressed(Buttons button)
        {
            return GamePadState.IsButtonDown(button);
        }
        public bool ButtonFirstPressed(Buttons button)
        {
            return GamePadState.IsButtonDown(button) &&
                LastGamePadState.IsButtonUp(button);
        }
        public bool ButtonReleased(Buttons button)
        {
            return GamePadState.IsButtonUp(button);
        }
        public bool ButtonFirstReleased(Buttons button)
        {
            return GamePadState.IsButtonUp(button) &&
                LastGamePadState.IsButtonDown(button);
        }
        public bool AnyButtonPressed()
        {
            foreach (Buttons button in Enum.GetValues(typeof(Buttons)))
                if (ButtonPressed(button))
                    return true;
            return false;
        }

        public bool InputPressed(Enums.Action action)
        {
            foreach (Keys key in KeyboardControls[action])
                if (KeyPressed(key))
                    return true;

            foreach (Buttons button in GamePadControls[action])
                if (ButtonPressed(button))
                    return true;

            return false;
        }
        public bool InputFirstPressed(Enums.Action action)
        {
            foreach (Keys key in KeyboardControls[action])
                if (KeyFirstPressed(key))
                    return true;

            foreach (Buttons button in GamePadControls[action])
                if (ButtonFirstPressed(button))
                    return true;

            return false;
        }
        public bool InputReleased(Enums.Action action)
        {
            foreach (Keys key in KeyboardControls[action])
                if (KeyReleased(key))
                    return true;

            foreach (Buttons button in GamePadControls[action])
                if (ButtonReleased(button))
                    return true;

            return false;
        }
        public bool InputFirstReleased(Enums.Action action)
        {
            foreach (Keys key in KeyboardControls[action])
                if (KeyFirstReleased(key))
                    return true;

            foreach (Buttons button in GamePadControls[action])
                if (ButtonFirstReleased(button))
                    return true;

            return false;
        }

        public Vector2 MouseWorldPosition(Camera camera)
        {
            return Vector2.Transform(MouseState.Position.ToVector2(), camera.InvertedTransform);
        }
        public Point MouseWorldPositionP(Camera camera)
        {
            return MouseWorldPosition(camera).ToPoint();
        }
        public Vector2 MouseScreenPosition()
        {
            return MouseScreenPositionP().ToVector2();
        }
        public Point MouseScreenPositionP()
        {
            return MouseState.Position;
        }
        public Rectangle SelectionBounds()
        {
            int x, y;
            if (SelectionStart.X < SelectionEnd.X)
                x = (int)SelectionStart.X;
            else x = (int)SelectionEnd.X;

            if (SelectionStart.Y < SelectionEnd.Y)
                y = (int)SelectionStart.Y;
            else y = (int)SelectionEnd.Y;

            return new Rectangle(
                x, y,
                (int)Math.Abs(SelectionStart.X - SelectionEnd.X),
                (int)Math.Abs(SelectionStart.Y - SelectionEnd.Y));
        }
    }
}