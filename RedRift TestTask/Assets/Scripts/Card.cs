using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _art;
    [SerializeField] private Text _ManaCost;
    [SerializeField] private Text _AttackDamage;
    [SerializeField] private Text _HealthPoints;
    [SerializeField] private float _animCounterDuration = 1f;
    
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
    
    private void OnDestroy () => Dispose();

    public void SetRandomFeature()
    {
        var key = _counters.ElementAt(CardHandler.GetRandomIndex()).Key;
        _counters[key] = CardHandler.GetRandomValue();
        SetFeatures();
    }
    
    private async void SetArt()
    {
        _texture = await CardHandler.GetRemoteRandomTexture();
        _art.sprite = Sprite.Create(_texture, 
                new Rect(0.0f, 0.0f, _texture.width, _texture.height), new Vector2(0.5f, 0.5f), 100f);

    }

    private void GetDefaultFeatures()
    {
        _counters["Mana"] = CardHandler.GetRandomValue();
        _counters["Attack"] = CardHandler.GetRandomValue();
        _counters["Health"] = CardHandler.GetRandomValue(1);
        SetFeatures();
    }

    private void SetFeatures()
    {
        AnimateCounter(_ManaCost, _counters["Mana"]);
        AnimateCounter(_AttackDamage, _counters["Attack"]);
        AnimateCounter(_HealthPoints, _counters["Health"]).OnComplete(CheckHealth);
    }

    private void CheckHealth()
    {
        if(_counters["Health"] <= 0) Dispose();
    }

    private Tweener AnimateCounter(Text text, int to)
    {
        return DOVirtual.Float(int.Parse(text.text), to, _animCounterDuration, v
            => text.text = Mathf.Floor(v).ToString(CultureInfo.InvariantCulture));
    }

    private void Dispose()
    {
        gameObject.SetActive(false);
        Destroy(_texture);
    }
}
