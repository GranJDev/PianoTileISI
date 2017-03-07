using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace PianoTile
{
    public class Tile : Microsoft.Xna.Framework.DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        private int maxX;
        private int maxY;
        private int minX;
        private int minY;


        private Vector2 vitesse = Vector2.Zero;
        private Vector2 position_initiale;

        private ObjetAnime unetile;

        public ObjetAnime UneTile
        {
            get
            {
                return unetile;
            }
        }


        public Tile(Game game, int x, int y, int z, int w)
            : base(game)
        {
            maxX = x;
            maxY = y;
            minX = z;
            minY = w;


            this.Game.Components.Add(this);

        }

        public override void Initialize()
        {
            // On définit une vitesse initale
            this.vitesse = new Vector2(3, 2);

            this.position_initiale.X = maxX / 2;
            this.position_initiale.Y = maxY / 2;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            Vector2 taille;
            spriteBatch = new SpriteBatch(GraphicsDevice);
            unetile = new ObjetAnime(Game.Content.Load<Texture2D>(@"blackTile"),
                this.position_initiale, Vector2.Zero, this.vitesse);

            taille.X = unetile.Texture.Width;
            taille.Y = unetile.Texture.Height;
            unetile.Size = taille;
            base.LoadContent();
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(unetile.Texture, unetile.Position, Color.Azure);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            bougeTile();

            base.Update(gameTime);
        }

        private void tileOut(int mur)
        {
        }

        private void bougeTile()
        {
            // déplacement de la balle
            unetile.Position += unetile.Vitesse;


        }


    }
}
