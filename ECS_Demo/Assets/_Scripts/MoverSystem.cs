using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public class MoverSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref Translation translation, ref MoveSpeedComponent speed) =>
            {
                translation.Value.x += speed.moveSpeedX * Time.DeltaTime;
                if (translation.Value.x > 20f || translation.Value.x < -20)
                    speed.moveSpeedX *= -1;
                
                translation.Value.z += speed.moveSpeedZ * Time.DeltaTime;
                if (translation.Value.z > 10f || translation.Value.z < -50)
                    speed.moveSpeedZ *= -1;

            }
            
            );
    }
}
