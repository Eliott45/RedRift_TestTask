using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField] private float _degreeRotation = 4f;
    [SerializeField] private float _distance = 1.5f;
    [SerializeField] private float _height = 0.04f; // Decrease in altitude per degree.
    [SerializeField] private float _animDuration = 0.5f;
    
    private readonly List<GameObject> _cards = new List<GameObject>();

    private void OnTriggerEnter2D(Collider2D other)
    {
        _cards.Add(other.gameObject);
        NormalizeDeck();
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        _cards.Remove(other.gameObject);
        NormalizeDeck();
    }

    private void NormalizeDeck()
    {
        var x = _cards.Count / 2;
        var angle = x * _degreeRotation;
        for (var i = 0; i < _cards.Count; i++, x--, angle -= _degreeRotation)
        {
            var y = Math.Abs(angle) * _height;
            _cards[i].transform.DOMove(new Vector2(x * _distance, transform.position.y - y), _animDuration);
            _cards[i].transform.DORotate(new Vector3(0, 0, -angle), _animDuration);
        }
    }
}
