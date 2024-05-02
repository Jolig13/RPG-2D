using UnityEngine;

public class LightRotation : MonoBehaviour
{
    [SerializeField ]private float speedRotate = 15f;
    void Update()
    {
        transform.Rotate(new Vector3(0,0,-speedRotate*Time.deltaTime));
    }
}
