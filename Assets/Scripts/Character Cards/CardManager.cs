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
                Debug.Log("laborer");
            }
            else if(!_troopCardsList.Contains(characterCard) && characterCard.GetComponent<TroopCard>())
            {
                _troopCardsList.Add(characterCard);
                Debug.Log("troop");
            }
        }
        
        /*foreach (var t in _cardPlaceHolders)
        {
            if (t.transform.childCount <= 0)
            {
                int random = Random.Range(0, _laborerCardsList.Count);
                GameObject obj = Instantiate(_laborerCardsList[random]);// NEEDS OBJECT POOLING!
                obj.name = "Card";
                RectTransform rectTransform =  obj.GetComponent<RectTransform>();
                rectTransform.SetParent(t.transform, true);
                rectTransform.DOAnchorPos(Vector2.zero, 0);
                _laborerCardsList.Remove(_laborerCardsList[random]);
            }
        }*/

        for (int i = 0; i < _cardPlaceHolders.Length; i++)
        {
            if (_cardPlaceHolders[i].childCount <= 0)
            {
                int random;
                GameObject obj;
                
                if (i < 2)
                {
                    random = Random.Range(0, _laborerCardsList.Count);
                    obj = Instantiate(_laborerCardsList[random]);// NEEDS OBJECT POOLING!
                    _laborerCardsList.Remove(_laborerCardsList[random]);
                }
                else
                {
                    random = Random.Range(0, _troopCardsList.Count);
                    obj = Instantiate(_troopCardsList[random]);// NEEDS OBJECT POOLING!
                    _troopCardsList.Remove(_troopCardsList[random]);
                }

                obj.SetActive(true);
                obj.name = "Card";
                RectTransform rectTransform = obj.GetComponent<RectTransform>();
                rectTransform.SetParent(_cardPlaceHolders[i].transform,false);
                rectTransform.DOAnchorPos(Vector2.zero, 0);
            }
        }
    }
}
