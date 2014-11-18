using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;
using Link2ChatSelfHosting.Infrastructure;
using Newtonsoft.Json;

namespace SignalROwinApplication
{
    using System.Threading;
    using Microsoft.AspNet.SignalR;
    using SignalROwinApplication.DomainModel;

   /* public class ProductMessageHub : Hub
    {
        // Метод обрабатывающий запросы.
        public void HandleProductMessage(string receivedString)
        {
            Console.WriteLine(receivedString);

            // Обрабатываем входную строку.
            var product = JsonConvert.DeserializeObject<Product>(receivedString);


            var responseString = JsonConvert.SerializeObject(product);

            Clients.All.handleProductMessage(responseString);
                // Иначе, только приславшему.
               // Clients.Caller.handleProductMessage(responseString);
        }
    }*/

    public class ChatHub : Hub
    {
        public void Send(string message, string room, string user)
        {
            Console.WriteLine("Send: message="+message+", room="+room+", user="+user);
            Clients.Group(room).groupMessage(message, room, user);
        }
     
        public Task JoinRoom(string room, string user)
        {
            Console.WriteLine("JoinRoom");
            return Groups.Add(Context.ConnectionId, room);
        }

      /*  public override Task OnDisconnected(bool stopCalled)
        {
            Debug.WriteLine("OnDisconnected");
            var tmp = UserList.Where(c => c.Id == Context.ConnectionId).ToList();
            foreach (var list in tmp)
            {
                UserList.Remove(list);
                UpdateUserList(list.Room);
            }
            return base.OnDisconnected(stopCalled);
        }*/
    }
}
