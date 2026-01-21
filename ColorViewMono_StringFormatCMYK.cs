using Eloi.ColorView;
using UnityEngine;
using UnityEngine.Events;

public class ColorViewMono_StringFormatCMYK : MonoBehaviour
{


    public STRUCT_ColorCMYK m_data;
    public string m_format = "CMYK:{0} {1} {2} {3}";
    public string m_asStringValue;
    public UnityEvent<string> m_onPushAsText;
    public UnityEvent<float> m_onPushPercentCyan;
    public UnityEvent<float> m_onPushPercentMagenta;
    public UnityEvent<float> m_onPushPercentYellow;
    public UnityEvent<float> m_onPushPercentKeyBlack;
    public void PushIn(STRUCT_ColorCMYK color)
    {
        m_data = color;
        m_asStringValue = string.Format(m_format, color.m_cyan, color.m_magenta, color.m_yellow, color.m_keyBlack);
        m_onPushAsText.Invoke(m_asStringValue);
        m_onPushPercentCyan.Invoke(color.m_cyan);
        m_onPushPercentMagenta.Invoke(color.m_magenta);
        m_onPushPercentYellow.Invoke(color.m_yellow);
        m_onPushPercentKeyBlack.Invoke(color.m_keyBlack);
    }
}
