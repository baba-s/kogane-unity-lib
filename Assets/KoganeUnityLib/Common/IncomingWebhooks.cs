using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace KoganeUnityLib
{
    [Serializable]
    public sealed class Payload
    {
        public string       channel     ;
        public string       username    ;
        public string       text        ;
        public string       icon_emoji  ;
        public string       icon_url    ;
        public Attachment[] attachments ;
    }

    [Serializable]
    public sealed class Attachment
    {
        public string   fallback    ;
        public string   color       ;
        public string   pretext     ;
        public string   author_name ;
        public string   author_link ;
        public string   author_icon ;
        public string   title       ;
        public string   title_link  ;
        public string   text        ;
        public Field[]  fields      ;
        public string   image_url   ;
        public string   thumb_url   ;
        public string   footer      ;
        public string   footer_icon ;
        public string   ts          ;
		public string[]	mrkdwn_in	;
    }

    [Serializable]
    public sealed class Field
    {
        public string  title;
        public string  value;
        public string @short;
    }

    public static class IncomingWebhooks
    {
        public static IEnumerator SendMessage
		(
            string          url                 ,
            Payload         payload             ,
            Action          onSuccess   = null  ,
            Action<string>  onError     = null
        )
        {
            var form = new WWWForm();
            form.AddField( "payload", JsonUtility.ToJson( payload ) );

            var www = UnityWebRequest.Post( url, form );
            yield return www.SendWebRequest();
            var error = www.error;

            if ( !string.IsNullOrEmpty( error ) )
            {
                if ( onError != null )
                {
                    onError( error );
                }
                yield break;
            }

            if ( onSuccess != null )
            {
                onSuccess();
            }
        }
    }
}