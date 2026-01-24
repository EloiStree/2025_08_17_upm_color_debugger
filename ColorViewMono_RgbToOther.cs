
using Eloi.ColorView;
using UnityEngine;
using UnityEngine.Events;


public class ColorViewMono_RgbToOther : MonoBehaviour
{
    public Color m_colorReceived;
    public STRUCT_ColorRGB m_colorReceivedAsRGB;
    public STRUCT_ColorHSL m_colorReceivedAsHSL;
    public STRUCT_ColorHSV m_colorReceivedAsHSV;
    public STRUCT_ColorCMYK m_colorReceivedAsCMYK;
    public ColorEvent m_onPushed;


    [System.Serializable]
    public class ColorEvent
    {
        public UnityEvent<Color> m_onRgbColor;
        public UnityEvent<STRUCT_ColorRGB> m_onRgbAsStruct;
        public UnityEvent<STRUCT_ColorHSL> m_onHslAsStruct;
        public UnityEvent<STRUCT_ColorHSV> m_onHsvAsStruct;
        public UnityEvent<STRUCT_ColorCMYK> m_onCmykAsStruct;
    }


    public void PushInWithCenterPixel(RenderTexture source)
    {
        if (source != null && source.width > 2 && source.height > 2)
        {
            RenderTexture previous = RenderTexture.active;
            RenderTexture.active = source;
            Texture2D tex = new Texture2D(source.width, source.height, TextureFormat.RGBA32, false);
            tex.ReadPixels(new Rect(0, 0, source.width, source.height), 0, 0);
            tex.Apply();
            int x = source.width / 2;
            int y = source.height / 2;
            Color color = tex.GetPixel(x, y);
            RenderTexture.active = previous;
            PushIn(color);
            Object.Destroy(tex);
        }
    }

    [ContextMenu("Push inspector color")]
    public void PushInInspectorColor() { 
    
        PushIn(m_colorReceived);
    }

    public void PushIn(Color color) { 
    
        m_colorReceived = color;
        ColorViewUtilityConverter.ParseColor(m_colorReceived, out m_colorReceivedAsRGB);
        ColorViewUtilityConverter.ParseColor(m_colorReceivedAsRGB, out m_colorReceivedAsHSL);
        ColorViewUtilityConverter.ParseColor(m_colorReceivedAsRGB, out m_colorReceivedAsHSV);
        ColorViewUtilityConverter.ParseColor(m_colorReceivedAsRGB, out m_colorReceivedAsCMYK);
        m_onPushed.m_onRgbColor.Invoke(m_colorReceived);
        m_onPushed.m_onRgbAsStruct.Invoke(m_colorReceivedAsRGB);
        m_onPushed.m_onHslAsStruct.Invoke(m_colorReceivedAsHSL);
        m_onPushed.m_onHsvAsStruct.Invoke(m_colorReceivedAsHSV);
        m_onPushed.m_onCmykAsStruct.Invoke(m_colorReceivedAsCMYK);

    }


}
