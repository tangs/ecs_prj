using Components;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace Systems
{
    
    [UpdateInGroup(typeof(FixedStepSimulationSystemGroup))]
    public partial class MonsterSpawningSystem : SystemBase
    {
        private EndFixedStepSimulationEntityCommandBufferSystem ecbSystem;

        protected override void OnCreate()
        {
            ecbSystem = World.GetExistingSystem<EndFixedStepSimulationEntityCommandBufferSystem>();
        }

        protected override void OnUpdate()
        {
            var config = GetSingleton<MonsterSpawningComponent>();
            Debug.Log($"cnt:{config.MonsterCount}, {config.MonsterPrefab == Entity.Null}");
            // var commandBuffer = m_EntityCommandBufferSystem.CreateCommandBuffer().AsParallelWriter();
            var ecb = ecbSystem.CreateCommandBuffer();
            
            var vehicles = CollectionHelper.CreateNativeArray<Entity>(config.MonsterCount, Allocator.Temp);
            ecb.Instantiate(config.MonsterPrefab, vehicles);
            
            var rand = Unity.Mathematics.Random.CreateFromIndex(223);
            foreach (var entity in vehicles)
            {
                var pos = new float3((float)rand.NextDouble() * 14 - 7f, (float)rand.NextDouble() * 7.2f - 3.6f, 0f);
                ecb.SetComponent(entity, new Translation { Value = pos });
            }
            // ecbSystem.AddJobHandleForProducer(Dependency);
            Enabled = false;
            vehicles.Dispose();
        }
    }
}