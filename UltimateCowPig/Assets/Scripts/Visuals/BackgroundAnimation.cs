using UnityEngine;
using UnityEngine.UI;

public class BackgroundAnimation : MonoBehaviour
{
    private Image _image;

    private readonly float _scrollSpeed = 0.125f;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    private void Start()
    {
        _image.material.mainTextureOffset = new(0, 0);
    }

    private void Update()
    {
        ScrollBackground();
    }

    private void OnApplicationQuit()
    {
        _image.material.mainTextureOffset = new(0, 0);
    }

    private void ScrollBackground()
    {
        Vector2 textureOffset = new(0, Time.time * _scrollSpeed);
        _image.material.mainTextureOffset = textureOffset;
    }
}
