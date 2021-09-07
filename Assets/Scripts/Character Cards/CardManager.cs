using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    readonly List<GameObject> _laborerCardsList = new List<GameObject>();
    readonly List<GameObject> _troopCardsList = new List<GameObject>();
    [SerializeField] private RectTransform[] _cardPlaceHolders;
    [SerializeField] private GameObject[] _laborerCards, _troopCards;

    private void Start()
    {
        foreach (var t in _laborerCards)
        {
            _laborerCardsList.Add(t);
        }
        foreach (var t in _troopCards)
        {
            _troopCardsList.Add(t);
        }
        
        SpawnCharacterCard(null);
    }

    public void SpawnCharacterCard(GameObject characterCard)
    {
        if (characterCard != null)
        {
            if (!_laborerCardsList.Contains(characterCard) && characterCard.GetComponent<LaborerCard>())
            {
                _laborerCardsList.Add(characterCard);
            }
            else if(!_troopCardsList.Contains(characterCard) && characterCard.GetComponent<TroopCard>())
            {
                _troopCardsList.Add(characterCard);
            }
        }
        
        for (int i = 0; i < _cardPlaceHolders.Length; i++)
        {
            if (_cardPlaceHolders[i].childCount <= 0)
            {
                int random;
                GameObject obj;
                
                if (i < 2)
                {
                    random = Random.Range(0, _laborerCardsList.Count);
                    obj = ObjectPool.Instance.GetObject(_laborerCardsList[random]);
                    _laborerCardsList.Remove(_laborerCardsList[random]);
                }
                else
                {
                    random = Random.Range(0, _troopCardsList.Count);
                    obj = ObjectPool.Instance.GetObject(_troopCardsList[random]);
                    _troopCardsList.Remove(_troopCardsList[random]);
                }
                
                RectTransform rectTransform = obj.GetComponent<RectTransform>();
                rectTransform.SetParent(_cardPlaceHolders[i].transform,false);
            }
        }
    }
}
