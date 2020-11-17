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
    private float delayTime;
    private float randX = 0;
    private float randZ = 0;
    private Vector3 playerPosition;



    private void Start()
    {
        searchTime = 2f;
        delayTime = 2f;
        zombieState = zombie.GetComponent<ZombieState>();
    }

    private void FixedUpdate()
    {
        searchTime += Time.deltaTime;
        delayTime += Time.deltaTime;
        movePosition();
    }

    void movePosition()
    {
        switch (zombieState.zombieState)
        {
            case 1: // inRay
                gameObject.transform.position = player.transform.position;
                break;
            case 3: // inSector
                if(delayTime >= 2f)
                {
                    followPlayer();
                    delayTime = 0f;
                }
                gameObject.transform.position = playerPosition;
                break;
            case 4: // inSoundSector
                if (searchTime >= 2f)
                {
                    setRandPosition();
                    searchTime = 0f;
                }
                gameObject.transform.position = new Vector3(player.transform.position.x + randX, player.transform.position.y, player.transform.position.z + randZ);
                break;
            case 6:
                gameObject.transform.position = GeneratorScript.Instance.objTrasnform.position;
                break;
        }
    }

    void setRandPosition()
    {
       randX = Random.Range(-5, 5);
       randZ = Random.Range(-5, 5);
    }

    void followPlayer()
    {
        //Debug.Log("setposition");
        playerPosition = player.transform.position;
    }

    IEnumerator setPositionDelay()
    {
        Debug.Log("time" + Time.time);
        yield return new WaitForSeconds(2.0f);
    }
    /*
    코루틴등의 방법을 통해 플레이어의 좌표를 1회 받아오고, 일정시간이 지나면 다시 받아오는 식으로 구현
    */
}
