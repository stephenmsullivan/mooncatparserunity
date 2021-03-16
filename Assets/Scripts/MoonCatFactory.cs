using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonCatFactory : MonoBehaviour
{
    public static MoonCatFactory Instance;

    public MoonCatParser parser;

    void Awake()
    {
        Instance = this;
    }

	// Returns a mooncat sprite at a multiple of the standard pixel size
	// The standard Mooncat Image is 20 x 20
	public Sprite GenerateMoonCatSprite(string catId)
	{
		// get the mooncat color data for this cat ID
		Color[][] data = parser.GetMoonCatData(catId);

		Texture2D texture = new Texture2D(data.Length, data[0].Length, TextureFormat.RGBA32,true);
		texture.filterMode = FilterMode.Point;
		texture.wrapMode = TextureWrapMode.Clamp;

		Sprite mooncatSprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f),1);
		
		for (var i = 0; i < data.Length; i++)
		{
			for (var j = 0; j < data[i].Length; j++)
			{
				Color color = data[i][j];
				if (color != null)
				{
					texture.SetPixel(i, j, color);
				}
			}
		}

		texture.Apply();

		return mooncatSprite;
	}
}
