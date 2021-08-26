using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MinerCard : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private bool _canDropMiner;
    private Vector2 _initialPosition;
    private Vector2 _lastMousePosition;
    private Image _imageComponent;
    private RectTransform _rectTransform;
    [SerializeField] private MinerCardData _minerCardData;

    private void Start()
    {
        _imageComponent = GetComponent<Image>();
        _imageComponent.sprite = _minerCardData.CardSprite;
        _rectTransform = GetComponent<RectTransform>();
        _initialPosition = _rectTransform.anchoredPosition;
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        _lastMousePosition = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 currentMousePosition = eventData.position;
        Vector2 diff = currentMousePosition - _lastMousePosition;
        Vector3 newPosition = _rectTransform.position +  new Vector3(diff.x, diff.y, transform.position.z);

        _rectTransform.position = newPosition;
        
        _lastMousePosition = currentMousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
       _rectTransform.DOAnchorPos(_initialPosition, 0.25f).SetEase(Ease.Linear);
    }
}
