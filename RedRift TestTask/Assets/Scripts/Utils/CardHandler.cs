using System.Threading.Tasks;
using UnityEngine;

namespace Utils
{
    public static class CardHandler
    {
        public static int GetRandomAmountInitialCards() => Random.Range(4, 7);
    
        public static int GetRandomFeatureValue(int min = -2, int max = 10) => Random.Range(min, max);
    
        public static int GetRandomFeatureIndex() => Random.Range(0, 3);

        public static async Task<Sprite> GetRandomArt()
        {
            var texture = await TaskHandler.GetRemoteRandomTexture();
            var sprite = Sprite.Create(texture, 
                new Rect(0f, 0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100f);
            return sprite;
        }
    }
}
