using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    readonly List<GameObject> _cardsList = new List<GameObject>();
    [SerializeField] private RectTransform[] _cardPlaceHolders;
    [SerializeField] private GameObject[] _cards;

    private void Start()
    {
        foreach (var t in _cards)
        {
            _cardsList.Add(t);
        }
        SpawnMinerCard(null);
    }

    public void SpawnMinerCard(GameObject card)
    {
        if (!_cardsList.Contains(card) && card != null)
        {
            _cardsList.Add(card);
        }
        
        foreach (var t in _cardPlaceHolders)
        {
            if (t.transform.childCount <= 0)
            {
                int random = Random.Range(0, _cardsList.Count);
                GameObject obj = Instantiate(_cardsList[random]);// NEEDS OBJECT POOLING!
                obj.name = "Card";
                RectTransform rectTransform =  obj.GetComponent<RectTransform>();
                rectTransform.SetParent(t.transform, true);
                rectTransform.DOAnchorPos(Vector2.zero, 0);
                _cardsList.Remove(_cardsList[random]);
            }
        }
    }
}
