using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoBlaster
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class GameRoot : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;

		//The screen information. 
		public static GameRoot Instance { get; private set; }
		public static Viewport Viewport { get { return Instance.GraphicsDevice.Viewport; } }
		public static Vector2 ScreenSize { get { return new Vector2(Viewport.Width, Viewport.Height); } }

		public GameRoot()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			Instance = this;
		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize()
		{
			base.Initialize();

			// TODO: Add your initialization logic here
			EntityManager.Add(PlayerShip.Instance);
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);

			//TODO: use this.Content to load your game content here 
			Art.Load(Content);
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update(GameTime gameTime)
		{
			

			// TODO: Add your update logic here
			base.Update(gameTime);
			EntityManager.Update();
			Input.Update();
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.Black);

			spriteBatch.Begin(SpriteSortMode.Texture, BlendState.Additive);
			EntityManager.Draw(spriteBatch);

			// draw the custom mouse cursor
			spriteBatch.Draw(Art.Pointer, Input.MousePosition, Color.White);
			spriteBatch.End();

			//TODO: Add your drawing code here

			base.Draw(gameTime);
		}
	}
}
