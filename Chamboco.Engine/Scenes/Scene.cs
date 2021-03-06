﻿using Chamboco.Engine.Entities;
using Chamboco.Engine.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using tainicom.Aether.Physics2D.Dynamics;

namespace Chamboco.Engine.Scenes
{
    public abstract class Scene : IDisposable
    {
        readonly IList<GameObject> entities = new List<GameObject>();
        public IList<GameObject> Entities => entities;
        public World World { get; }

        public Scene()
        {
            World = new ()
            {
                Gravity = new (0, 10)
            };

            SceneManager.CurrentScene ??= this;
        }

        public virtual void Start() { }

        public void Destroy(GameObject entity)
        {
            entity.Dispose();
            entities.Remove(entity);
        }

        public void Spawn(GameObject gameObject, Vector2? position = null, string name = null)
        {
            if (position.HasValue)
                gameObject.Transform.MoveTo(position.Value);

            if (name is not null)
                gameObject.Name = name;
            entities.Add(gameObject);
        }

        public virtual void Update(GameTime gameTime)
        {
            WorldStep(gameTime);
            for (var i = 0; i < entities.Count; i++)
                entities[i].UpdateObject(gameTime);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            for (var i = 0; i < entities.Count; i++)
                entities[i].Draw(spriteBatch);
        }

        public void WorldStep(GameTime gameTime) =>
            World.Step(Math.Min((float)gameTime.ElapsedGameTime.TotalSeconds, 1 / 30f));

        public virtual void Dispose()
        {
            while (Entities.Count > 0)
                Destroy(Entities[0]);
        }
    }

}
