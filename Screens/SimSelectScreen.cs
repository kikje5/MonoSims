using MonoSims.Engine;
using MonoSims.Engine.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoSims.Screens;

public class SimSelectScreen : Screen
{
	private Button BoidsButton;
	private Button PlanetsButton;
	private Button TitleButton;
	private TextElement SimSelectText;

	public SimSelectScreen()
	{
		int ButtonWidth = 256 - 32;
		int ButtonHeight = ButtonWidth / 4;

		int ButtonSpacing = 80;
		int ButtonYStart = 160;
		int ButtonX = 480;

		SimSelectText = new TextElement("Fonts/TitleFont");
		SimSelectText.Text = "Simulation Selection";
		SimSelectText.Position = new Vector2(ButtonX, 64);
		Add(SimSelectText);

		BoidsButton = new Button(new Vector2(ButtonX, ButtonYStart), new Vector2(ButtonWidth, ButtonHeight));
		BoidsButton.Text = "Boids Simulation";
		BoidsButton.Clicked += () => App.ScreenManager.SwitchTo(ScreenManager.BOIDS_SCREEN);
		Add(BoidsButton);

		PlanetsButton = new Button(new Vector2(ButtonX, ButtonYStart + ButtonSpacing), new Vector2(ButtonWidth, ButtonHeight));
		PlanetsButton.Text = "Planets Simulation";
		PlanetsButton.Clicked += () => App.ScreenManager.SwitchTo(ScreenManager.PLANETS_SCREEN);
		Add(PlanetsButton);

		TitleButton = new Button(new Vector2(ButtonX, ButtonYStart + ButtonSpacing * 2), new Vector2(ButtonWidth, ButtonHeight));
		TitleButton.Text = "Back to Title";
		TitleButton.Clicked += () => App.ScreenManager.SwitchTo(ScreenManager.TITLE_SCREEN);
		Add(TitleButton);
	}
}