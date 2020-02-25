namespace observer_pattern.util
{
    public interface Observer
    {
         void Update(object data);
         void Update(Observable observable, object d);
         
    }
}