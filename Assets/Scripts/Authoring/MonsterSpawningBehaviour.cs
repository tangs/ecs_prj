using System.Collections.Generic;
using Components;
using Unity.Entities;
using UnityEngine;

namespace Authoring
{
    public class MonsterSpawningBehaviour : MonoBehaviour, IConvertGameObjectToEntity, IDeclareReferencedPrefabs
    {
        public GameObject monsterPrefab;
        public int monsterCount;
        
        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            dstManager.AddComponentData(entity, new MonsterSpawningComponent
            {
                MonsterPrefab = conversionSystem.GetPrimaryEntity(monsterPrefab),
                MonsterCount = monsterCount,
            });
        }

        public void DeclareReferencedPrefabs(List<GameObject> referencedPrefabs)
        {
            referencedPrefabs.Add(monsterPrefab);
        }
    }
}