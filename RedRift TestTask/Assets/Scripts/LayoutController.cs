using UnityEngine;

public class LayoutController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _card;
    [SerializeField] private SpriteRenderer _art;
    [SerializeField] private int _defaultArtLayer = 1;
    [SerializeField] private Canvas _UI;
    [SerializeField] private int _defaultUILayer = 3;
    [SerializeField] private SpriteRenderer _title;
    [SerializeField] private int _defaultTitleLayer = 2;
    [SerializeField] private SpriteRenderer[] _countersBackground;
    [SerializeField] private int _defaultCountersBackgroundLayer = 2;

    public void SetLayout(int layout)
    {
        layout *= 4;
        
        _card.sortingOrder = layout;
        _art.sortingOrder = layout + _defaultArtLayer;
        _UI.sortingOrder = layout + _defaultUILayer;
        _title.sortingOrder = layout + _defaultTitleLayer;
        foreach (var bg in _countersBackground)
        {
            bg.sortingOrder = layout + _defaultCountersBackgroundLayer;
        }
    }
}
