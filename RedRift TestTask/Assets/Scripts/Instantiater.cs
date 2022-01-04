using UnityEngine;
using Utils;

public class Instantiater : MonoBehaviour
{
    [Header("Set in Inspector:")] 
    [SerializeField] private GameObject _cardPrefab;
    [SerializeField] private Transform _hand;

    private void Start()
    {
        SpawnCards();
    }

    private void SpawnCards()
    {
        var amount = CardHandler.GetRandomAmountInitialCards();
        for (var i = 0; i < amount; i++)
        {
            var go = _cardPrefab;
            go.name = i.ToString();
            Instantiate(go, _hand);
        }
    }
}
