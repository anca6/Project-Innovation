using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public Transform gridContainer;

    public GameObject textPrefab;


    private Dictionary<string, GameObject> seedPrefabs = new Dictionary<string, GameObject>();
    private void Start()
    {
        LoadSeedPrefabs();

        FillInventoryGrid();
    }

    private void LoadSeedPrefabs()
    {
        seedPrefabs["SeedType1"] = Resources.Load<GameObject>("Prefabs/SeedType1");
        seedPrefabs["SeedType2"] = Resources.Load<GameObject>("Prefabs/SeedType2");
    }


    public void FillInventoryGrid()
    {
        foreach(Transform child in gridContainer)
        {
            Destroy(child.gameObject);
        }

        foreach(var seed in inventoryManager.inventory)
        {
            for(int i= 0; i < seed.Quantity; i++)
            {
                GameObject seedObject = Instantiate(GetSeedPrefab(seed.Type), gridContainer);
            }

                Text textComponent = textPrefab.GetComponent<Text>(); ;
                textComponent.text = $"{seed.Quantity}";
        }
    }

    private GameObject GetSeedPrefab(string seedType)
    {
        if(seedPrefabs.TryGetValue(seedType, out GameObject prefab))
        {
            return prefab;
        }
        else
        {
            Debug.Log("seed prefab not found for type: " + seedType);
            return null;
        }
    }

    private void OnEnable()
    {
        InventoryManager.onInventoryChanged += FillInventoryGrid;
    }

    private void OnDisable()
    {
        InventoryManager.onInventoryChanged -= FillInventoryGrid;   
    }
}
