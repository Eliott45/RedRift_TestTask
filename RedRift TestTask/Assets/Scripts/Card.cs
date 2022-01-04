using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _art;
    [SerializeField] private Text _ManaCost;
    [SerializeField] private Text _AttackDamage;
    [SerializeField] private Text _HealthPoints;
    
    private readonly Dictionary<string, int> _counters = new Dictionary<string, int>
    {
        ["Mana"] = 0,
        ["Attack"] = 0,
        ["Health"] = 0
    };
    
    private Texture2D _texture;

    private void Awake()
    {
        GetDefaultFeatures();
        SetArt();
    }

    private async void SetArt()
    {
        _texture = await CardHandler.GetRemoteRandomTexture();
        _art.sprite = Sprite.Create(_texture, 
            new Rect(0.0f, 0.0f, _texture.width, _texture.height), new Vector2(0.5f, 0.5f), 100.0f); 
    }

    private void GetDefaultFeatures()
    {
        _counters["Mana"] = CardHandler.GetRandomValue(0);
        _counters["Attack"] = CardHandler.GetRandomValue(0);
        _counters["Health"] = CardHandler.GetRandomValue(0);
        SetFeatures();
    }

    private void SetFeatures()
    {
        _ManaCost.text = _counters["Mana"].ToString();
        _AttackDamage.text = _counters["Attack"].ToString();
        _HealthPoints.text = _counters["Health"].ToString();
    }

    public void SetRandomFeature()
    {
        var key = _counters.ElementAt(CardHandler.GetRandomIndex()).Key;
        _counters[key] = CardHandler.GetRandomValue();
        SetFeatures();
    }
    
    private void OnDestroy () => Dispose();

    private void Dispose () => Destroy(_texture); 
}
