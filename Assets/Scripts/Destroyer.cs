using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public float lifetime;

    private void start()
    {
        Destroy(gameObject, lifetime);
    }

}
