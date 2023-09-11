using System;
using UnityEngine;

public abstract class ChangementEntier : MonoBehaviour
{
    public virtual event Action<int> OnChangementEntier;
}
