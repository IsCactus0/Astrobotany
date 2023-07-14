using Microsoft.Xna.Framework.Graphics;

namespace AstrobotanyLibrary.Classes.Objects
{
    public class Animation
    {
        public Animation()
        {
            Frames = new List<string>();
            CurrentIndex = 0;
            FrameRate = 1f;
            lastFrame = 0f;
        }
        public Animation(List<string> frames)
        {
            Frames = frames;
            CurrentIndex = 0;
            FrameRate = 1f;
            lastFrame = 0f;
        }

        public List<string> Frames { get; protected set; }
        public Texture2D Texture
        {
            get { return Main.AssetManager.GetTexture(Frames[CurrentIndex]); }
        }
        public int CurrentIndex { get; protected set; }
        public float FrameRate { get; protected set; }

        protected float lastFrame;

        public void Update(float delta)
        {
            lastFrame += delta;
            if (lastFrame >= FrameRate)
            {
                lastFrame = 0f;
                if (++CurrentIndex >= Frames.Count)
                    CurrentIndex = 0;
            }
        }
    }
}