using Cache;
using Components;
using Unity.Burst;
using Unity.Entities;
using UnityEngine;

namespace Systems
{
    public partial class SetSpriteSystem : SystemBase
    {
        private static readonly SpritesCache Instance = SpritesCache.Instance();
        
        protected override void OnUpdate()
        {
            Entities
                .WithAll<FrameAnimComponent>()
                .ForEach((in FrameAnimComponent data, in SpriteRenderer spriteRenderer) =>
                {
                    var index = data.AnimIndex;
                    var framesCnt = Instance.GetSpritesCount(index);
                    if (framesCnt == 0) return;
                    var frame = data.Frame % framesCnt;
                    spriteRenderer.sprite = Instance.GetSprites(index)[frame];
                }).WithoutBurst().Run();
        }
    }
    
    
    [BurstCompile]
    public partial struct FrameAnimSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
        }
    
        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {
            
        }
    
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var deltaTime = state.Time.DeltaTime;
            state.Entities
                .WithAll<FrameAnimComponent>()
                .ForEach((ref FrameAnimComponent anim) =>
            {
                anim.Secs += deltaTime;
                var fs = anim.FrameSec;
                while (anim.Secs >= fs)
                {
                    // data.frame = (data.frame + 1) % data.frameCnt;
                    ++anim.Frame;
                    anim.Secs -= fs;
                }
            }).ScheduleParallel();
        }
    }
}