using UnityEngine;
using System;

public class GlobalEvents : MonoBehaviour
{
    public static Action SelectEvent;

    public static Action<string> SelectEmptyEvent;

    public static Action GameOverCompare;
}
