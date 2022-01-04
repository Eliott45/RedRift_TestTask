using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _art;

    public Texture2D _texture;

    private void Awake()
    {
        SetArt();
    }

    private async void SetArt()
    {
        _texture = await CardHandler.GetRemoteTexture();
        _art.sprite = Sprite.Create(_texture, 
            new Rect(0.0f, 0.0f, _texture.width, _texture.height), new Vector2(0.5f, 0.5f), 100.0f); 
    }

    private void OnDestroy () => Dispose();

    private void Dispose () => Destroy(_texture); 
}
