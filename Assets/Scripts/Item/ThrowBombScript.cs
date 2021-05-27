using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBombScript : MonoBehaviour
{
    SetBombScript setBombScript;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject effect;
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private GameObject gPosition;
    [SerializeField]
    private float angle;
    private float gravity = 9.8f;
    [SerializeField]
    private Transform Obj;
    [SerializeField]
    private GameObject parabola;
    [SerializeField]
    private GameObject targetSphere;

    [SerializeField]
    private GameObject grenadeObj;

    private Transform myTransform;
    private float elapse_time;
    private float flightDuration;
    private float targetDistance;
    private float ObjVelocity;
    private float Vx;
    private float Vy;
    [SerializeField]
    private bool isthrow;

    private void Awake()
    {
        myTransform = transform;
    }

    private void OnEnable()
    {
        elapse_time = 0;
        targetDistance = 0;
    }

    private void Start()
    {
        setBombScript = player.GetComponent<SetBombScript>();
    }

    private void Update()
    {
        throwBomb();
        setEffect();
        setThrowPosition();
        drawParabola();
    }

    void throwBomb()
    {
        if (PlayerState.Instance.invenNum == 10 && Input.GetMouseButtonUp(0) && PlayerState.Instance.grenadeNum > 0)
        {
            isthrow = true;

            PlayerState.Instance.grenadeNum--;
            grenadeObj.SetActive(true);
            Obj.position = myTransform.position + new Vector3(0, 0.0f, 0);

            targetDistance = Vector3.Distance(Obj.position, target.transform.position);

            ObjVelocity = targetDistance / (Mathf.Sin(2 * angle * Mathf.Deg2Rad) / gravity);

            Vx = Mathf.Sqrt(ObjVelocity) * Mathf.Cos(angle * Mathf.Deg2Rad);
            Vy = Mathf.Sqrt(ObjVelocity) * Mathf.Sin(angle * Mathf.Deg2Rad);

            flightDuration = targetDistance / Vx;

            Obj.rotation = Quaternion.LookRotation(target.transform.position - Obj.position);
            target.transform.position = gPosition.transform.position;
        }

        if (elapse_time <= flightDuration && isthrow)
        {
            Obj.Translate(0, (Vy - (gravity * elapse_time)) * Time.deltaTime, Vx * Time.deltaTime);

            elapse_time += Time.deltaTime;
        }
    }

    void setEffect()
    {
        if (elapse_time > flightDuration && isthrow)
        {
            isthrow = false;
            grenadeObj.SetActive(false);
            Instantiate(effect, gameObject.transform.position, Quaternion.identity);
            setBombScript.isSet = false;
            gameObject.SetActive(false);
        }
    }

    void setThrowPosition()
    {
        if (PlayerState.Instance.invenNum == 10 && Input.GetMouseButton(0))
        {
            target.transform.Translate(Vector3.forward * Time.deltaTime*10);
        }
        if (PlayerState.Instance.invenNum != 10)
        {
            target.transform.position = gPosition.transform.position;
        }
    }

    void drawParabola()
    {
        if (PlayerState.Instance.invenNum == 10 && Input.GetMouseButton(0) && PlayerState.Instance.grenadeNum > 0)
        {
            parabola.SetActive(true);
            targetSphere.SetActive(true);
        }
        else if(PlayerState.Instance.invenNum != 10 || !Input.GetMouseButton(0) || PlayerState.Instance.grenadeNum <= 0)
        {
            parabola.SetActive(false);
            targetSphere.SetActive(false);
        }
        
    }
}
