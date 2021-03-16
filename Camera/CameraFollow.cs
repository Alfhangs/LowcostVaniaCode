using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float margenX = 1f;
    public float margenY = 1f;
    public float xSmooth = 8f;
    public float ySmooth = 8f;
    public Vector2 maxXAndY;
    public Vector2 minXAndY;
    public Transform player;


    bool CheckXMargin()
    {
        //Devuelve el valor de la distancia de la camara al jugador en el eje X
        return Mathf.Abs(transform.position.x - player.position.x) > margenX;
    }
    bool CheckYMargin()
    {
        //Devuelve el valor de la distancia de la camara al jugador en el eje Y
        return Mathf.Abs(transform.position.y - player.position.y) > margenY;
    }
    private void FixedUpdate()
    {
        TrackPlayer();
    }
    void TrackPlayer()
    {
        float targetX = transform.position.x;
        float targetY = transform.position.y;

        if (CheckXMargin())
        {
            //Si el jugador lo movemos por el eje X, usamos el Lerp para calcular la posicion de la camara con el jugador
            targetX = Mathf.Lerp(transform.position.x, player.position.x, xSmooth * Time.deltaTime);
        }
        if (CheckYMargin())
        {
            //Si el jugador lo movemos por el eje Y, usamos el Lerp para calcular la posicion de la camara con el jugador
            targetY = Mathf.Lerp(transform.position.y, player.position.y, ySmooth * Time.deltaTime);
        }
        targetX = Mathf.Clamp(targetX, minXAndY.x, maxXAndY.x);
        targetY = Mathf.Clamp(targetY, minXAndY.y, maxXAndY.y);

        transform.position = new Vector3(targetX, targetY, transform.position.z);
    }
}
