using Eloi.ColorView;
using UnityEngine;
using UnityEngine.Events;

public class ColorViewMono_StringFormatHSL : MonoBehaviour
{


    public STRUCT_ColorHSL m_data;
    public string m_format = "HSL:{0:0.00} {1:0.00} {2:0.00}";
    public string m_asStringValue;
    public UnityEvent<string> m_onPushAsText;
    public UnityEvent<float> m_onPushPercentHue;
    public UnityEvent<float> m_onPushPercentSaturation;
    public UnityEvent<float> m_onPushPercentLightness;
    public void PushIn(STRUCT_ColorHSL color)
    {
        m_data = color;
        m_asStringValue = string.Format(m_format, color.m_hue, color.m_saturation, color.m_lightness);
        m_onPushAsText.Invoke(m_asStringValue);
        m_onPushPercentHue.Invoke(color.m_hue);
        m_onPushPercentSaturation.Invoke(color.m_saturation);
        m_onPushPercentLightness.Invoke(color.m_lightness);
    }
}
