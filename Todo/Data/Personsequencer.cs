namespace Todo.Data
{
    public class Personsequencer
    {
        private static int personId;

        public static int NextPersonId()
        {
            return ++personId;

        }
        public static void Reset()
        {
            personId = 0;
        }
    }
}
