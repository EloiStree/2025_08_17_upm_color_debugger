using Eloi.ColorView;
using UnityEngine;
using UnityEngine.Events;

public class ColorViewMono_StringFormatHSV : MonoBehaviour
{


    public STRUCT_ColorHSV m_data;
    public string m_format = "HSV:{0:0.00} {1:0.00} {2:0.00}";
    public string m_asStringValue;
    public UnityEvent<string> m_onPushAsText;
    public UnityEvent<float> m_onPushPercentHue;
    public UnityEvent<float> m_onPushPercentSaturation;
    public UnityEvent<float> m_onPushPercentValue;
    public void PushIn(STRUCT_ColorHSV color)
    {
        m_data = color;
        m_asStringValue = string.Format(m_format, color.m_hue, color.m_saturation, color.m_value);
        m_onPushAsText.Invoke(m_asStringValue);
        m_onPushPercentHue.Invoke(color.m_hue);
        m_onPushPercentSaturation.Invoke(color.m_saturation);
        m_onPushPercentValue.Invoke(color.m_value);
    }
}