using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Factor : MonoBehaviour
{
    public Factor raw;
    public int affect_order;
    public int effect_order;
    protected virtual void Affect(Factor factor, bool removed)
    {

    }
    protected virtual void Effect()
    {

    }
    public class Target<T>
    {
        public static implicit operator T(Target<T> x) { return x.value; }
        T value;
        public bool Set(T new_value)
        {
            if (options.Contains(new_value))
            {
                value = new_value;
                return true;
            }

            return false;
        }
        public readonly T[] options;
        public Target(List<T> options)
        {
            new Target<T>(options.ToArray());
        }
        public Target(T[] options)
        {
            if (options.Length == 0) throw new System.Exception("Tried to initialize target without options.");
            value = options.First();
            this.options = options;
        }
    }

    public struct Container
    {
        List<Factor> factors;

        public void Add(Factor factor)
        {
            List<Factor> affectors = factors.OrderBy(x => x.affect_order).ToList();
            foreach (Factor affector in affectors)
            {
                affector.Affect(factor, false);
                factor.Affect(affector, false);
            }

            factors.Add(factor);
        }

        public void Remove(Factor factor)
        {
            if (factors.Contains(factor)) factors.Remove(factor);
        }

        public void ApplyEffects()
        {
            List<Factor> effectors = factors.OrderBy(x => x.effect_order).ToList();
            foreach (Factor effector in effectors)
            {
                effector.Effect();
            }
        }
    }
}
