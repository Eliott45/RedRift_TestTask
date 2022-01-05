using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utils;

namespace Card
{
    public class Card : MonoBehaviour
    {
        public Sprite art;
        public event Action ArtChanged;
        public event Action FeatureChanged;
        public readonly Dictionary<ECardFeatures, int> Counters = new Dictionary<ECardFeatures, int>
        {
            [ECardFeatures.Attack] = 0,
            [ECardFeatures.Mana] = 0,
            [ECardFeatures.Health] = 0
        };

        private void Awake()
        {
            GetDefaultFeatures();
            SetArt();
        }
    
        public void SetRandomFeature()
        {
            var key = Counters.ElementAt(CardHandler.GetRandomFeatureIndex()).Key;
            Counters[key] = CardHandler.GetRandomFeatureValue();
            SetFeatures();
        }
    
        private async void SetArt()
        {
            art = await CardHandler.GetRandomArt();
            ArtChanged?.Invoke();
        }

        private void GetDefaultFeatures()
        {
            Counters[ECardFeatures.Attack] = CardHandler.GetRandomFeatureValue();
            Counters[ECardFeatures.Mana] = CardHandler.GetRandomFeatureValue();
            Counters[ECardFeatures.Health] = CardHandler.GetRandomFeatureValue(1);
            SetFeatures();
        }

        private void SetFeatures() => FeatureChanged?.Invoke();
    }
}
