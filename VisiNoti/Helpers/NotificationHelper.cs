using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using VisiNoti.Models;

namespace VisiNoti.Helpers
{
    public class NotificationHelper
    {
        public static void SendPushNotification(Notification notification)
        {
            try
            {
                string serverKey = "AAAAoYGiVI0:APA91bFcJ_p25mtqQtq2z0bmZlDOQbluD50eRw-WjY-z1PpMIMKuFemC_ebyupK_RDR5OC1qH2NpISWt5NG3CA03iSYhyakrlBDpc0VZUIobZMqx5SdB1-xEfEgl05thIqRsrhDGBP3w";
                string senderId = "693664633997";
                WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                tRequest.Method = "post";
                tRequest.ContentType = "application/json";
                var data = new
                {
                    to = notification.FCMToken,
                    notification = new
                    {
                        body = notification.Body,
                        title = notification.Title,
                        sound = notification.Sound
                    }
                };

                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(data);
                Byte[] byteArray = Encoding.UTF8.GetBytes(json);
                tRequest.Headers.Add(string.Format("Authorization: key={0}", serverKey));
                tRequest.Headers.Add(string.Format("Sender: id={0}", senderId));
                tRequest.ContentLength = byteArray.Length;

                using (Stream dataStream = tRequest.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    using (WebResponse tResponse = tRequest.GetResponse())
                    {
                        using (Stream dataStreamResponse = tResponse.GetResponseStream())
                        {
                            using (StreamReader tReader = new StreamReader(dataStreamResponse))
                            {
                                String sResponseFromServer = tReader.ReadToEnd();
                                string str = sResponseFromServer;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }
    }
}