class Program
{

    public interface IInter<T>
    {
            T GetValue();
    }

    public class MyClass<T, T2, T3> : IInter<int> where T: class // ограничение
    {
        private int m_value = 1; // проинициализировали
        public MyClass()
        {

        }
        public int value => m_value; // геттер, который возвращает m_value

        // public int value
        // {
        //     get
        //     {
        //         return m_value;
        //     }
        //     private set // защита метода, по умолчанию всегда public
        //     {
        //         if (value != m_value)
        //         {
        //             m_value = value;
        //             Console.WriteLine("changed value");
        //         }
        //     }
        // }
//        public int value {protected set; get;} // запретили менять set, теперь доступен классу и наследникам
        public int GetValue()
        {
            return m_value;
        }

        public void SetValue(int value)
        {
            this.m_value = value;
        }
    }

    static void Main()
    {
        MyList<int> myList = new MyList<int>();
        myList.Add(1);
        myList.Add(1);
        myList.Add(1);
        myList.Remove(1);
        myList.RemoveAt(1);

        int i = myList[0];


        Print(0, "text", 0.5f);

        for (int j = 0; j< myList.Count; j++)
    {
        Console.WriteLine(myList[i]);
    }

        foreach (int item in myList)  // IEnumirable, можем использовать вместо листа ICollection (еслит только размер)
        {
            Console.WriteLine(item);
        }

        List<int> list = new List<int>();
        list.Add(0);
        list.Add(5);
        list.Add(10);



        foreach (int item in list)  // IEnumirable, можем использовать вместо листа ICollection (еслит только размер)
        {
            Console.WriteLine(item);
        }

        Animals animal = Animals.Cat; // по умолчанию всегда берется первый элемент
        animal = Animals.Dog;
        animal = Animals.Cat;
        animal = Animals.Monkey;

        Animals animal2 = Animals.Lion;
        int v = (int)animal2;
        Console.WriteLine(v); // увидим 3 (индекс)
        Console.WriteLine((Animals)v); // 

        switch (animal) // удобно использовать в свитче
        {
            case Animals.Cat : Console.WriteLine("select cat"); break;
            case Animals.Dog : Console.WriteLine("select dog"); break;
            case Animals.Lion : Console.WriteLine("select lion"); break;
        }

    }
        
// Можно передавать в методы
public static void PrintAnimals (Animals p)
{
    Console.WriteLine(p);

}
    public static T1 Print<T1, T2, T3>(T1 p1, T2 p2, T3 p3)
    {
        Console.WriteLine(p1.ToString());
        Console.WriteLine(p2.ToString());
        Console.WriteLine(p3.ToString());
        return p1;
    }

    public enum Animals // еще один тип, внутри содержится обычный лист, не ссылочный тип => можно использвать ref, out, in
    {
        Cat,
        Dog,
        Monkey,
        Lion //, запятая опциональна у последнего
    }

//    public static void Print2<T>() where T : IInter // ограничиваем типы необходимостью наследования интерфейса
//    public static void Print2<T>() where T : struct // ограничиваем типы необходимостью, чтобы он был структурой
//    public static void Print2<T>() where T : struct // ограничиваем типы необходимостью, чтобы он классом, реализующим IInter
//    public static void Print2<T>() where T : new() // должен быть конструктор по умолчанию без параметров
    public static void Print2<T>() // должен быть конструктор по умолчанию без параметров

    {

    }

    // public static void Print(int i)
    // {
    //     Console.WriteLine(i);
    // }

    
    // public static void Print(string s)
    // {
    //     Console.WriteLine(s);
    // }

    
    // public static void Print(float f)
    // {
    //     Console.WriteLine(f);
    // }
}


// По сути, этого вполне достаточно, чтобы уже написать игру, и разбираться в чужом коде, в примерах