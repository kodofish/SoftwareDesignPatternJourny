namespace C2M2H1_TemplateMethod.TemplateMethod_Pratice
{
    public class Class1
    {
        public void p1(int[] u)
        {
            Process(u, (current, next) => Condition(current, next));
        }
        private static void Process(int[] u, Func<int, int, bool> condition)
        {
            int n = u.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (condition(u[j], u[j+1]))
                    {
                        int temp = u[j];
                        u[j] = u[j + 1];
                        u[j + 1] = temp;
                    }
                }
            }
        }
        private static bool Condition(int current, int next)
        {
            return current > next;
        }
    }

    public class Class2
    {
        public void p2(int[] u)
        {
            Process(u, (current, next)=> Condition(current, next));
        }
        private static void Process(int[] u, Func<int, int, bool> condition)
        {

            int n = u.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (condition(u[j], u[j+1]))
                    {
                        int temp = u[j];
                        u[j] = u[j + 1];
                        u[j + 1] = temp;
                    }
                }
            }
        }
        private static bool Condition(int current, int next)
        {
            return current < next;
        }
    }

}