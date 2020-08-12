using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : Levelchanger
{
    [SerializeField] BoyController player;
    static float timer; //world timer

    public override void Start()
    {
        base.Start();

        if (prevscene == -1) //upon first starting game
        {
            timer = 0f;
        }
            if (currentscene == 0 && prevscene > -1)
        {
            player.transform.position = new Vector2(1f, -3f);
            player.lookDirection = new Vector2(0, 1);
        }
        if(currentscene == 1 && prevscene == 0)
        {
            player.transform.position = new Vector2(-4f, -2.9f);
            player.lookDirection = new Vector2(1, 0);
        }
        if(currentscene == 1 && prevscene == 2)
        {
            player.transform.position = new Vector2(3.5f, 0f);
            player.lookDirection = new Vector2(-1, 0);
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;
    }
}