using Eloi.ColorView;
using UnityEngine;
using UnityEngine.Events;

public class ColorViewMono_StringFormatRgb : MonoBehaviour {


    public STRUCT_ColorRGB m_data;
    public string m_format = "RGB:{0} {1} {2}";
    public string m_asStringValue;
    public UnityEvent<string> m_onPushAsText;
    public UnityEvent<float> m_onPushPercentRed;
    public UnityEvent<float> m_onPushPercentGreen;
    public UnityEvent<float> m_onPushPercentBlue;
    public void PushIn(STRUCT_ColorRGB color) {
        m_data = color;
        m_asStringValue = string.Format(m_format, color.m_redPercent, color.m_greenPercent, color.m_bluePercent);
        m_onPushAsText.Invoke(m_asStringValue);
        m_onPushPercentRed.Invoke(color.m_redPercent);
        m_onPushPercentGreen.Invoke(color.m_greenPercent);
        m_onPushPercentBlue.Invoke(color.m_bluePercent);
    }
}
