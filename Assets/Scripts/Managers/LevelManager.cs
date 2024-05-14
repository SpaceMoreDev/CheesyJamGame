using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static Dictionary<GameObject, bool> spawnables = new Dictionary<GameObject, bool>();
    public int NumberOfCheese = 3;
    void Start()
    {
        int[] indexes = new int[NumberOfCheese];

        for (int i = 0; i < indexes.Length; i++)
        {
            indexes[i] = UnityEngine.Random.Range(0, spawnables.Count);

            while (!indexes.Contains(indexes[i]))
            {
                indexes[i] = UnityEngine.Random.Range(0, spawnables.Count);
            }
            
        }

        List<GameObject> keys = new List<GameObject>(spawnables.Keys);
        int d = 0;
        foreach (var spawn in keys)
        {
            for (int i = 0; i < indexes.Length; i++)
            {
                if (d == indexes[i])
                {
                    spawnables[spawn] = true;
                }
            }
            d++;
            if (spawn.TryGetComponent<IBox>(out IBox box)) { box.Begin(); }
        }

    }

}
