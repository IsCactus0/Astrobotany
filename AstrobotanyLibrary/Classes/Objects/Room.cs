﻿using AstrobotanyLibrary.Classes.Objects.Decorations;
using AstrobotanyLibrary.Classes.Objects.Entities;
using Microsoft.Xna.Framework;

namespace AstrobotanyLibrary.Classes.Objects
{
    public class Room
    {
        public Vector2 Entrance { get; protected set; }
        public List<Entity> Entities { get; protected set; }
        public List<Decoration> Decorations { get; protected set; }

        public void LoadRoom()
        {
            Main.ParticleManager.Particles.Clear();
            Main.EntityManager.Entities.Clear();
            Main.DecorationManager.Decorations.Clear();

            Main.EntityManager.Entities.AddRange(Entities);
            Main.DecorationManager.Decorations.AddRange(Decorations);
        }
    }
}