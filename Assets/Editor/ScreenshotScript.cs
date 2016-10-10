using UnityEngine;
using UnityEditor;
using System.Collections;

public class ScreenshotScript {
    [MenuItem("Screenshot/Take screenshot")]

    static void Screenshot()
    {
        Application.CaptureScreenshot(System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")+ ".png");
    }
}
