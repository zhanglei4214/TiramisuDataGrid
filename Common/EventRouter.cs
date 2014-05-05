using System;
using Microsoft.Practices.Prism.Events;

namespace TiramisuDataGrid.Common
{
    public class EventRouter
    {
        #region Fields

        private static IEventAggregator eventAggregator;

        #endregion

        #region Constructors

        static EventRouter()
        {
            eventAggregator = new EventAggregator();
        }

        #endregion

        #region Public Methods

        public static void Publish<EventType, Payload>(Payload payload) where EventType : CompositePresentationEvent<Payload>, new() 
        {
            eventAggregator.GetEvent<EventType>().Publish(payload);
        }

        public static void Subscribe<EventType, Payload>(Action<Payload> action) where EventType : CompositePresentationEvent<Payload>, new()
        {
            eventAggregator.GetEvent<EventType>().Subscribe(action);
        }

        #endregion
    }
}
