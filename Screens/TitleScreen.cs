using MonoSims.Engine;
using MonoSims.Engine.UI;
using Microsoft.Xna.Framework;

namespace MonoSims.Screens;

public class TitleScreen : Screen
{
	private Button SimSelectionButton;
	private Button GlobalSettingsButton;
	private Button exitButton;
	private TextElement titleText;

	public TitleScreen()
	{
		BackgroundSong = "main_menu";

		int ButtonWidth = 256;
		int ButtonHeight = ButtonWidth / 4;

		int ButtonSpacing = 100;
		int ButtonYStart = 270;
		int ButtonX = 480;


		titleText = new TextElement("Fonts/TitleFont");
		titleText.Text = "Mono Sims";
		titleText.Position = new Vector2(ButtonX, 64);
		Add(titleText);

		SimSelectionButton = new Button(new Vector2(ButtonX, ButtonYStart), new Vector2(ButtonWidth, ButtonHeight));
		SimSelectionButton.Text = "Simulation Selection";
		SimSelectionButton.Clicked += () => App.ScreenManager.SwitchTo(ScreenManager.SIMULATION_SELECTION_SCREEN);
		Add(SimSelectionButton);

		GlobalSettingsButton = new Button(new Vector2(ButtonX, ButtonYStart + ButtonSpacing), new Vector2(ButtonWidth, ButtonHeight));
		GlobalSettingsButton.Text = "Global Settings";
		GlobalSettingsButton.Clicked += () => App.ScreenManager.SwitchTo(ScreenManager.SETTINGS_SCREEN);
		Add(GlobalSettingsButton);

		exitButton = new Button(new Vector2(ButtonX, ButtonYStart + ButtonSpacing * 2), new Vector2(ButtonWidth, ButtonHeight));
		exitButton.Clicked += App.Instance.Exit;
		exitButton.Text = "Exit";
		Add(exitButton);
	}
}