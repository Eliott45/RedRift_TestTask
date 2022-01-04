using System;
using UnityEngine;

namespace UI
{
    [Serializable]
    public class SpriteOrder
    {
        [SerializeField] private SpriteRenderer _renderer;
        [SerializeField] private int _order;

        public void ApplyOrderByBaseOrder(int order) => _renderer.sortingOrder = order + _order;
    }
}
