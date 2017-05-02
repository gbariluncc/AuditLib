using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audits.Services
{
    public static class Refresher<T> where T : class
    {
        private static List<IObserver> _observers = new List<IObserver>();

        public static void NotifyObservers()
        {
            _observers.EachAsync(o => o.update());
        }
        public static void RegisterObserver(IObserver observer)
        {
            _observers.Add(observer);
        }
        public static void RemoveObserver(IObserver observer)
        {
            _observers.Remove(observer);
        }
    }
}
