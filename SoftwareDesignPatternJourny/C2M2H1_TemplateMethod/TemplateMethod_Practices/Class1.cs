namespace C2M2H1_TemplateMethod.TemplateMethod_Pratice
{
    public class Class1
    {
        public void p1(int[] u)
        {
            int n = u.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (u[j] > u[j + 1])
                    {
                        int temp = u[j];
                        u[j] = u[j + 1];
                        u[j + 1] = temp;
                    }
                }
            }
        }
    }

    public class Class2
    {
        public void p2(int[] u)
        {
            int n = u.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (u[j] < u[j + 1])
                    {
                        int temp = u[j];
                        u[j] = u[j + 1];
                        u[j + 1] = temp;
                    }
                }
            }
        }
    }

}