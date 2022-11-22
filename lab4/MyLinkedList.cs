using System.Collections;

public class LinkedList<TItem> : IEnumerable<TItem>
{
    // он работает с помозью вспомогательного класса
    private class Node
{
    public TItem value;
    public Node prev;
    public Node next;
}

    public void Push(TItem value)
    {

    }

    public void Pop() // возвращает и удалаяет послеждний элемент из листа
    {

    }

    public TItem Peek(){ // ctrl + . для подсказки
        return default;
    }

    public void Clear(){ // ctrl + . для подсказки
        
    }

    IEnumerator<TItem> IEnumerable<TItem>.GetEnumerator()
    {
        yield return default;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        //TO DO
//        return GetEnumerator(); 
return default;
    }
}


// больше методов = больше плюсов
// мини тест наших листов, сравнить по скорости ( в форе проинициализировать ( по 1000 элементов))