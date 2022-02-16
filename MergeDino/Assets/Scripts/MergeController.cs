using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MergeController : MonoBehaviour
{
    private Vector3 _currentPrefabPosition;
    private Vector3 _newPrefabPosition;


    private GameObject _currentRaycastObject;

    private ItemSpawner _itemSpawner;


    private RaycastHit2D _raycastHit2D;

    private Camera _mainCam;

    private Item _item;

    [SerializeField]  private GameObject _parentCell;

    public GameObject ParentCell
    {
        get { return _parentCell; }
        set { _parentCell = value; }
    }

    public List<GameObject> _webItems;


    [SerializeField] private LayerMask _layer;


    [SerializeField] private List<ItemData> _itemSettings;

    private void Awake()
    {
        _mainCam = Camera.main;
        _item = GetComponent<Item>();
        _itemSpawner = FindObjectOfType<ItemSpawner>();
        _webItems.AddRange(GameObject.FindGameObjectsWithTag("WebItem"));
    }



    private void OnMouseDown()
    {
        _currentPrefabPosition = transform.position;
        gameObject.layer = 0;
    }

    private void OnMouseDrag()
    {
        transform.position = new Vector3(_mainCam.ScreenToWorldPoint(Input.mousePosition).x, _mainCam.ScreenToWorldPoint(Input.mousePosition).y, transform.position.z);
    }

    private void OnMouseUp()
    {
        _raycastHit2D = Physics2D.Raycast(_mainCam.ScreenToWorldPoint(Input.mousePosition), _mainCam.transform.forward, 10f, _layer);
        if (_raycastHit2D.collider != null)
        {
            _newPrefabPosition = _raycastHit2D.transform.position;
            _currentRaycastObject = _raycastHit2D.collider.gameObject;

            if (_currentRaycastObject.layer == 7 && _currentRaycastObject.GetComponent<Item>().Level == _item.Level && _currentRaycastObject.GetComponent<Item>().Level != 4)
            {
                for (int i = 0; i < _webItems.Count; i++)
                {
                    if (_currentRaycastObject == _webItems[i]) 
                        _webItems[i].transform.SetParent(_itemSpawner.FieldParent);
                }
                _currentRaycastObject.GetComponent<Item>().Level++;
                _currentRaycastObject.GetComponent<Image>().sprite = _itemSettings[_currentRaycastObject.GetComponent<Item>().Level - 1].ItemSprite;
                _itemSpawner.ListsAvailable.Add(_parentCell);
                FindObjectOfType<AudioController>().Play("BonesMerge");
                _parentCell.layer = 6;
                Destroy(gameObject);
            }

            else
            {
                NotMergeObject();
            }
        }
        else
        {
            NotMergeObject();
        }
    }
    private void NotMergeObject()
    {
        transform.position = _currentPrefabPosition;
        gameObject.layer = 7;
    }


}
