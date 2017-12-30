using System;
using Xamarin.Forms;


namespace Nevitium.Helpers.Services
{


    public interface IInjectableMessageService
    {
        void Send(object sender, string messageName);
        void Send<TArgumentObjectType>(object sender, string messageName, TArgumentObjectType argumentObject);
        void Subscribe<TSender>(TSender sender, string messageName, Action<TSender> callbackAction) where TSender : class;
        void Subscribe<TSender, TArgumentObjectType>(TSender sender, string messageName, Action<TSender, TArgumentObjectType> callbackAction) where TSender : class;
        void UnSubscribe<T>(object subscriber, string messageName) where T : class;
    }
    public class InjectableMessageService : IInjectableMessageService
    {

        public void Send(object sender, string messageName)
        {
            MessagingCenter.Send(sender, messageName);
        }

        public void Send<TArgumentObjectType>(object sender, string messageName, TArgumentObjectType argumentObject)
        {
            MessagingCenter.Send(sender, messageName, argumentObject);

        }

        public void Subscribe<TSender>(TSender sender, string messageName, Action<TSender> callbackAction) where TSender : class
        {

            //Action<InjectableMessageService, TArgumentObjectType> action = (x, y) => callbackAction(argumentObject);
            //void action(InjectableMessageService x, TArgumentObjectType y) => callbackAction(argumentObject);

            MessagingCenter.Subscribe(sender, messageName, (TSender x) => callbackAction(sender));
        }


        public void Subscribe<TSender, TArgumentObjectType>(TSender sender, string messageName, Action<TSender, TArgumentObjectType> callbackAction) where TSender : class
        {

            //Action<InjectableMessageService, TArgumentObjectType> action = (x, y) => callbackAction(argumentObject);
            //void action(InjectableMessageService x, TArgumentObjectType y) => callbackAction(argumentObject);

            MessagingCenter.Subscribe(sender, messageName, (TSender x, TArgumentObjectType y) => callbackAction(x, y));
        }

        public void UnSubscribe<T>(object subscriber, string messageName) where T : class
        {
            MessagingCenter.Unsubscribe<T>(subscriber, messageName);

        }
    }

}


