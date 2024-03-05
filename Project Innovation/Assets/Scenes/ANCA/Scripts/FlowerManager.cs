using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerManager : MonoBehaviour
{
    [SerializeField]
    private List<Flower> flowerList = new List<Flower>();

    public void GrowFLower(Flower flower)
    {
        flower.Grow();
        /*journalManager.updateEntry();

        if(FlowerManager.currentStage == " ")
        {
            gameOject.setActive(true);
        }*/
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
}
