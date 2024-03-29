using UnityEngine;

public class ResolutionScreenAndFullSceen
{
    static Resolution[] resolutions = Screen.resolutions;
    static Resolution currentResolution;
    static int resolutionIndex = 0;


    static float width = Screen.currentResolution.width;
    static float height = Screen.currentResolution.height;

    static bool isFullScreen = false;

    static ResolutionScreenAndFullSceen()
    {
        if (PlayerPrefs.HasKey("ScreenWidth"))
            width = PlayerPrefs.GetFloat("ScreenWidth");
        if (PlayerPrefs.HasKey("ScreenHeight"))
            height = PlayerPrefs.GetFloat("ScreenHeight");

        if (PlayerPrefs.HasKey("IsFullScreen"))
            isFullScreen = (PlayerPrefs.GetInt("IsFullScreen") == 1);

        FindCurrentResolutionAndResolutionIndex();
    }
    public Resolution Resolution
    {
        set
        {
            currentResolution = value;

            width = currentResolution.width;
            PlayerPrefs.SetFloat("ScreenWidth", width);

            height = currentResolution.height;
            PlayerPrefs.SetFloat("ScreenHeight", height);

            FindCurrentResolutionAndResolutionIndex();
        }
        get
        {

            return currentResolution;
        }
    }

    public int ResolutionIndex
    {
        set
        {
            resolutionIndex = value;
            currentResolution = resolutions[resolutionIndex];

            width = currentResolution.width;
            PlayerPrefs.SetFloat("ScreenWidth", width);

            height = currentResolution.height;
            PlayerPrefs.SetFloat("ScreenHeight", height);
        }
        get
        {

            return resolutionIndex;
        }
    }
    public bool IsFullScreen
    {
        set
        {
            isFullScreen = value;
            PlayerPrefs.SetInt("IsFullScreen", isFullScreen ? 1 : 0);
        }
        get
        {
            return isFullScreen;
        }
    }

    static void FindCurrentResolutionAndResolutionIndex()
    {
        for (int i = 0; i < resolutions.Length; ++i)
        {
            if (width == resolutions[i].width && height == resolutions[i].height)
            {
                currentResolution = resolutions[i];
                resolutionIndex = i;
            }
        }
    }
}
