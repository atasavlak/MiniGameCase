using UnityEngine;

public class UIChestModelRotator : MonoBehaviour
{
    public float rotateSpeed = 30f;

    private void Update()
    {
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime, Space.World);
    }
}
