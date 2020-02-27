using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Rendering;
using Unity.Transforms;
using Random = UnityEngine.Random;

public class Testing : MonoBehaviour
{

    [SerializeField] private Mesh myMesh;
    [SerializeField] private Material myMaterial;
    
    // Start is called before the first frame update
    void Start()
    {
        EntityManager entityManager = World.Active.EntityManager;
        EntityArchetype entityArchetype = entityManager.CreateArchetype(
            typeof(LevelComponent),
            typeof(MoveSpeedComponent),
            
            typeof(Translation),
            typeof(RenderMesh),
            typeof(LocalToWorld)
            );

        NativeArray<Entity> entityArray = new NativeArray<Entity>(100, Allocator.Temp);
        entityManager.CreateEntity(entityArchetype,entityArray);

        for (int i = 0; i < entityArray.Length; i++)
        {
            
            Entity entity = entityArray[i];
            entityManager.SetComponentData(entity, new LevelComponent{ level = Random.Range(10,20)});
            entityManager.SetComponentData(entity, new MoveSpeedComponent{ moveSpeedX = Random.Range(3,5), moveSpeedZ = Random.Range(3,5)});
            entityManager.SetComponentData(entity, new Translation{ Value = 
                new float3(Random.Range(-20,20), 0, Random.Range(-50,10))});
            entityManager.SetSharedComponentData(entity, new RenderMesh
            {
                mesh = myMesh,
                material = myMaterial,
            });
        }

        entityArray.Dispose();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
