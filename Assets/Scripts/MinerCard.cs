using UnityEngine;
using UnityEngine.UI;

public class MinerCard : MonoBehaviour
{
    [SerializeField] private MinerCardData _minerCardData;

    private void Start()
    {
        GetComponent<Image>().sprite = _minerCardData.CardSprite;
    }
}
