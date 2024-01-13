using UnityEngine;

public class BoundsSetter : MonoBehaviour
{
    [SerializeField]
    private bool Upper;
    void Awake ()
    {
        gameObject.transform.localPosition = new Vector3(0, 1018.25f * (Upper ? 1 : -1) , 0);
        Debug.Log(1018.25f * (Upper ? 1 : -1));
    }
}
