using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabolaScript : MonoBehaviour
{
    [SerializeField]
    private Transform point1;
    [SerializeField]
    private Transform point2;
    [SerializeField]
    private Transform point3;

    [SerializeField]
    private LineRenderer lineRenderer;
    [SerializeField]
    private float vertexCount;
    [SerializeField]
    private float Ypoint;

    private void Start()
    {
        lineRenderer.SetColors(Color.white, Color.white);
        lineRenderer.SetWidth(0.01f, 0.1f);
    }
    private void Update()
    {
        drawParabola();
    }

    void drawParabola()
    {
        point2.transform.position = new Vector3((point1.position.x + point3.position.x)/2, Ypoint, (point1.position.z + point3.position.z)/2);
        var pointlist = new List<Vector3>();

        for(float ratio = 0; ratio<=1; ratio+= 1/vertexCount)
        {
            var tan1 = Vector3.Lerp(point1.position, point2.position, ratio);
            var tan2 = Vector3.Lerp(point2.position, point3.position, ratio);
            var curve = Vector3.Lerp(tan1, tan2, ratio);

            pointlist.Add(curve);
        }

        lineRenderer.positionCount = pointlist.Count;
        lineRenderer.SetPositions(pointlist.ToArray());
    }
}

