using System.Globalization;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class CardUIView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _art;
    [SerializeField] private TMP_Text _ManaCost;
    [SerializeField] private TMP_Text _AttackDamage;
    [SerializeField] private TMP_Text _HealthPoints;
    [SerializeField] private float _animCounterDuration = 0.5f;

    private Card _card;
    
    private void Awake()
    {
        _card = GetComponent<Card>();
        _card.ArtChanged += OnArtChanged;
        _card.FeatureChanged += OnFeatureChanged;
    }
    
    private void OnDestroy()
    {
        _card.ArtChanged -= OnArtChanged;
        _card.FeatureChanged -= OnFeatureChanged;
    }

    private void OnFeatureChanged()
    {
        AnimateCounter(_ManaCost, _card.Counters[ECardFeatures.Mana]);
        AnimateCounter(_AttackDamage, _card.Counters[ECardFeatures.Attack]);
        AnimateCounter(_HealthPoints, _card.Counters[ECardFeatures.Health]).OnComplete(CheckHealth);
    }

    private void OnArtChanged()
    {
        _art.sprite = _card.art;
    }
    
    private Tweener AnimateCounter(TMP_Text text, int to)
    {
        return DOVirtual.Float(int.Parse(text.text), to, _animCounterDuration, v
            => text.text = Mathf.Floor(v).ToString(CultureInfo.InvariantCulture));
    }

    private void CheckHealth()
    {
        if(int.Parse(_HealthPoints.text) <= 0) Dispose();
    }
    
    private void Dispose()
    {
        gameObject.SetActive(false);
        // Destroy this game object or do smth else
    }
}

