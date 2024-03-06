using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public int water;
    public int elixir;

    public void AddElixir(int amount)
    {
        elixir += amount;
    }

    public void UseElixir(int amount)
    {
        if (elixir >= amount)
        {
            elixir -= amount;
        }

    }

    public int GetElixirCount()
    {
        return elixir;
    }
}
