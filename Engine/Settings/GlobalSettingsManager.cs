
namespace MonoSims.Engine;

public enum Language
{
	English
}
public static class GlobalSettingsManager
{
	public static SettingsObject Settings { private get; set; } = new SettingsObject();

	public static Language Language
	{
		get => (Language)Settings.Language;
		set => Settings.Language = (int)value;
	}

	public static int MasterVolume
	{
		get => Settings.MasterVolume;
		set
		{
			if (value < 0)
			{
				Settings.MasterVolume = 100;
			}
			else if (value > 100)
			{
				Settings.MasterVolume = 0;
			}
			else
			{
				Settings.MasterVolume = value;
			}
			App.AudioManager.EffectVolume = (Settings.MasterVolume / 100f) * (Settings.SfxVolume / 100f);
			App.AudioManager.MusicVolume = (Settings.MasterVolume / 100f) * (Settings.MusicVolume / 100f);
		}
	}

	public static int MusicVolume
	{
		get => Settings.MusicVolume;
		set
		{
			if (value < 0)
			{
				Settings.MusicVolume = 100;
			}
			else if (value > 100)
			{
				Settings.MusicVolume = 0;
			}
			else
			{
				Settings.MusicVolume = value;
			}
			App.AudioManager.MusicVolume = (Settings.MasterVolume / 100f) * (Settings.MusicVolume / 100f);
		}
	}

	public static int SFXVolume
	{
		get => Settings.SfxVolume;
		set
		{
			if (value < 0)
			{
				Settings.SfxVolume = 100;
			}
			else if (value > 100)
			{
				Settings.SfxVolume = 0;
			}
			else
			{
				Settings.SfxVolume = value;
			}
			App.AudioManager.EffectVolume = (Settings.MasterVolume / 100f) * (Settings.SfxVolume / 100f);
		}
	}
}