using Unity.Entities;

namespace Components
{
    [GenerateAuthoringComponent]
    public struct FrameAnimComponent : IComponentData
    {
        public int AnimIndex;
        public float FrameSec;
        public int Frame;
        public float Secs;
    }
}
