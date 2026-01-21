using UnityEngine;

namespace Eloi.ColorView {
[System.Serializable]
public struct STRUCT_ColorHSV
{
    public float m_hue;         // 0–360
    public float m_saturation;  // 0–1
    public float m_value;       // 0–1
}

[System.Serializable]
public struct STRUCT_ColorHSL
{
    public float m_hue;         // 0–360
    public float m_saturation;  // 0–1
    public float m_lightness;   // 0–1
}

[System.Serializable]
public struct STRUCT_ColorRGB
{
    public float m_redPercent;   // 0–1
    public float m_greenPercent; // 0–1
    public float m_bluePercent;  // 0–1
}

[System.Serializable]
public struct STRUCT_ColorCMYK
{
    public float m_cyan;      // 0–1
    public float m_magenta;   // 0–1
    public float m_yellow;    // 0–1
    public float m_keyBlack;  // 0–1
}

public class ColorViewUtilityConverter
{

        public static void ParseColor(Color from, out STRUCT_ColorRGB to)
        { 
            to = new STRUCT_ColorRGB();
            to.m_redPercent = from.r;
            to.m_greenPercent = from.g;
            to.m_bluePercent = from.b;
        }

    // RGB → CMYK
    public static void ParseColor(STRUCT_ColorRGB from, out STRUCT_ColorCMYK to)
    {
        // 🤖 GPT CODE HERE CHECK IT LATER
        float r = Mathf.Clamp01(from.m_redPercent);
        float g = Mathf.Clamp01(from.m_greenPercent);
        float b = Mathf.Clamp01(from.m_bluePercent);

        float k = 1f - Mathf.Max(r, Mathf.Max(g, b));
        float c = (1f - r - k) / (1f - k + Mathf.Epsilon);
        float m = (1f - g - k) / (1f - k + Mathf.Epsilon);
        float y = (1f - b - k) / (1f - k + Mathf.Epsilon);

        if (Mathf.Approximately(k, 1f))
        {
            c = 0f; m = 0f; y = 0f;
        }

        to.m_cyan = c;
        to.m_magenta = m;
        to.m_yellow = y;
        to.m_keyBlack = k;
    }

    // RGB → HSL
    public static void ParseColor(STRUCT_ColorRGB from, out STRUCT_ColorHSL to)
    {
        // 🤖 GPT CODE HERE CHECK IT LATER
        float r = Mathf.Clamp01(from.m_redPercent);
        float g = Mathf.Clamp01(from.m_greenPercent);
        float b = Mathf.Clamp01(from.m_bluePercent);

        float max = Mathf.Max(r, Mathf.Max(g, b));
        float min = Mathf.Min(r, Mathf.Min(g, b));
        float delta = max - min;

        float h = 0f;
        if (delta > Mathf.Epsilon)
        {
            if (Mathf.Approximately(max, r))
                h = 60f * (((g - b) / delta) % 6f);
            else if (Mathf.Approximately(max, g))
                h = 60f * (((b - r) / delta) + 2f);
            else
                h = 60f * (((r - g) / delta) + 4f);
        }
        if (h < 0f) h += 360f;

        float l = (max + min) / 2f;
        float s = (delta < Mathf.Epsilon) ? 0f : (delta / (1f - Mathf.Abs(2f * l - 1f)));

        to.m_hue = h;
        to.m_saturation = s;
        to.m_lightness = l;
    }

    // RGB → HSV
    public static void ParseColor(STRUCT_ColorRGB from, out STRUCT_ColorHSV to)
    {

        // 🤖 GPT CODE HERE CHECK IT LATER
        float r = Mathf.Clamp01(from.m_redPercent);
        float g = Mathf.Clamp01(from.m_greenPercent);
        float b = Mathf.Clamp01(from.m_bluePercent);

        float max = Mathf.Max(r, Mathf.Max(g, b));
        float min = Mathf.Min(r, Mathf.Min(g, b));
        float delta = max - min;

        float h = 0f;
        if (delta > Mathf.Epsilon)
        {
            if (Mathf.Approximately(max, r))
                h = 60f * (((g - b) / delta) % 6f);
            else if (Mathf.Approximately(max, g))
                h = 60f * (((b - r) / delta) + 2f);
            else
                h = 60f * (((r - g) / delta) + 4f);
        }
        if (h < 0f) h += 360f;

        float s = (Mathf.Approximately(max, 0f)) ? 0f : (delta / max);
        float v = max;

        to.m_hue = h;
        to.m_saturation = s;
        to.m_value = v;
    }
}

}