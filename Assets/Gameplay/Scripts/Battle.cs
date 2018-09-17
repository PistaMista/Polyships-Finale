using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{
    public Player player;
    public Factors factors;
    public List<Factors> history;

    public struct Factors
    {
        List<Factor> factors;

        public bool Add(Factor factor)
        {

        }

        public void Remove(Factor factor)
        {
            if (factors.Contains(factor)) factors.Remove(factor);
        }

    }

    public static Battle main;
}
