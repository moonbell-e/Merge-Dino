using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField] private int _level;
    [SerializeField] private Sprite _sprite;

    public int Level
    {
        get { return _level; }
        set { _level = value; }
    }
    public Sprite ItemSprite
    {
        get { return _sprite; }
        set { _sprite = value; }
    }

    [SerializeField]
    private GameObject _iconRemove;

    private ItemSpawner _itemSpawner;

    private void Update()
    {
        if (Level == 4)
            _iconRemove.SetActive(true);
    }
    private void Awake()
    {
        _itemSpawner = FindObjectOfType<ItemSpawner>();
        gameObject.GetComponent<Image>().sprite = ItemSprite;
    }

    public void Remove()
    {

        FindObjectOfType<AudioController>().Play("ProgressBarFill");
        _itemSpawner.ProgressBar.fillAmount += 0.2f;
        _itemSpawner.ListsAvailable.Add(gameObject.GetComponent<MergeController>().ParentCell);
        Destroy(gameObject);
    }



}
