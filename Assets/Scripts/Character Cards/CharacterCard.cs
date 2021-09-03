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
    private GameObject _minerClone;
    private CardManager _cardManager;
    [SerializeField] private LayerMask _tileLayer;
    [SerializeField] protected CharacterCardData characterCardData;

    private void Awake()
    {
        _cardManager = FindObjectOfType<CardManager>();
        _imageComponent = GetComponent<Image>();
        _rectTransform = GetComponent<RectTransform>();
    }

    private void OnEnable()
    {
        _imageComponent.enabled = true;
        _imageComponent.sprite = characterCardData.CardSprite;
        _rectTransform.DOAnchorPos(Vector2.zero, 0);
        _rectTransform.offsetMax = Vector2.zero;
        _rectTransform.offsetMin = Vector2.zero;
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
            _minerClone.GetComponent<IActivated>().Activate();//Let miner go.
            _minerClone = null;
            _rectTransform.SetParent(null);
            _cardManager.SpawnCharacterCard(gameObject); //Send this card to cardslist and spawn another card.
            gameObject.SetActive(false);// NEEDS OBJECT POOLING!
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
                    
                    if (_minerClone == null)
                    {
                        _minerClone = characterCardData.SpawnMiner();//Spawn corresponding miner here.
                        _minerClone.transform.position = hit.transform.position + Vector3.up * hit.transform.localScale.y * 1.5f;
                    }
                    else
                    {
                        _minerClone.SetActive(true);
                    }
                }
                else
                {
                    if (_minerClone.transform.position != hit.transform.position + Vector3.up * _minerClone.transform.localScale.y * 1.5f)
                    {
                        _minerClone.transform.position = hit.transform.position + Vector3.up * _minerClone.transform.localScale.y * 1.5f;// Move miner position over the starting tile.
                    } 
                }
            }
            else
            {
                if (_tileDetected) //Set card active and deactivate miner here.
                {
                    _tileDetected = false;
                    _imageComponent.enabled = true;
                    
                    if (_minerClone != null)
                    {
                        _minerClone.SetActive(false);
                    }
                }
            }
        }
    }
}
