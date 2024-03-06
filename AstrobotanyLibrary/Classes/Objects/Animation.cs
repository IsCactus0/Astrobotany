using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstrobotanyLibrary.Classes.Objects {
    public class Animation {
        public Animation(string texture) {
            SpriteSheet = Main.AssetManager.GetTexture(texture);
            FrameSize = new Point(32);
            StartIndex = 0;
            EndIndex = 0;
            FrameRate = 1f;
            CurrentIndex = 0;
            Looping = false;
            Finished = false;
            lastFrame = 0f;
        }
        public Animation(string texture, Point frameSize) {
            SpriteSheet = Main.AssetManager.GetTexture(texture);
            FrameSize = frameSize;
            StartIndex = 0;
            EndIndex = 0;
            FrameRate = 1f;
            CurrentIndex = 0;
            Looping = false;
            Finished = false;
            lastFrame = 0f;
        }
        public Animation(string texture, Point frameSize, uint frameCount) {
            SpriteSheet = Main.AssetManager.GetTexture(texture);
            FrameSize = frameSize;
            StartIndex = 0;
            EndIndex = frameCount;
            FrameRate = 1f;
            CurrentIndex = 0;
            Looping = false;
            Finished = false;
            lastFrame = 0f;
        }
        public Animation(string texture, Point frameSize, uint startIndex, uint endIndex) {
            SpriteSheet = Main.AssetManager.GetTexture(texture);
            FrameSize = frameSize;
            StartIndex = startIndex;
            EndIndex = endIndex;
            FrameRate = 1f;
            CurrentIndex = 0;
            Looping = false;
            Finished = false;
            lastFrame = 0f;
        }
        public Animation(string texture, Point frameSize, uint startIndex, uint endIndex, float frameRate) {
            SpriteSheet = Main.AssetManager.GetTexture(texture);
            FrameSize = frameSize;
            StartIndex = startIndex;
            EndIndex = endIndex;
            FrameRate = frameRate;
            CurrentIndex = 0;
            Looping = false;
            Finished = false;
            lastFrame = 0f;
        }
        public Animation(string texture, Point frameSize, uint startIndex, uint endIndex, float frameRate, bool looping) {
            SpriteSheet = Main.AssetManager.GetTexture(texture);
            FrameSize = frameSize;
            StartIndex = startIndex;
            EndIndex = endIndex;
            FrameRate = frameRate;
            CurrentIndex = 0;
            Looping = looping;
            Finished = false;
            lastFrame = 0f;
        }

        /// <summary>A <paramref name="Texture2D"></paramref> containing all frames of an animation.</summary>
        public Texture2D SpriteSheet;
        /// <summary>Size of the texture for each individual frame.</summary>
        public Point FrameSize;
        /// <summary>The index of the current frame.</summary>
        public uint CurrentIndex;
        /// <summary>The first frame of animation to sample from <paramref name="SpriteSheet"></paramref></summary>
        public uint StartIndex;
        /// <summary>The final frame of animation to sample from <paramref name="SpriteSheet"></paramref></summary>
        public uint EndIndex;
        /// <summary>Time per frame in seconds.</summary>
        public float FrameRate;
        /// <summary>Resets the animation when <paramref name="CurrentIndex"></paramref> reaches <paramref name="EndIndex"></paramref></summary>
        public bool Looping;
        /// <summary>The animation</summary>
        public bool Finished;

        /// <summary>Time passed since last frame change.<br></br>
        /// Used to increment <paramref name="CurrentIndex"></paramref> when<br></br>
        /// value matches or exceeds that of <paramref name="FrameRate"></paramref></summary>
        private float lastFrame;

        public void Update(float delta) {
            lastFrame += delta;
            if (lastFrame >= FrameRate) {
                lastFrame = 0f;
                if (++CurrentIndex > EndIndex) {
                    if (Looping)
                        CurrentIndex = StartIndex;
                    else CurrentIndex = EndIndex;
                }
            }
        }
    }
}