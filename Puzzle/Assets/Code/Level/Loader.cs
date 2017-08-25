using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Reads level image from the StreamingAssets folder,
/// Creates objects/level from the image's pixel color.
/// </summary>
public class Loader : MonoBehaviour
{
    // This is a string string for early development purposes
    // We can make it an array or list of strings for multiple levels
    public string LevelFileName;

    // A mapping class from colour to a GameObject
    [SerializeField]
    private ColourToObject[] colourToObjects;

    // A look up table for the GameObjects we can create base on a colour key
    private Dictionary<Color32, GameObject> objectDictionary;
    
    private void Start()
    {
        objectDictionary = new Dictionary<Color32, GameObject>();

        // For every mapped object we have
        foreach (ColourToObject cto in colourToObjects)
        {
            // Add it to the look up table
            objectDictionary.Add(cto.Colour, cto.Object);
        }

        LoadLevel();
    }

    /// <summary>
    /// Creates a level from an image file (image MUST have transparency)
    /// </summary>
    private void LoadLevel()
    {
        // Get the correct file path
        string filePath = Application.dataPath + "/StreamingAssets/Levels/" + LevelFileName;

        // Grab all the bytes from the image so we can create a new Texture2D from it
        byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);

        // Create said texture
        Texture2D levelTexture = new Texture2D(2, 2);

        // Give the texture an image from the byte data of the image
        levelTexture.LoadImage(fileBytes);

        // Grab all the pixels in the image
        Color32[] pixels = levelTexture.GetPixels32();

        // Cache the width and height for easier looping
        int width = levelTexture.width;
        int height = levelTexture.height;

        for (int x = 0; x < width; ++x)
        {
            for (int y = 0; y < height; ++y)
            {
                // Spawn an object at the x, y that we're at
                // (y * width) + x <---- this may need some explaining
                // We essentially want to get the colour at the x, y position
                // that we're at but obviously the pixels array is a 1D array.
                // To get the colour we want, we can multiply the y 'pos' by
                // the width to get the y from the 1D array.
                // https://youtu.be/EmtU0eloTlE?t=12m32s <-- A better explaination than I can give.
                SpawnObjectAt(pixels[(y * width) + x], x, y);
            }
        }
    }

    /// <summary>
    /// Spawn an Object at the given x, y position
    /// </summary>
    /// <param name="colour">The colour to use in the look up process</param>
    /// <param name="x">The X position we want</param>
    /// <param name="y">The Y position we want</param>
    private void SpawnObjectAt(Color32 colour, int x, int y)
    {
        // NOTE: This process will only allow us to use non-transparent colours.
        //       Might be a little 'hacky' but whatever, it makes 'designing' levels
        //       in Photoshop or something and bringing the result in WAY easier as
        //       we can just check 'whole' byte colours. Example: RGBA(0, 255, 0, 255) <- Player.
        if (colour.a <= 0.0f)
            return;

        // Get the GameObject we want to spawn
        GameObject go = GameObjectFromColour(colour);
        
        // If we actually got something
        if (go != null)
        {
            Instantiate(go, new Vector3(x, y, 0.0f), Quaternion.identity, this.transform);
        }
    }

    /// <summary>
    /// Looks up the GameObject from the ColourToObject table we have
    /// </summary>
    /// <param name="c">Colour to look with</param>
    /// <returns>GameObject from CTO look up table</returns>
    private GameObject GameObjectFromColour(Color32 c)
    {
        GameObject result = null;
        result = objectDictionary[c];
        return result;
    }
}
