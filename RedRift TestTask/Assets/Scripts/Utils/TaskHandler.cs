using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace Utils
{
    public static class TaskHandler
    {
        private const string URL = "https://picsum.photos/170/155";

        public static async Task<Texture2D> GetRemoteRandomTexture()
        {
            using var www = UnityWebRequestTexture.GetTexture(URL);
        
            var asyncOp = www.SendWebRequest();
            while( asyncOp.isDone == false ) await Task.Delay( 1000/30 );

            if (www.result == UnityWebRequest.Result.Success) return DownloadHandlerTexture.GetContent(www);
        
            Debug.LogError( $"{www.error}, URL:{www.url}");
        
            return null;
        }
    }
}
