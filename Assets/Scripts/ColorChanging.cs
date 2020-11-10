using UnityEngine;

public class ColorChanging : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;
    public float delay = 0.4f;

    public static Color colorCyan;
    public static Color colorYellow;
    public static Color colorMagenta;
    public static Color colorPink;
    public Color[] colorArray = new Color[] { colorCyan, colorYellow, colorMagenta, colorPink };

    private int index = 0;

    void Update()
    {
        SetColor();
    }

    public void SetColor()
    {
        if (delay <= 0)
        {
            spriteRenderer.color = colorArray[index % 4];
            index++;
            delay = 0.4f;
        }

        delay -= Time.deltaTime;
    }
}
