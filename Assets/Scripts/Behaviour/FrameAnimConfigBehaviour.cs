using System;
using Cache;
using UnityEngine;

namespace Behaviour
{
    public class FrameAnimConfigBehaviour : MonoBehaviour
    {
        public int animIndex;
        public Sprite[] sprites;

        public void Start()
        {
            SpritesCache.Instance().SetSprites(animIndex, sprites);
        }
    }
}