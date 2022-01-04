using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public static class CardHandler
{
    public static async Task<Texture2D> GetRemoteTexture()
    {
        using var www = UnityWebRequestTexture.GetTexture("https://picsum.photos/170/155");
        
        var asyncOp = www.SendWebRequest();
        while( asyncOp.isDone == false ) await Task.Delay( 1000/30 );

        if (!www.isNetworkError && !www.isHttpError) return DownloadHandlerTexture.GetContent(www);
        
        Debug.Log( $"{www.error}, URL:{www.url}" );
        
        return null;
    }
}
