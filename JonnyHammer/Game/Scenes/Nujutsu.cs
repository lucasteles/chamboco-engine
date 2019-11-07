﻿using JonnyHamer.Engine.Helpers;
using JonnyHamer.Engine.Manipulators;
using JonnyHammer.Engine.Scenes;
using JonnyHammer.Game.Characters;
using JonnyHammer.Tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JonnyHammer.Game.Scenes
{
    public class Nujutsu : Scene
    {
        private BigNaruto narutao;
        private Texture2D background;
        private Floor floor;

        public Nujutsu()
        {
            background = Loader.LoadTexture("bg");
            Camera.AreaWidth = background.Width * 2;
            Camera.AreaHeight = background.Height;

            narutao = Instantiate<BigNaruto>("Narutao", new Vector2(100, 300));
            floor = Instantiate<Floor>("Parede", new Vector2(300, 300));
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            Camera.Update(narutao);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(transformMatrix: Camera.ViewMatrix);
            spriteBatch.Draw(background, new Rectangle(0, 0, background.Width, background.Height), Color.White);
            spriteBatch.Draw(background, new Vector2(background.Width, 0), null, Color.White, 0, Vector2.Zero, 1,
                SpriteEffects.FlipHorizontally, 0);

            base.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}