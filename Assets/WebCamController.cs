using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WebCamController : MonoBehaviour
{
    [SerializeField] RawImage m_rawImage = default;
    [SerializeField, Range(1, 60)] int m_fps = 30;
    WebCamTexture m_texture = default;

    public void SwitchWebCam()
    {
        if (m_texture && m_texture.isPlaying)
        {
            TurnOffWebCam();
        }
        else if (m_texture == null)
        {
            TurnOnWebCam();
        }
    }

    public void TurnOnWebCam()
    {
        m_texture = new WebCamTexture();
        m_texture.requestedFPS = m_fps;
        m_rawImage.texture = m_texture;
        m_texture.Play();
    }

    public void TurnOffWebCam()
    {
        m_texture.Stop();
        m_texture = null;
        m_rawImage.texture = null;
    }
}
