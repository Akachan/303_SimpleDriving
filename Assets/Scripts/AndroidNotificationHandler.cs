using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_ANDROID
using Unity.Notifications.Android;
#endif
using System;

public class AndroidNotificationHandler : MonoBehaviour
{
    const string chanelId = "notification channel";
    public void ScheduleNotification( DateTime dateTime)
    {

#if UNITY_ANDROID


        //creación del canal*******************************************************
        AndroidNotificationChannel androidNotificationChannel = new AndroidNotificationChannel
        {
          Id = chanelId,
          Name = "Notification Channel",
          Description = "Por aquí se enviarán las notificaciones",
          Importance = Importance.Default,
        };

        AndroidNotificationCenter.RegisterNotificationChannel(androidNotificationChannel);




        //creamos la notificacion*************************************************
        AndroidNotification notification = new AndroidNotification
        {
            Title = "Metete de nuevo",
            Text = "Ya se te recargó la energía para que vuelvas a pistear como un campeon",
            SmallIcon = "default",
            LargeIcon = "default",
            FireTime = dateTime,
        };

        AndroidNotificationCenter.SendNotification(notification, chanelId);



    }

#endif

}
