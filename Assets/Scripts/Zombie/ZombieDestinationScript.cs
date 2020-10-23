using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDestinationScript : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject zombie;
    private ZombieState zombieState;

    [SerializeField]
    private float searchTime;

    private void Start()
    {
        zombieState = zombie.GetComponent<ZombieState>();
    }

    private void Update()
    {
        searchTime += Time.deltaTime;
        movePosition();
    }

    void movePosition()
    {
        switch (zombieState.zombieState)
        {
            case 1: // inRay
                followPlayer();
                break;
            case 3: // inSector
                followPlayer();
                break;
            case 4: // inSoundSector
                if (searchTime >= 5f)
                {
                    setPosition();
                    searchTime = 0f;
                }
                break;
        }
    }

    void setPosition()
    {
        float randX = Random.Range(-1, 1);
        float randZ = Random.Range(-1, 1);
        gameObject.transform.position = new Vector3(player.transform.position.x + randX, 0f, player.transform.position.z + randZ);
    }

    void followPlayer()
    {
        gameObject.transform.position = player.transform.position;
    }
}
