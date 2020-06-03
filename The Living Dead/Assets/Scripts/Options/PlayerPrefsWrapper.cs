using UnityEngine;

/// <summary>
/// A custom player prefs wrapper that gives us more options with saving and retrieving data.
/// </summary>
public static class PlayerPrefsWrapper
{
    /// <summary>
    /// Sets the value of the preference identified by the key.
    /// </summary>
    public static void SetFloat(string key, float value)
    {
        PlayerPrefs.SetFloat(key, value);
    }

    /// <summary>
    /// Sets the value of the preference identified by the key.
    /// </summary>
    public static void SetInt(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
    }

    /// <summary>
    /// Sets the value of the preference identified by the key.
    /// </summary>
    public static void SetBool(string key, bool value)
    {
        var intValue = value == true ? Constants.PlayerPrefs.BoolValueTrue : Constants.PlayerPrefs.BoolValueFalse;
        PlayerPrefs.SetInt(key, intValue);
    }

    /// <summary>
    /// Returns the value corresponding to the key in the preference file if it exists.
    /// If it does not, the method returns null.
    /// </summary>
    /// <returns>True or false if the key exists, null if not.</returns>
    public static bool? TryGetBool(string key)
    {
        var value = PlayerPrefs.GetInt(key, int.MaxValue);

        if (value == int.MaxValue)
        {
            return null;
        }
        else if (value == Constants.PlayerPrefs.BoolValueTrue)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Returns the value corresponding to the key in the preference file if it exists.
    /// If it does not, the method returns null.
    /// </summary>
    /// <returns>Float value if the key exists, null if not.</returns>
    public static float? TryGetFloat(string key)
    {
        var value = PlayerPrefs.GetFloat(key, float.MaxValue);

        if (value == float.MaxValue)
        {
            return null;
        }
        else
        {
            return value;
        }
    }

    /// <summary>
    /// Returns the value corresponding to the key in the preference file if it exists.
    /// If it does not, the method returns null.
    /// </summary>
    /// <returns>Int value if the key exists, null if not.</returns>
    public static int? TryGetInt(string key)
    {
        var value = PlayerPrefs.GetInt(key, int.MaxValue);

        if (value == int.MaxValue)
        {
            return null;
        }
        else
        {
            return value;
        }
    }
}