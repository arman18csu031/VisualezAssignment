using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LoadTextures : MonoBehaviour
{
    [SerializeField] private List<string> url = new List<string>();
    public List<Sprite> sprite = new List<Sprite>();

    // Start is called before the first frame update
    void Awake()
    {
        for(int i = 0; i <url.Count; i++)
        {
            StartCoroutine(GetTexture(url[i]));
        }
       
    }

    private IEnumerator GetTexture(string url)
    {
        using(UnityWebRequest unityWebRequest = UnityWebRequestTexture.GetTexture(url))
        {
            yield return unityWebRequest.SendWebRequest();
            if(unityWebRequest.isNetworkError || unityWebRequest.isHttpError)
            {
                Debug.Log("error: " + unityWebRequest.error);
            }
            else
            {
                DownloadHandlerTexture downloadHandlerTexture = unityWebRequest.downloadHandler as DownloadHandlerTexture;
                Debug.Log("Received");
                Texture2D tex2D = downloadHandlerTexture.texture;
                Sprite tempSprite = Sprite.Create(tex2D, new Rect(0, 0, 1, 1), new Vector2(.5f, .5f), 100);
                sprite.Add(tempSprite);
            }
        }
    }
}
