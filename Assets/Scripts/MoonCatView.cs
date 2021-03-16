using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonCatView : MonoBehaviour
{
    // Default catId for Mooncat to be visable
    public string catId = "0x00135b6b9c";

    void Start()
    {
        UnityEngine.UI.Image image = this.gameObject.AddComponent<UnityEngine.UI.Image>();
        image.sprite = MoonCatFactory.Instance.GenerateMoonCatSprite(catId);
        image.rectTransform.sizeDelta = new Vector2(image.sprite.rect.width, image.sprite.rect.height);
    }
 
}
