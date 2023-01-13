using System.Collections.Generic;
using UnityEngine;

namespace Cache
{
    public class SpritesCache
    {
        private static SpritesCache _cache;
        
        private Dictionary<int, Sprite[]> _sprites = new();

        public static SpritesCache Instance()
        {
            return _cache = _cache ?? new SpritesCache();
        }

        public Sprite[] GetSprites(int index)
        {
            return _sprites[index];
        }
        
        public int GetSpritesCount(int index)
        {
            if (_sprites.ContainsKey(index)) return _sprites[index].Length;
            return 0;
        }

        public void SetSprites(int index, Sprite[] sprites)
        {
            _sprites[index] = sprites;
        }

        public void Clear()
        {
            _sprites.Clear();
        }
    }
}