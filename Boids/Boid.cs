using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoSims.Engine;

namespace MonoSims.Boids;

public class Boid : ILoopObject
{
	public static Texture2D Texture = App.AssetManager.GetTexture("Boids/Boid");
	public static Random random = new Random();
	public const float Speed = 40f;
	private Vector2 _position;
	public Vector2 Position
	{
		get => _position;
		set
		{
			_position = value;
			int x = (int)_position.X;
			int y = (int)_position.Y;
			const int screenWidth = 1920;
			const int screenHeight = 1080;
			const int offset = 20;
			const int halfOffset = offset / 2;
			if (x < -offset) _position.X = screenWidth + halfOffset;
			else if (x > screenWidth + offset) _position.X = -halfOffset;
			if (y < -offset) _position.Y = screenHeight + halfOffset;
			else if (y > screenHeight + offset) _position.Y = -halfOffset;
		}
	}
	public Vector2 Direction;

	private Color _color;

	public Boid(Vector2 position, Vector2 direction)
	{
		Position = position;
		Direction = direction;
		float red = 0.5f + random.NextSingle() * 0.5f; // Random red value between 0.5 and 1.0
		float green = 0.5f + random.NextSingle() * 0.5f; // Random green value between 0.5 and 1.0
		float blue = 0.5f + random.NextSingle() * 0.5f; // Random blue value between 0.5 and 1.0
		_color = new Color(red, green, blue);
	}

	public void Update(GameTime gameTime)
	{
		MoveTowardsCenter(40, 400);
		Direction = Vector2.Normalize(Direction);
		Position += Direction * Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
	}

	public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
	{
		spriteBatch.Draw(Texture, Position, null, _color, (float)Math.Atan2(Direction.Y, Direction.X), new Vector2(Texture.Width / 2f, Texture.Height / 2f), 1f, SpriteEffects.None, 0f);
	}

	public void HandleInput(InputHelper inputHelper) { }

	public void Reset() { }

	private float GetDistanceSquaredTo(Boid other)
	{
		return Vector2.DistanceSquared(Position, other.Position);
	}

	public void MoveTowardsCenter(int strength, int radius)
	{
		Vector2 center = new Vector2(960, 540); // Center of the screen
		Vector2 directionToCenter = Vector2.Normalize(center - Position);
		float distanceToCenter = Vector2.Distance(Position, center);

		if (distanceToCenter > radius)
		{
			Direction += directionToCenter * distanceToCenter * strength * 0.0000001f;
		}
	}

	public void ApplySeparation(Boid[] boids, int strength, int radius)
	{
		int squaredRadius = radius * radius;
		Vector2 AvoidanceForce = Vector2.Zero;

		foreach (var boid in boids)
		{
			Vector2 relativePositionOfOther = Vector2.Normalize(boid.Position - Position);
			float distanceSquared = GetDistanceSquaredTo(boid);
			float factor = squaredRadius - distanceSquared;
			AvoidanceForce -= relativePositionOfOther * factor;
		}
		Direction += AvoidanceForce * strength * 0.00000002f / boids.Length;
	}

	public void ApplyAlignment(Boid[] boids, int strength, float radius)
	{
		Vector2 averageDirection = Vector2.Zero;

		foreach (var boid in boids)
		{
			if (boid != this && GetDistanceSquaredTo(boid) < radius * radius)
			{
				averageDirection += boid.Direction;
			}
		}

		Direction += Vector2.Normalize(averageDirection) * strength * 0.0004f / boids.Length;
	}

	public void ApplyCohesion(Boid[] boids, int strength, float radius)
	{
		Vector2 averagePosition = Vector2.Zero;

		foreach (var boid in boids)
		{
			averagePosition += boid.Position;
		}
		averagePosition /= boids.Length;

		Direction += Vector2.Normalize(averagePosition - Position) * strength * 0.001f / boids.Length;
	}
}