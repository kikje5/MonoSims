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
		int ButtonWidth = 512;
		int ButtonHeight = ButtonWidth / 4;

		int ButtonSpacing = ButtonHeight + 64;
		int ButtonYStart = 512;
		int ButtonX = 960;

		Vector2 buttonSize = new Vector2(ButtonWidth, ButtonHeight);

		SimSelectText = new TextElement("Fonts/TitleFont");
		SimSelectText.Text = "Simulation Selection";
		SimSelectText.Position = new Vector2(ButtonX, 128);
		Add(SimSelectText);

		BoidsButton = new Button(new Vector2(ButtonX, ButtonYStart), buttonSize);
		BoidsButton.Text = "Boids Simulation";
		BoidsButton.Clicked += () => App.ScreenManager.SwitchTo(ScreenManager.BOIDS_SCREEN);
		Add(BoidsButton);

		PlanetsButton = new Button(new Vector2(ButtonX, ButtonYStart + ButtonSpacing), buttonSize);
		PlanetsButton.Text = "Planets Simulation";
		PlanetsButton.Clicked += () => App.ScreenManager.SwitchTo(ScreenManager.TITLE_SCREEN);
		Add(PlanetsButton);

		TitleButton = new Button(new Vector2(ButtonX, ButtonYStart + ButtonSpacing * 2), buttonSize);
		TitleButton.Text = "Back to Title";
		TitleButton.Clicked += () => App.ScreenManager.SwitchTo(ScreenManager.TITLE_SCREEN);
		Add(TitleButton);
	}
}