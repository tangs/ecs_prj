using Unity.Entities;

namespace Components
{
    public struct MonsterSpawningComponent : IComponentData
    {
        public Entity MonsterPrefab;
        public int MonsterCount;
    }
}