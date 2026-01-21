using UnityEngine;

public class ColorViewMono_HUE : MonoBehaviour
{

    [Range(0,1)]
    public float m_hueColorPercent;

    [Range(0, 1)]
    public float m_hueSaturationPercent;

    [Range(0, 1)]
    public float m_hueBrightnessPercent;

    public HueType m_hueTypeOfDegree;
    public enum HueType { Traditional360, Digital240 }


    public Color m_color;


    public void GetDegreeFromPercent(out float valueInDegree) {

        GetDegreeRangeFor(HueType.Traditional360, out float range);
            valueInDegree = m_hueColorPercent * range;

    }
    public void GetDegreeRangeFor(HueType type, out float degree) {

        if (m_hueTypeOfDegree == HueType.Traditional360)
            degree = 360;
        else
            degree =  240;

    }

    public void OnValidate()
    {
        m_color = GetColorFromHueTraditional();
        
    }

    public Color GetColorFromHueTraditional()
    {
        float hue = m_hueColorPercent * 360f;
        float saturation = Mathf.Clamp01(m_hueSaturationPercent);
        float brightness = Mathf.Clamp01(m_hueBrightnessPercent);
        Color newColor = Color.HSVToRGB(hue / 360f, saturation, brightness);

        return newColor;
    }


}
