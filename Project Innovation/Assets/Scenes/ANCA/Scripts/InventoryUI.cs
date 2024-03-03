using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public GameObject inventoryPrefab;
    public Transform gridContainer;

    private void Start()
    {
        FillInventoryGrid();
    }

    public void FillInventoryGrid()
    {
        foreach(Transform child in gridContainer)
        {
            Destroy(child.gameObject);
        }

        foreach(var seed in inventoryManager.inventory)
        {
            GameObject gridSlot = Instantiate(inventoryPrefab, gridContainer);

            //GameObject seedObject = Instantiate(GetSeedPrefab(seed.Type), inventoryPrefab.transform);
        }
    }

   /* private GameObject GetSeedPrefab(string seedType)
    {
        return Resources.Load<GameObject>("Prefabs/SeedPrefab");
    }*/
}
