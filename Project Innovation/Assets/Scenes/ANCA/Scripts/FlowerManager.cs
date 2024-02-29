using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerManager : MonoBehaviour
{
    [SerializeField]
    private List<Flower> flowerList = new List<Flower>();

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    public void AddFlower(Flower flower)
    {
        flowerList.Add(flower);
    }

    public void RemoveFlower(Flower flower)
    {
        flowerList.Remove(flower);
    }

    public void GrowFLower(Flower flower)
    {
        flower.Grow();
        flower.UpdateVisualStage();
    }

    public void GrowAllFlowers()
    {
        foreach(Flower flower in flowerList)
        {
            flower.Grow();
            flower.UpdateVisualStage();
        }
    }

    public void OnFlowerInteraction(Flower flower)
    {
        //if(journal.currentStage != null)
        //check flower stage and update journal
    }
}
