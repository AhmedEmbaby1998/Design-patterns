using System.Collections;

namespace observer_pattern.util
{
    public abstract class Observable
    {
        private bool _changed ;
        private readonly ArrayList _observers=new ArrayList();

        protected void SetChanged()
        {
            this._changed = true;
        }

        protected void AddObserver(Observer obs)
        {
            _observers.Add(obs);
        }

        protected void DeleteObserver(Observer obs)
        {
            _observers.RemoveAt(_observers.BinarySearch(obs));
        }
        protected void NotifyObserver(object data)
        {
            if (_changed)
            {
                foreach (var obs in _observers)
                {
                    var o = (Observer) obs;
                    o.Update(data);
                }
            }
            _changed = false;
        }
        protected void NotifyObserver()
        {
            if (_changed)
            {
                foreach (var obs in _observers)
                {
                    var o = (Observer) obs;
                    o.Update(this,null);
                }
            }
            _changed = false;
        }
    }
    }
