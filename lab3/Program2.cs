using System.Diagnostics;
class Program{
        // инкапсуляция - private и protected? это изоляция данных и скрытие их для безопасности, таким образом мы делаем работу приложения более стабильной
        // полиморфизм - это изменение поведения нашего объекта - метод Run, наследники изменили поведение этой функции // работаем с одним типом, а на деле работаем с другим

        public interface IActivatable {
            public void Activate();
        };
        public interface IUpdatable {
            public void Update();
        };

        public abstract myData{
            public string key;
            public string value;

            private int data;

            public abstract void Set(); // дали контракт на наследование

            protected void CalcSum(int first, int second){
                return first + second;
            }
        }

        public class MyBase : MyData{
            public override void Set(){
                CalcSum();
            }
        }

        public interface myInterface
        {
            void Run();
            int Calc();
        }

        public interface myInterface
        {
            void Run();
            int Calc();
        }



        public class MyObject
        {
            public string name; // поле - это свойство
            protected int id; // доступно только наследникам (во всей цепочки наследования)
            private int guid; // не доступно

            public virtual void Run() // виртуальная функция, также доступна для вызова, но ее можно переопределить
            {
                id++;
            }
        }

        public class Car : MyObject
        {
            public int[] weals;

            public int getId(){
                return this.id;
            }
        }

        public class Bike : MyObject, myInterface, IActivatable, IUpdatable
        {
                public void Activate(){

                }

                public void Update(){

                }

                public int Calc(){
                    return 0;
                }

                public int GetMyId(){
                    return this.id;
                }

                public override void Run()
                {
//                    base.Run();
                    id--;
                }
        }


		static void Main(string[] args)
		{
            Car car = new Car();
            car.Run();

            MyObject myObject = new Bike();
            myObject.Run();

            IActivatable[] arrayAct = new IActivatable[3];
            IUpdatable[] arrayUp = new IUpdatable[3];

            arrayAct[0] = myObject;
            arrayUp[0] = myObject;

            for( int i = 1; i< 3; i++)
            {
                arrayAct[i].Activate();
            }
		}
	}