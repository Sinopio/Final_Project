using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRoadScript : MonoBehaviour
{
    private Vector3[] wayPoint;
    private Vector3 currentPos;
    private Quaternion[] rotateAngle;
    private int wayPointIndex;
    [SerializeField]
    private float speed;

    [SerializeField]
    private GameObject[] objects;

    private void Start()
    {
        wayPoint = new Vector3[4];
        rotateAngle = new Quaternion[2];

        wayPoint.SetValue(new Vector3(-27, 4.2f, 81), 0);
        wayPoint.SetValue(new Vector3(-33, 4.2f, -9.2f), 1);
        wayPoint.SetValue(new Vector3(8.6f, 4.2f, -12.3f), 2);
        wayPoint.SetValue(new Vector3(16, 4.2f, -13), 3);

        rotateAngle[0] = Quaternion.Euler(new Vector3(0, 100, 0));
        rotateAngle[1] = Quaternion.Euler(new Vector3(15, 100, 0));
    }

    private void Update()
    {
        followWayPoint();
        rotateCam();
        startGame();
    }

    void followWayPoint()
    {
        currentPos = transform.position;

        if(wayPointIndex < wayPoint.Length)
        {
            transform.position = Vector3.MoveTowards(currentPos, wayPoint[wayPointIndex],
                speed * Time.deltaTime);
        }

        if(Vector3.Distance(wayPoint[wayPointIndex], currentPos) <= 1.0f && wayPointIndex <= 2)
        {
            wayPointIndex++;
        }
    }

    void rotateCam()
    {
        if(wayPointIndex == 2)
        {
            transform.rotation = Quaternion.Slerp(gameObject.transform.rotation,
                rotateAngle[0], 0.03f);
        }

        else if(wayPointIndex == 3)
        {
            transform.rotation = Quaternion.Slerp(gameObject.transform.rotation,
                rotateAngle[1], 0.01f);
        }

    }

    void startGame()
    {
        if (Vector3.Distance(wayPoint[3], currentPos) == 0.0f)
        {
            objects[0].SetActive(true);
            objects[1].SetActive(true);
            objects[2].SetActive(true);
            objects[3].SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
