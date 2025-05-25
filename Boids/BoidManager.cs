using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoSims.Engine;

namespace MonoSims.Boids
{
	using System;
	using System.Collections.Generic;
	using Microsoft.Xna.Framework;
	using MonoSims.Engine;

	public class BoidManager : ILoopObject
	{
		public Boid[] Boids;

		private const int InitialBoidCount = 500;

		public bool DoSeparation = true;
		public bool DoAlignment = true;
		public bool DoCohesion = true;

		public int SeparationStrength = 100;
		public int AlignmentStrength = 100;
		public int CohesionStrength = 100;

		public const int radius = 128;
		public int SeparationDistance = radius;
		public int AlignmentDistance = radius;
		public int CohesionDistance = radius;
		public BoidManager() { }

		private void InitializeBoids()
		{
			Random random = new Random();
			Boids = new Boid[InitialBoidCount];
			for (int i = 0; i < InitialBoidCount; i++)
			{
				Vector2 position = new Vector2(
					random.Next(0, 1920),
					random.Next(0, 1080));
				Vector2 direction = new Vector2(random.NextSingle() * 2 - 1, random.NextSingle() * 2 - 1); //random.NextVector2(-1f, 1f);
				Boid boid = new Boid(position, direction);
				Boids[i] = boid;
			}
		}

		public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			foreach (Boid boid in Boids)
			{
				boid.Draw(gameTime, spriteBatch);
			}
		}

		public void Update(GameTime gameTime)
		{
			ApplyBoidRules();
			foreach (Boid boid in Boids)
			{
				boid.Update(gameTime);
			}
		}

		private void ApplyBoidRules()
		{
			foreach (Boid boid in Boids)
			{
				Boid[] nearbyBoids = GetNearbyBoids(boid);
				if (nearbyBoids.Length == 0) continue;
				if (DoSeparation)
				{
					boid.ApplySeparation(nearbyBoids, SeparationStrength, SeparationDistance);
				}
				if (DoAlignment)
				{
					boid.ApplyAlignment(nearbyBoids, AlignmentStrength, AlignmentDistance);
				}
				if (DoCohesion)
				{
					boid.ApplyCohesion(nearbyBoids, CohesionStrength, CohesionDistance);
				}
			}
		}

		private Boid[] GetNearbyBoids(Boid boid)
		{
			List<Boid> nearbyBoids = new List<Boid>();
			foreach (Boid otherBoid in Boids)
			{
				if (otherBoid != boid && Vector2.DistanceSquared(boid.Position, otherBoid.Position) < radius * radius)
				{
					nearbyBoids.Add(otherBoid);
				}
			}
			return nearbyBoids.ToArray();
		}

		public void HandleInput(InputHelper inputHelper) { }

		public void Reset()
		{
			InitializeBoids();
		}
	}
}