using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public static class CardHandler
{
    public static async Task<Texture2D> GetRemoteRandomTexture()
    {
        using var www = UnityWebRequestTexture.GetTexture("https://picsum.photos/170/155");
        
        var asyncOp = www.SendWebRequest();
        while( asyncOp.isDone == false ) await Task.Delay( 1000/30 );

        if (www.result == UnityWebRequest.Result.Success) return DownloadHandlerTexture.GetContent(www);
        
        Debug.LogError( $"{www.error}, URL:{www.url}" );
        
        return null;
    }

    public static int GetRandomValue(int min = -2, int max = 9) => Random.Range(min, max);
    
    public static int GetRandomIndex() => Random.Range(0, 2);
}
