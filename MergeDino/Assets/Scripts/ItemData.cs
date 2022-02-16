using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Standard Item", fileName = "New Item")]
public class ItemData : ScriptableObject
{

    [SerializeField] private Sprite _itemSprite;
    public Sprite ItemSprite
    {
        get { return _itemSprite;  }
        set { }
    }

    [SerializeField] private int _level;
    public int Level
    {
        get { return _level;  }
        set { }
    }

}
