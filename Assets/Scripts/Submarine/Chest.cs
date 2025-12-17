using UnityEngine;

public class Chest : MonoBehaviour
{
    public float rotateSpeed = 40f;

    private bool collected = false;

    private void Update()
    {
        // Idle dönüş
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (collected) return;

        if (other.CompareTag("Player"))
        {
            collected = true;

            SubmarineGameController.Instance.CollectChest();

            Destroy(gameObject);
        }
    }
}
