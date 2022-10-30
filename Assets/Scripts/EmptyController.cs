using UnityEngine;

public class EmptyController : MonoBehaviour
{
    void OnMouseDown()
    {
        GlobalEvents.SelectEmptyEvent.Invoke(this.name);
    }
}
