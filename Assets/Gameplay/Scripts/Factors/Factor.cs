using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factor : MonoBehaviour
{
    public Factor raw;
    public int affect_order;
    public int effect_order;
    public virtual void Affect(Factor factor, bool removed)
    {

    }
    public virtual void Effect()
    {

    }
}
