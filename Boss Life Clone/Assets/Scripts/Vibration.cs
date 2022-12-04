using System;
using UnityEngine;

public class Vibration : MonoBehaviour
{
#if unity_android && !unity_editor
    public static androidjavaclass unityplayer = new androidjavaclass("com.unity3d.player.unityplayer");
    public static androidjavaobject currentactivity = unityplayer.getstatic<androidjavaobject>("currentactivity");
    public static androidjavaobject vibrator = currentactivity.call<androidjavaobject>("getsystemservice", "vibrator");
#else
    public static AndroidJavaClass unityplayer;
    public static AndroidJavaObject currentactivity;
    public static AndroidJavaObject vibrator;
#endif


    public static void vibrate(long milliseconds = 250)
    {
        if (isandroid())
        {
            vibrator.Call("vibrate", milliseconds);
        }
        else
        {
            Handheld.Vibrate();
        }
    }

    public static void cancel()
    {
        if (isandroid())
        {
            vibrator.Call("cancel");
        }
    }

    public static bool isandroid()
    {
#if unity_android
        return true;
#else
        return false;
#endif

    }
}