using System;
using UnityEngine;

public abstract class ChangeurValeur : MonoBehaviour
{
    public virtual event Action<object[]> OnChangementValeur;
    public abstract object[] GetValeurs();
}
