using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public int water;
    public int elixir;

   public void AddElixir(int amount)
    {
        elixir += amount;
        Debug.Log("elixir amount: " +  elixir); 
    }

    public void UseElixir(int amount)
    {
        if(elixir >= amount)
        {
            elixir -= amount;
        }
        else
        {
            Debug.Log("not enough elixir");
        }
    }
}
