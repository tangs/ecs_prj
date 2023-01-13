using System.Collections.Generic;
using Cache;
using Components;
using Unity.Entities;
using UnityEngine;

namespace Authoring
{
    [AddComponentMenu("FrameAnim")]
    [ConverterVersion("tangs", 1)]
    public class FrameAnimBehaviour : MonoBehaviour, IConvertGameObjectToEntity
    {
        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            dstManager.AddComponentData(entity, new FrameAnimComponent()
            {
                AnimIndex = 0,
                FrameSec = 0.1f,
                Frame = 0,
                Secs = 0f,
            });
        }
    }
}
