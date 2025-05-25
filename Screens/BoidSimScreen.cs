using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoSims.Engine;
using MonoSims.Engine.UI;
using MonoSims.Boids;
using Microsoft.Xna.Framework.Input;
using MonoSims;

namespace BoidSim.Screens;

public class BoidSimScreen : Screen
{
	private BoidManager _boidManager;

	private Button BackButton;

	private Button Separation;
	private IntegerInput SeparationInput;
	private Button alignment;
	private IntegerInput AlignmentInput;
	private Button cohesion;
	private IntegerInput CohesionInput;

	private Button DoClearButton;

	private bool showUI = true;

	public BoidSimScreen()
	{
		_boidManager = new BoidManager();

		int ButtonWidth = 256 + 128;
		int ButtonHeight = ButtonWidth / 4;

		int ButtonSpacing = ButtonHeight + 32;
		int ButtonYStart = ButtonHeight / 2 + 32;
		int ButtonX = 960;
		int RightSideX = 1920 - ButtonWidth / 2 - 32;

		Vector2 buttonSize = new Vector2(ButtonWidth, ButtonHeight);

		Vector2 InputSize = new Vector2(ButtonWidth - 128, ButtonHeight);

		BackButton = new Button(new Vector2(ButtonX, 1000), buttonSize);
		BackButton.Text = "Back to Selection";
		BackButton.Clicked += () =>
		{
			App.ScreenManager.SwitchTo(ScreenManager.SIMULATION_SELECTION_SCREEN);
			App.DoClear = true; // Reset the clear flag when going back
		};
		Add(BackButton);

		Separation = new Button(new Vector2(RightSideX, ButtonYStart), buttonSize);
		Separation.Text = "Separation: ON";
		Separation.Clicked += () =>
		{
			_boidManager.DoSeparation = !_boidManager.DoSeparation;
			Separation.Text = _boidManager.DoSeparation ? "Separation: ON" : "Separation: OFF";
		};
		Add(Separation);

		SeparationInput = new IntegerInput(new Vector2(RightSideX, ButtonYStart + ButtonSpacing), InputSize);
		SeparationInput.Integer = _boidManager.SeparationStrength;
		SeparationInput.OnIntegerChanged += () =>
		{
			_boidManager.SeparationStrength = SeparationInput.Integer;
		};
		Add(SeparationInput);

		alignment = new Button(new Vector2(RightSideX, ButtonYStart + ButtonSpacing * 2), buttonSize);
		alignment.Text = "Alignment: ON";
		alignment.Clicked += () =>
		{
			_boidManager.DoAlignment = !_boidManager.DoAlignment;
			alignment.Text = _boidManager.DoAlignment ? "Alignment: ON" : "Alignment: OFF";
		};
		Add(alignment);

		AlignmentInput = new IntegerInput(new Vector2(RightSideX, ButtonYStart + ButtonSpacing * 3), InputSize);
		AlignmentInput.Integer = _boidManager.AlignmentStrength;
		AlignmentInput.OnIntegerChanged += () =>
		{
			_boidManager.AlignmentStrength = AlignmentInput.Integer;
		};
		Add(AlignmentInput);

		cohesion = new Button(new Vector2(RightSideX, ButtonYStart + ButtonSpacing * 4), buttonSize);
		cohesion.Text = "Cohesion: ON";
		cohesion.Clicked += () =>
		{
			_boidManager.DoCohesion = !_boidManager.DoCohesion;
			cohesion.Text = _boidManager.DoCohesion ? "Cohesion: ON" : "Cohesion: OFF";
		};
		Add(cohesion);

		CohesionInput = new IntegerInput(new Vector2(RightSideX, ButtonYStart + ButtonSpacing * 5), InputSize);
		CohesionInput.Integer = _boidManager.CohesionStrength;
		CohesionInput.OnIntegerChanged += () =>
		{
			_boidManager.CohesionStrength = CohesionInput.Integer;
		};
		Add(CohesionInput);

		DoClearButton = new Button(new Vector2(RightSideX, ButtonYStart + ButtonSpacing * 6), buttonSize);
		DoClearButton.Text = "Do Screen Clear: ON";
		DoClearButton.Clicked += () =>
		{
			App.DoClear = !App.DoClear;
			DoClearButton.Text = App.DoClear ? "Do Screen Clear: ON" : "Do Screen Clear: OFF";
		};
		Add(DoClearButton);
	}

	public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
	{
		_boidManager.Draw(gameTime, spriteBatch);
		if (showUI)
		{
			base.Draw(gameTime, spriteBatch);
		}
	}

	public override void Update(GameTime gameTime)
	{
		_boidManager.Update(gameTime);
		if (showUI)
		{
			base.Update(gameTime);
		}
	}

	public override void HandleInput(InputHelper inputHelper)
	{
		if (inputHelper.KeyPressed(Keys.Space))
		{
			showUI = !showUI;
		}
		if (showUI)
		{
			base.HandleInput(inputHelper);
		}
	}

	public override void Reset()
	{
		_boidManager.Reset();
		showUI = true;
		base.Reset();
	}
}