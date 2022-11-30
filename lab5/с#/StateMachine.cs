

public class Food
{

}

public enum SnakeState // С каждым добавлением нового стейта придется все бегать добавлять
{
    Idle, Moving, Eating
}
// На помощь приходит паттерн стейт
// У кнопки 4 состояния - тоже стейт машин

public class Snake
{
    // private Food m_targetFood = null;
    // private bool m_atTarget = false;

    private Food m_targetFood = null;
    private bool m_atTarget = false;
    private SnakeState m_state = SnakeState.Idle;
    private Dictionary<SnakeState, BaseSnakeState> m_states = new Dictionary<SnakeState, BaseSnakeState();// Тип данных с ключом и значением
    
    public Snake()
    {
        m_states.Add(SnakeState.Idle, new SnakeIdleState(this));
        m_states.Add(SnakeState.Moving, new SnakeMoveState(this));
        m_states.Add(SnakeState.Eating, new SnakeEatState(this)); // можно добавлять извне => змейка делается более абстрактной

    }

    public void ChangeState(SnakeState state)
    {
        m_state = state;
    }

    public void FindFood()
    {
        m_targetFood = new Food();
        ChangeState(SnakeState.Moving);
    }

    public void Move()
    {
//        m_atTarget = true;
        ChangeState(SnakeState.Eating);

    }

    public void Eat()
    {
        m_targetFood = null;
        ChangeState(SnakeState.Idle);

    }

    public void Update()
    {
        // switch (m_state)
        // {
        //     case SnakeState.Idle:
        //         FindFood();
        //         break;
        //     case SnakeState.Moving:
        //         Move();
        //         break;
        //     case SnakeState.Eating:
        //         Eat();
        //         break;   
        // }

        m_states[m_state].Update();

    }

    public void Rain() // Изменение системы, влияющее на машину
    {
        // switch (m_state)
        // {
        //     case SnakeState.Idle:
        //         break;
        //     case SnakeState.Moving:
        //         ChangeState(SnakeState.Idle);
        //         break;
        //     case SnakeState.Eating:
        //         ChangeState(SnakeState.Idle);
        //         break;   
        // }
        m_states[m_state].Rain();

    }

    // минус - придется писать каждое состояние

    public abstract class BaseSnakeState // Очень легко масштабировать (добавлять новые команды)
    {
        protected readonly Snake m_sare; // Это контекст, с чем вообще будет работать состояние
        // readonlu = мы не можем переприсвоить значение этой переменной
        public BaseSnakeState(Snake snake)
        {
            m_snake = snake;
        }
        public abstract void Update();
        public abstract void Rain();
    }

    public class SnakeIdleState : BaseSnakeState // Минус - приходится описывать каждое состояние
    {
            public SnakeIdleState(Snake snake) : base(snake) { }

            public override void Update()
            {
                m_snake.FindFood();
            }
            public override void Rain()
            {
            }
    }

    public class SnakeMoveState : BaseSnakeState // Минус - приходится описывать каждое состояние
    {
            public SnakeMoveState(Snake snake) : base(snake) { }

            public override void Update()
            {
                m_snake.Move();
            }
            public override void Rain()
            {
                m_snake.ChangeState()
            }
    }

    public class SnakeEatState : BaseSnakeState // Минус - приходится описывать каждое состояние
    {
            public SnakeEatState(Snake snake) : base(snake) { }

            public override void Update()
            {
                m_snake.Move();
            }
            public override void Rain()
            {
                m_snake.ChangeState()
            }
    }

}

// Подход через заполнение апдейта условиями ошибочен
// Получается слишком сложный апдейт, сложно поддерживать
// Исправлять через enum


// Каждое состояние описывается отдельно и управляется отдельным объектом