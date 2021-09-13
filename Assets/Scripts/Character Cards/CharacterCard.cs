using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public abstract class CharacterCard : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private bool _cardPicked;
    private bool _tileDetected;
    private Vector2 _lastMousePosition;
    private Image _imageComponent;
    private RectTransform _rectTransform;
    private GameObject _prefab;
    private CardManager _cardManager;
    [SerializeField] private LayerMask _tileLayer;
    [SerializeField] private CharacterCardData _characterCardData;

    private void Awake()
    {
        _cardManager = FindObjectOfType<CardManager>();
        _imageComponent = GetComponent<Image>();
        _rectTransform = GetComponent<RectTransform>();
    }

    private void OnEnable()
    {
        if(!_imageComponent.enabled)
            _imageComponent.enabled = true;
        
        _rectTransform.anchoredPosition = Vector2.zero;
        _rectTransform.offsetMax = Vector2.zero;
        _rectTransform.offsetMin = Vector2.zero;
    }

    private void OnDisable()
    {
        _cardPicked = false;
        _tileDetected = false;
    }

    private void Start()
    {
        _imageComponent.sprite = _characterCardData.CardSprite;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _lastMousePosition = eventData.position;
        _cardPicked = true;
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
        if (!_tileDetected)
        {
            _rectTransform.DOAnchorPos(Vector2.zero, 0.25f).SetEase(Ease.Linear);
            _cardPicked = false;
        }
        else
        {
            _prefab.GetComponent<IActivated>().Activate();//Let miner go.
            _prefab = null;
            _rectTransform.SetParent(null);
            _cardManager.SpawnCharacterCard(gameObject); //Send this card to cardslist and spawn another card.
            ObjectPool.Instance.ReturnGameObject(gameObject);
        }
    }

    private void FixedUpdate()
    {
        SpawnMiner();
    }
    
    private void SpawnMiner()
    {
        if(!_cardPicked)
            return;
        
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity, _tileLayer))
            {
                if (!_tileDetected)
                {
                    _tileDetected = true;
                    _imageComponent.enabled = false;
                    
                    if (_prefab == null)
                    {
                        _prefab = ObjectPool.Instance.GetObject(_characterCardData.Prefab);//Spawn corresponding prefab here.
                        _prefab.transform.position = hit.transform.position + Vector3.up * hit.transform.localScale.y * 1.5f;
                    }
                    else
                    {
                        _prefab.SetActive(true);
                    }
                }
                else
                {
                    if (_prefab.transform.position != hit.transform.position + Vector3.up * _prefab.transform.localScale.y * 1.5f)
                    {
                        _prefab.transform.position = hit.transform.position + Vector3.up * _prefab.transform.localScale.y * 1.5f;// Move miner position over the starting tile.
                    } 
                }
            }
            else
            {
                if (_tileDetected) //Set card active and deactivate miner here.
                {
                    _tileDetected = false;
                    _imageComponent.enabled = true;
                    
                    if (_prefab != null)
                    {
                        _prefab.SetActive(false);
                    }
                }
            }
        }
    }
}
