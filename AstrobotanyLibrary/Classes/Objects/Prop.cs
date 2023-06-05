using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstrobotanyLibrary.Classes.Objects
{
    public class Prop : GameObject
    {
        public Prop()
            : base()
        {
            Name = "";
        }
        public Prop(string name)
            : base()
        {
            Name = name;
        }

        public string Name { get; set; }

        public override void Destroy()
        {
            Main.PropManager.Props.Remove(this);
        }
        public override void Update(float delta)
        {
            
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Main.AssetManager.GetTexture(Name), Position, Color.White);
        }
    }
}