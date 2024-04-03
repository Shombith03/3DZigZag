using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformColor : MonoBehaviour
{
    [SerializeField]
    private Color[] _colors;
    private MeshRenderer m_Renderer;

    private void Start()
    {
        m_Renderer = GetComponent<MeshRenderer>();
    }

    public void SwapColor()
    {
        Color randomColor = _colors[Random.Range(0, _colors.Length)];
        m_Renderer.material.color = randomColor;
    }

}
