using UnityEngine;

public static class Spector
{
    public static Color GBR(float spectorValue, float maxColor)
    {
        float MaxColorLight = maxColor / 255;

        float value = spectorValue / 100;

        float green = 0;
        float blue = 0;
        float red = 0;

        float greenValue = 0.25f;
        float redValue = 0.75f;


        // GREEN \\
        if (value < greenValue)
            green = MaxColorLight;
        else if (value > greenValue && value < 0.5f || value == greenValue)
            green = (1 - (value - greenValue) * 4) * MaxColorLight;
        else
            green = 0;

        // BLUE \\
        if (value < 0.5f)
            blue = value * 3 * MaxColorLight;
        else if (value > 0.5f)  
            blue = (1 - value) * 3 * MaxColorLight;

        // RED \\
        if (value < redValue && value > 0.5f || value == redValue)
            red = (value - 0.5f) * 4 * MaxColorLight;
        else if (value > redValue)
            red = MaxColorLight;
        else
            red = 0;

        // RESULT \\
        return new Color(red, green, blue, 1);
    }
}
