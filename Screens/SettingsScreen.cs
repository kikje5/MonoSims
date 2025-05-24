using MonoSims.Engine;
using MonoSims.Engine.UI;
using Microsoft.Xna.Framework;

namespace MonoSims.Screens;

public class SettingsScreen : Screen
{
	Button languageButton;
	Button masterVolumeButton;
	Button musicVolumeButton;
	Button sfxVolumeButton;
	Button backButton;
	private TextElement settingsText;
	public SettingsScreen()
	{
		int ButtonWidth = 256 - 32;
		int ButtonHeight = ButtonWidth / 4;

		int ButtonSpacing = 80;
		int ButtonYStart = 160;
		int ButtonX = 480;

		settingsText = new TextElement("Fonts/TitleFont");
		settingsText.Text = "Settings";
		settingsText.Position = new Vector2(ButtonX, 64);
		Add(settingsText);

		languageButton = new Button(new Vector2(ButtonX, ButtonYStart), new Vector2(ButtonWidth, ButtonHeight));
		languageButton.Text = "Language: " + GlobalSettingsManager.Language.ToString();
		languageButton.Clicked += () =>
		{
			GlobalSettingsManager.Language = GlobalSettingsManager.Language == Language.English ? Language.English : Language.English;
			languageButton.Text = "Language: " + GlobalSettingsManager.Language.ToString();
		};
		Add(languageButton);

		masterVolumeButton = new Button(new Vector2(ButtonX, ButtonYStart + ButtonSpacing), new Vector2(ButtonWidth, ButtonHeight));
		masterVolumeButton.Text = "Master Volume: " + GlobalSettingsManager.MasterVolume;
		masterVolumeButton.Clicked += () =>
		{
			GlobalSettingsManager.MasterVolume = GlobalSettingsManager.MasterVolume + 10;
			masterVolumeButton.Text = "Master Volume: " + GlobalSettingsManager.MasterVolume;
		};
		Add(masterVolumeButton);

		musicVolumeButton = new Button(new Vector2(ButtonX, ButtonYStart + ButtonSpacing * 2), new Vector2(ButtonWidth, ButtonHeight));
		musicVolumeButton.Text = "Music Volume: " + GlobalSettingsManager.MusicVolume;
		musicVolumeButton.Clicked += () =>
		{
			GlobalSettingsManager.MusicVolume = GlobalSettingsManager.MusicVolume + 10;
			musicVolumeButton.Text = "Music Volume: " + GlobalSettingsManager.MusicVolume;
		};
		Add(musicVolumeButton);

		sfxVolumeButton = new Button(new Vector2(ButtonX, ButtonYStart + ButtonSpacing * 3), new Vector2(ButtonWidth, ButtonHeight));
		sfxVolumeButton.Text = "SFX Volume: " + GlobalSettingsManager.SFXVolume;
		sfxVolumeButton.Clicked += () =>
		{
			GlobalSettingsManager.SFXVolume = GlobalSettingsManager.SFXVolume + 10;
			sfxVolumeButton.Text = "SFX Volume: " + GlobalSettingsManager.SFXVolume;
		};
		Add(sfxVolumeButton);

		backButton = new Button(new Vector2(ButtonX, ButtonYStart + ButtonSpacing * 4), new Vector2(ButtonWidth, ButtonHeight));
		backButton.Text = "Go Back";
		backButton.Clicked += () => App.ScreenManager.SwitchTo(ScreenManager.TITLE_SCREEN);
		Add(backButton);
	}
}