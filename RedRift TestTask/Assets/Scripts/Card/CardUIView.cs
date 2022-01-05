using System;
using System.Globalization;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Card
{
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
            
            try
            {
                Validate();
            }
            catch (Exception)
            {
                Dispose(); // Destroy
                throw;
            }
            
            BindEvents();
        }
    
        private void OnDestroy()
        {
            Dispose();
        }

        private void BindEvents()
        {
            _card.ArtChanged += OnArtChanged;
            _card.FeatureChanged += OnFeatureChanged;
        }
        
        private void UnBindEvents()
        {
            _card.ArtChanged -= OnArtChanged;
            _card.FeatureChanged -= OnFeatureChanged;
        }

        private void Validate()
        {
            if(_art == null) throw new InvalidOperationException();
            if(_ManaCost == null) throw new InvalidOperationException();
            if(_AttackDamage == null) throw new InvalidOperationException();
            if(_HealthPoints == null) throw new InvalidOperationException();
            if(_card == null) throw new InvalidOperationException();
        }

        private void OnFeatureChanged()
        {
            AnimateCounter(_ManaCost, _card.Counters[ECardFeatures.Mana]);
            AnimateCounter(_AttackDamage, _card.Counters[ECardFeatures.Attack]);
            AnimateCounter(_HealthPoints, _card.Counters[ECardFeatures.Health]).OnComplete(CheckHealth);
        }

        private void OnArtChanged() => _art.sprite = _card.Art;
        
        private Tweener AnimateCounter(TMP_Text text, int to)
        {
            return DOVirtual.Float(int.Parse(text.text), to, _animCounterDuration, v
                => text.text = Mathf.Floor(v).ToString(CultureInfo.InvariantCulture));
        }

        private void CheckHealth()
        {
            if (int.Parse(_HealthPoints.text) <= 0) Dispose(); // Destroy => Dispose
        }
    
        private void Dispose()
        {
            gameObject.SetActive(false);
            UnBindEvents();
        }
    }
}

