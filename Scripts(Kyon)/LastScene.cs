using UnityEngine;

public class LastScene : MonoBehaviour {
    // スクロールするスピード
    public float speed = 0.1f;
    public float rotationSpeed = 1f;
    Vector3 rotation;

    void Start()
    {
        rotation = new Vector3(0, speed, 0);
    }

    void Update()
    {
        transform.Rotate(rotation * Time.deltaTime * rotationSpeed);
    }
}
