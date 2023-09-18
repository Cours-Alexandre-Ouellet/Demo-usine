using System;
using UnityEngine;
using UnityEngine.Events;

public abstract class ChangeurValeur : MonoBehaviour
{
    //public virtual event Action<object[]> OnChangementValeur;
    [SerializeField]
    protected UnityEvent<object[]> OnChangementValeur;

    public abstract object[] GetValeurs();
}
