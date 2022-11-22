using System.Diagnostics;
class Program{

        public struct MyStruct // отличие от класса - ее нельзя наследовать, еще она не ссылочный тип, в структуре нельзя сразу инициализировать переменные
        {
            public int i;

            public MyStruct(int i){
                this.i = i;
            }
        }

        class MyClass
        {
            // модификаторы доступа public - все через экземпляр этого класса
            // private - только сам класс
            private int i = 5;
            private float f;
            protected uint u;

            public MyClass(int i)
            {
                this.i = 5;
                f = 1f;
                u = 1;
            }

            ~MyClass() // деструктор
            {

            }

            public int GetInt()
            {
                return i;
            }

            public int GetInt(string key) // переопределение методов
            {
                return i;
            }
        }

		static void Main(string[] args)
		{

            int i;
            MyClass myClass = new MyClass(5); // ссылка на ячейку памяти, класс будет жить до тех пор, пока существует на него ссылка
            Console.WriteLine($"result: {myClass.GetInt()}");
            myClass.GetInt = 5;
            Console.WriteLine($"result: {myClass.GetInt()}");

            MyStruct myStruct = new MyStruct(15);

            MyStruct myStruct2 = myStruct; // произойдет копирование памяти

            MyClass myClass2 = MyClass; // не копирование, класс возьмет ссылку на myClass (будет содержать ту же ячейку памяти)

            myClass.GetInt = 5;
            myClass2.GetInt = 10;
            Console.WriteLine($"result: {myClass.GetInt()}"); // будет 10

            Console.WriteLine($"result: {myStruct.i()}");
            myStruct.i = 5;

            myStruct2.i = 10;
            Console.WriteLine($"result: {myStruct.i()}"); // будет 5

            TestRun(out myStruct2.i, ref myStruct2.i, myStruct2.i); 
            Console.WriteLine($"result: {myStruct2.i()}");

            TestRunClass(MyClass2);
            
            Console.WriteLine($"result: {myClass2.i()}");

            int i = 0;
            TestRunObject(i); // боксинг - завернули не ссылочный тип в ссылочный
//            TestRunObject("fgdgf");
//            TestRunObject(myClass);


		}

//		public void TestRun(int i) // вызывается копия
        public void TestRun(out int i, ref int p, in int r) // out передаем ссылку на кусок памяти, при этом out нужно проинициализировать (дать значение), ref просто дает ссылку, ничено не обязывая, in ничего сделать с переменной не можем, позволяет защитить данные в структуре, следовательно, бесплатный вызов
        {
            i = 55;
            p = 60;
        }

        public static void TestRunClass(MyClass i)
        {
            cl.i = 35;
        }

        public static void TestRunObject(object obj) // object - ссылочный тип
        {
            int i = (int)obj; // анбоксинг
            Console.WriteLine($"result: {i}");
        }
	}