using System.Collections.Generic;
using DG.Tweening;
using MyUtils;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField] private RectTransform[] _cardPlaceHolders;
    [SerializeField] private GameObject[] _cards;

    private void Start()
    {
        List<GameObject> cardsList = new List<GameObject>();
        
        foreach (var t in _cards)
        {
            cardsList.Add(t);
        }

        int cardsListCount = cardsList.Count;
        
        for (int i = 0; i < cardsListCount; i++)
        {
            int random = Random.Range(0, cardsList.Count);
            GameObject obj = ObjectPool.Instance.GetObject(cardsList[random]);

            foreach (var t in _cardPlaceHolders)
            {
                if (t.transform.childCount <= 0)
                {
                    RectTransform rectTransform =  obj.GetComponent<RectTransform>();
                    rectTransform.SetParent(t.transform, true);
                    rectTransform.DOAnchorPos(t.anchoredPosition, 0);
                    break;
                }
            }

            cardsList.Remove(cardsList[random]);
        }
    }
}
