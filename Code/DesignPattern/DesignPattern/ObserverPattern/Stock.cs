namespace DesignPattern.ObserverPattern;

// SUBJECT - Luu danh sach observers va thong bao khi gia thay doi
public class Stock
{
    private List<IObserver> _observers = new List<IObserver>();
    private float _price;

    // Dang ky observer
    public void Attach(IObserver observer)
    {
        _observers.Add(observer);
    }

    // Huy dang ky observer
    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
    }

    // Thay doi gia => thong bao tat ca observers
    public void SetPrice(float newPrice)
    {
        _price = newPrice;
        Notify();
    }

    // Goi Update() cua tung observer
    private void Notify()
    {
        foreach (var observer in _observers)
        {
            observer.Update(_price);
        }
    }
}
