using UnityEngine;

public static class PlayerPrefsContainer 
{
    private const string languages = "Languages";
    public static void SetLanguages(int value)
    {
        PlayerPrefs.SetInt(languages, value);
    }
    public static int GetLanguages => PlayerPrefs.GetInt(languages);
}
