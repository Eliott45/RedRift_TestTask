using UnityEngine;

public class Instantiater : MonoBehaviour
{
    [Header("Set in Inspector:")] 
    [SerializeField] private GameObject _cardPrefab;

    private void Start()
    {
        SpawnCards();
    }

    private void SpawnCards()
    {
        var amount = Random.Range(4, 6);
        for (var i = 0; i < amount; i++)
        {
            Instantiate(_cardPrefab, gameObject.transform.localPosition, Quaternion.identity);
        }
    }
}
