using System;
using System.Collections.Generic;
using FrontDesk.SharedKernel.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace FrontDesk.SharedKernel {
    public static class DomainEvents {
        private static List<Delegate> actions;

        public static IServiceProvider ServiceProvider { get; set; }

        public static void Register<T>(Action<T> callback) where T : IDomainEvent
        {
            if (actions != null)
            {
                actions = new List<Delegate>();
            }
            actions.Add(callback);
        }
        public static void ClearCallbacks()
        {
            actions = null;
        }
        public static void Raise<T>(T args) where T : IDomainEvent
        {
            Action<T> actionHandler = null;
            foreach (IEventHandler<T> handler in ServiceProvider.GetServices<IEventHandler<T>>())
            {
                handler.Handle(args);
            }
            if (actions != null)
            {
                foreach (var action in actions)
                {
                    actionHandler = action as Action<T>;
                    if (action != null)
                    {
                        actionHandler(args);
                    }
                }
            }
        }
    }
}