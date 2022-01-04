using UnityEngine;

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
        var amount = Random.Range(4, 7);
        for (var i = 0; i < amount; i++)
        {
            _cardPrefab.name = i.ToString(); // Нужно убрать
            Instantiate(_cardPrefab, _hand);
        }
    }
}
