using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    protected virtual void OnSpawn()
    {

    }

    public virtual Transform SpawnPos()
    {
        return null;
    }
}
