using System;
using System.Collections.Generic;

namespace PizzaMaker.Code
{
    public class DIContainer
    {
        private readonly Dictionary<Type, Registration> _container = new();

        private readonly DIContainer _parent;

        private List<Type> _requests = new();

        public DIContainer(DIContainer parent = null)
        {
            _parent = parent;
        }

        public T Resolve<T>()
        {
            if (_requests.Contains(typeof(T)))
            {
                throw new InvalidOperationException($"Circular dependency detected for type {typeof(T)}");
            }

            _requests.Add(typeof(T));

            try
            {
                if (_container.TryGetValue(typeof(T), out Registration registration))
                    return CreateFrom<T>(registration);
                
                if (_parent != null)
                    return _parent.Resolve<T>();
            }
            finally
            {
                _requests.Remove(typeof(T));
            }
            
            throw new InvalidOperationException($"Registration for type {typeof(T)} not found");
        }

        public void RegisterAsSingle<T>(Func<DIContainer, T> creator)
        {
            if (_container.ContainsKey(typeof(T)))
            {
                throw new InvalidOperationException($"Type {typeof(T)} is already registered");
            }

            Registration registration = new(container => creator(container));

            _container[typeof(T)] = registration;
        }

        private T CreateFrom<T>(Registration registration)
        {
            if (registration.Instance == null && registration.Creator != null)
                registration.Instance = registration.Creator(this);

            return (T)registration.Instance;
        }

        private class Registration
        {
            public readonly Func<DIContainer, object> Creator;
            public object Instance { get; set; }

            public Registration(object instance) => Instance = instance;

            public Registration(Func<DIContainer, object> creator) => Creator = creator;
        }
    }
}