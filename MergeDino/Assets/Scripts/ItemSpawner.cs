using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefabToSpawn;

    private GameObject _cellToSpawnOn;


    [SerializeField]
    private Image _progressBar;

    public Image ProgressBar
    {
        get { return _progressBar;  }
        set { }
    }

    [SerializeField] private List<GameObject> _listsAvailable;

    public List<GameObject> ListsAvailable
    {
        get { return _listsAvailable;  }
        set { _listsAvailable = value; }
    }

    [SerializeField] private ItemData _itemToSpawn;

    [SerializeField] private Transform _fieldParent;

    [SerializeField] private GameObject _successAnimator;

    public Transform FieldParent
    {
        get { return _fieldParent; }
        protected set { }
    }

    private void Start()
    {
        _listsAvailable = new List<GameObject>();
        _listsAvailable.AddRange(GameObject.FindGameObjectsWithTag("Cell"));
    }

    private void Update()
    {
        if (_progressBar.fillAmount == 1)
        {
            _successAnimator.SetActive(true);
            _successAnimator.GetComponent<Animator>().Play("SuccessEndAnim");
        }
            
    }

    public void AddItem()
    {
        FindObjectOfType<AudioController>().Play("ChestOpening");
        if (_listsAvailable.Count != 0)
        {
            _prefabToSpawn.GetComponent<Item>().Level = _itemToSpawn.Level;
            _prefabToSpawn.GetComponent<Item>().ItemSprite = _itemToSpawn.ItemSprite;

            _cellToSpawnOn = _listsAvailable[Random.Range(0, _listsAvailable.Count)];
            _prefabToSpawn.GetComponent<MergeController>().ParentCell = _cellToSpawnOn;
            Instantiate(_prefabToSpawn, new Vector3(_cellToSpawnOn.transform.position.x, _cellToSpawnOn.transform.position.y, _cellToSpawnOn.transform.position.z - 0.1f), _cellToSpawnOn.transform.rotation, _fieldParent);
            _listsAvailable.Remove(_cellToSpawnOn);
            _cellToSpawnOn.layer = 0;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
