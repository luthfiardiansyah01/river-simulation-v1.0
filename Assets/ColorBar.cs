using UnityEngine;
using UnityEngine.UI;

public class ColorBar : MonoBehaviour
{
    public Image colorBarImage;
    public Gradient gradient;
    public int resolution = 100;

    void Start()
    {
        Texture2D texture = new Texture2D(resolution, 1);
        for (int i = 0; i < resolution; i++)
        {
            float t = (float)i / (resolution - 1);
            texture.SetPixel(i, 0, gradient.Evaluate(t));
        }
        texture.Apply();

        colorBarImage.sprite = Sprite.Create(texture, new Rect(0, 0, resolution, 1), Vector2.zero);
    }
}
