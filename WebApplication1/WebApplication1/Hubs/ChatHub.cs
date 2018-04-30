using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using WebApplication1.Models;
using Microsoft.AspNet.SignalR.Hubs;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace WebApplication1.Hubs
{
    public class ChatHub : Hub
    {
        static List<User> Users = new List<User>();
        public Regex R = new Regex(@"\s");
        // Отправка сообщений
        public void Send(string name, string message)
        {
            string str = R.Replace(message, "");
            if ("" != str)
                Clients.All.addMessage(name, message);
        }

        // Подключение нового пользователя
        public void Connect(string userName)
        {
            var id = Context.ConnectionId;

            string str = R.Replace(userName, "");
            if ("" != str)
            {
                if (!Users.Any(x => x.ConnectionId == id))
                {
                    Users.Add(new User { ConnectionId = id, Name = userName });

                    // Посылаем сообщение текущему пользователю
                    Clients.Caller.onConnected(id, userName, Users);

                    // Посылаем сообщение всем пользователям, кроме текущего
                    Clients.AllExcept(id).onNewUserConnected(id, userName);
                }
            }
        }

        // Отключение пользователя
        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        {
            var item = Users.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
            if (item != null)
            {
                Users.Remove(item);
                var id = Context.ConnectionId;
                Clients.All.onUserDisconnected(id, item.Name);
            }

            return base.OnDisconnected(stopCalled);
        }
    }
}