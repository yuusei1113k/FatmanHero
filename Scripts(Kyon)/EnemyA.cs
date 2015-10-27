using UnityEngine;
using System.Collections;

public class EnemyA : MonoBehaviour {
    public Transform player;
    public float speed = 10;
    private string[] state = new string[2] {"wonder", "attack"};
    private string enemyState;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemyState = state[0];
        print("EnemyState: " + enemyState);
    }

    // Update is called once per frame
    void Update()
    {
        switch (enemyState)
        {
            case "wonder":
                wonder();
                break;
            case "attack":
                break;

        }
    }

    public void wonder()
    {
        Vector3 playerPos = player.position; //プレーヤーの位置
        Vector3 direction = playerPos - transform.position; //方向
        direction = direction.normalized; //単位化（距離要素を取り除く
        transform.position = transform.position + (direction * speed * Time.deltaTime);
        transform.LookAt(player);//プレーヤーの方を向く
    }

    public void attack()
    {
        this.transform.position = new Vector3(0, 5, 0);
    }

    private int i = 0;
    public void switchState()
    {
        if(i == 0)
        {
            i++;
            enemyState = state[i];
        }
        else
        {
            i = 0;
            enemyState = state[i];
        }
    }
}
