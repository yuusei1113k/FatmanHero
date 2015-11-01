using UnityEngine;
using System.Collections;

public class EnemyHP : MonoBehaviour {

    public GameObject hpBar;

    private Vector3 HProtation;

    private Vector3 HpScale;
    private float hp;

    private GameObject enemy;
    private EnemyA ea;

    private GameObject camera;

	// Use this for initialization
	void Start () {
        enemy = transform.parent.gameObject;
        ea = enemy.GetComponent<EnemyA>();
        hp = ea.getEvil();
        camera = GameObject.Find("Camera");
        print(camera);
    }

    // Update is called once per frame
    void Update () {
        transform.LookAt(camera.transform);
        gameObject.transform.rotation = Quaternion.LookRotation(HProtation);
        if (hp >= 0)
        {
            hp = ea.getEvil();
            HpScale = new Vector3(hp, 1f, hp);
            transform.localScale = HpScale;
        }
        else
        {
			hpBar.SetActive(false);
        }
    }
}
