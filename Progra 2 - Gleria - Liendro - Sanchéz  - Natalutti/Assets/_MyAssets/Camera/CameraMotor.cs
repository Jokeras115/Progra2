using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    private Transform lookAt;
    [SerializeField]
    private float boundX = 0.15f;
    [SerializeField]
    private float boundY = 0.05f;

    private void Awake()
    {
        lookAt = GameObject.Find("Player").transform;
    }
    private void LateUpdate()
    {
        Vector3 delta = Vector3.zero;

        // Chequear que estemos dentro de los limites de X
        float deltaX = lookAt.position.x - transform.position.x;
        if (deltaX > boundX || deltaX < -boundX)
            if (transform.position.x < lookAt.position.x)
                delta.x = deltaX - boundX;
            else
                delta.x = deltaX + boundX;

        // Chequear que estemos dentro de los limites de Y
        float deltaY = lookAt.position.y - transform.position.y;
        if (deltaY > boundY || deltaY < -boundY)
            if (transform.position.y < lookAt.position.y)
                delta.y = deltaY - boundY;
            else
                delta.y = deltaY + boundY;

        // Posicionar la camara
        transform.position += new Vector3(delta.x, delta.y, 0);
    }
}
