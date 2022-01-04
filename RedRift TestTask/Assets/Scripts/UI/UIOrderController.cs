using UnityEngine;

namespace UI
{
    public class UIOrderController : MonoBehaviour
    {
        [SerializeField] private SpriteOrder[] _spritesOrders;
        [SerializeField] private Canvas _UI;
        [SerializeField] private int _defaultUIOrder = 3;
        
        public void ApplyOrder(int layout)
        {
            layout *= 4;
        
            foreach (var spriteOrder in _spritesOrders)
            {
                spriteOrder.ApplyOrderByBaseOrder(layout);
            }

            _UI.sortingOrder = layout + _defaultUIOrder;
        }
    }
}
