using Chamboco.Engine.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Chamboco.Engine.Entities.Components
{
    public class Component : IDisposable
    {
        public GameObject Entity { get; private set; }
        public bool IsActive { get; set; } = true;
        public bool didLoad { get; set; }

        public void DrawComponent(SpriteBatch spriteBatch)
        {
            if (didLoad)
                Draw(spriteBatch);
        }

        public void StartComponent()
        {
            Start();
            didLoad = true;
        }

        public void SetEntity(GameObject entity) => Entity = entity;

        protected virtual void Start() { }

        public virtual void Update(GameTime gameTime) { }

        protected virtual void Draw(SpriteBatch spriteBatch) { }


        public Lazy<T> GetComponent<T>() where T : Component => new (() => Entity.GetComponent<T>());

        public virtual void Dispose() { }
    }
}
