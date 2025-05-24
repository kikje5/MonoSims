using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace MonoSims.Engine;

public interface ILoopObject
{
	void Update(GameTime gameTime);
	void Draw(GameTime gameTime, SpriteBatch spriteBatch);
	void HandleInput(InputHelper inputHelper);
	void Reset();
}
