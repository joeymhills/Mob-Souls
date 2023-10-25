using JetBrains.Annotations;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    void Update()
    {
        if (transform.position != player.position + offset)
        {

            transform.position = player.position + offset;

        }

    }
}
