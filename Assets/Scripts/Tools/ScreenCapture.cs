using UnityEngine;
using System.IO;

public class ScreenShotTaker : MonoBehaviour
{
    [SerializeField] private string saveLocation = "Screenshots"; // Default location

    // Example: Press the "P" key to take a screenshot
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TakeScreenshot();
        }
    }

    void TakeScreenshot()
    {
        // Create a new RenderTexture with the screen's width and height
        RenderTexture rt = new RenderTexture(Screen.width, Screen.height, 24);

        // Set the target texture to the newly created RenderTexture
        Camera.main.targetTexture = rt;

        // Create a new Texture2D with the screen's width and height
        Texture2D screenShot = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);

        // Render the camera's view into the RenderTexture
        Camera.main.Render();

        // Read pixels from the RenderTexture and apply them to the Texture2D
        RenderTexture.active = rt;
        screenShot.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        Camera.main.targetTexture = null;
        RenderTexture.active = null;
        Destroy(rt);

        // Convert Texture2D to PNG bytes with highest quality
        byte[] bytes = screenShot.EncodeToPNG();

        // Specify the file path where you want to save the screenshot
        string filePath = Path.Combine(Application.persistentDataPath, saveLocation);
        Directory.CreateDirectory(filePath); // Create directory if it doesn't exist

        // Set the desired file name
        string fileName = Path.Combine(filePath, "screenshot.png");

        // Save the screenshot as a PNG file with highest quality
        System.IO.File.WriteAllBytes(fileName, bytes);

        Debug.Log("Screenshot captured: " + fileName);
    }
}
