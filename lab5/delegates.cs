//Делегат - тип ссылки на функцию (метод)

// public delegate void FuncDelegate();

public delegate int FuncDelegate<T>(T f);

public delegate int FuncDelegate2<T>(T f);


class Program
{
    static FuncDelegate<float> m_delegate;

    static FuncDelegate2<float> m_delegate2; // Тип делегата другой


    static void Main() // из мэйна можно вызывать только также статические методы
    {
        m_delegate = FuncTest;

        m_delegate.Invoke();

//        System.Action // Встроенный делегат, свои делегаты будем использовать редко
//        System.Func // Возвращает результат

        Character player = new Character();
        player.TakeDamage += OnTakeDamage; // Подписались на события => можно присвоить несколько методов
        player.TakeDamage(10);
        player.TakeDamage += OnTakeDamage2;
        player.TakeDamage -= OnTakeDamage; // Отписались метода
    }

    // public static void FuncTest()
    // {

    // }

    public static int FuncTest()
    {
        
    }

    private static void TakeDamage(int damage)
    {
        Console.WriteLine("Take Damage 1");
    }
    private static void TakeDamage2(int damage)
    {
        Console.WriteLine("Take Damage 2");
    }
}

// Пример использования
class Character
{
    public System.Action onTakeDamage;

    // К public нет никакого доверия
    private int m_hp = 100; // m = member, Венгерская нотация, говорит о том, что это приватная переменная, являющаяся членом этого класса
    public void TakeDamage(int damage)
    {
        m_hp -= damage;
        onTakeDamage?.Invoke();
        //  Альтернатива
        // if(onTakeDamage != null)
        // {
        //     onTakeDamage?.Invoke();
        // }
    }


    private List<System.Action> m_actions = new List<System.Action>();
    public event System.Action p; // Делает вызыв делегата приватным, ругается на player.onTakeDamage?.Invoke
    public event System.Action FuncTest
    {
        add
        {
                m_actions.Add(value);
        }
        remove
        {
            m_actions.Remove(value);
        }
    }

    public void Test(int hp)
    {
        foreach (System.Action action in m_actions)
        {
            
        }
    }
}