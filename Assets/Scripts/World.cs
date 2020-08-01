using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : Levelchanger
{
    [SerializeField] BoyController player;

    public override void Start()
    {
        base.Start();

        if (currentscene == 0 && prevscene > -1)
        {
            player.transform.position = new Vector2(1f, -3f);
            player.lookDirection = new Vector2(0, 1);
        }
        if(currentscene == 1 && prevscene == 0)
        {
            player.transform.position = new Vector2(-3.5f, 0f);
            player.lookDirection = new Vector2(1, 0);
        }
    }
}