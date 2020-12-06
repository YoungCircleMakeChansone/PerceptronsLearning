using System;

namespace lab3
{
    class Lab
    {
        /// <summary>
        /// Массив весов
        /// </summary>
        static int[] weights = new int[15];

        /// <summary>
        /// Порог функции активности
        /// </summary>
        static int bias = 5;

        /// <summary>
        /// Выборка букв
        /// </summary>
        static char[] books = { 'Б', 'В', 'Г', 'Е', 'З', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'Ч' };

        /// <summary>
        /// Рандом
        /// </summary>
        static Random random = new Random(Guid.NewGuid().GetHashCode());

        /// <summary>
        /// Является ли данная буква необходимой 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        static bool proceed(char[] data)
        {
            var net = 0;

            for (int i = 0; i < 15; i++)
            {
                net += int.Parse(data[i].ToString()) * weights[i];
            }

            return net >= bias;
        }

        /// <summary>
        /// Уменьшает значение весов если сеть ошиблась и выдала 1
        /// </summary>
        /// <param name="data"></param>
        static void decrease(char[] data)
        {
            for (int i = 0; i < 15; i++)
            {
                if (int.Parse(data[i].ToString()) == 1)
                    weights[i] -= 1;
            }
        }

        /// <summary>
        /// Увеличивает значение весов если сеть ошиблась и выдала 1
        /// </summary>
        /// <param name="data"></param>
        static void increse(char[] data)
        {
            for (int i = 0; i < 15; i++)
            {
                if (int.Parse(data[i].ToString()) == 1)
                    weights[i] += 1;
            }
        }

        static void Main()
        {
            #region data
            var lit1 = "111100111101111".ToCharArray();

            var lit2 = "111101111101111".ToCharArray();

            var lit3 = "111100100100100".ToCharArray();

            var lit4 = "111100111100111".ToCharArray();

            var lit5 = "111001111001111".ToCharArray();

            var lit6 = "101101111101101".ToCharArray();

            var lit7 = "111101101101111".ToCharArray();

            var lit8 = "111101101101101".ToCharArray();

            var lit9 = "111101111100100".ToCharArray();

            var lit10 = "111101100101111".ToCharArray();

            var lit11 = "111010010010010".ToCharArray();

            var lit12 = "101101111001001".ToCharArray();

            char[][] data = { lit1, lit2, lit3, lit4, lit5, lit6, lit7, lit8, lit9, lit10, lit11, lit12 };

            var litP1 = "111101111100100".ToCharArray();
            var litP2 = "111101110100100".ToCharArray();
            var litP3 = "111101011100100".ToCharArray();
            var litP4 = "111001111100100".ToCharArray();
            var litP5 = "111101111100000".ToCharArray();
            var litP6 = "011101110100100".ToCharArray();
            var litP7 = "011101011100100".ToCharArray();
            #endregion

            //Процесс навчання
            for (int i = 0; i < 10000; i++)
            {
                var option = random.Next(0, 11 + 1);

                if (books[option] != 'Р')
                {
                    if (proceed(data[option]))
                        decrease(data[option]);
                }
                else
                {
                    if (!proceed(lit9))
                        increse(lit9);
                }

            }

            #region consoleOutput
            Console.WriteLine(String.Join(",", weights));


            Console.WriteLine("Б\tэто\tР?\t" + proceed(lit1));
            Console.WriteLine("В\tэто\tР?\t" + proceed(lit2));
            Console.WriteLine("Г\tэто\tР?\t" + proceed(lit3));
            Console.WriteLine("Е\tэто\tР?\t" + proceed(lit4));
            Console.WriteLine("З\tэто\tР?\t" + proceed(lit5));
            Console.WriteLine("Н\tэто\tР?\t" + proceed(lit6));
            Console.WriteLine("О\tэто\tР?\t" + proceed(lit7));
            Console.WriteLine("П\tэто\tР?\t" + proceed(lit8));
            Console.WriteLine("С\tэто\tР?\t" + proceed(lit10));
            Console.WriteLine("Е\tэто\tР?\t" + proceed(lit11));
            Console.WriteLine("Ч\tэто\tР?\t" + proceed(lit12), "\r\n\n");

            Console.WriteLine("Узнал\tP\t?" + proceed(litP1));
            Console.WriteLine("Узнал\tP\t-\t1?\t" + proceed(litP1));
            Console.WriteLine("Узнал\tP\t-\t2?\t" + proceed(litP2));
            Console.WriteLine("Узнал\tP\t-\t3?\t" + proceed(litP3));
            Console.WriteLine("Узнал\tP\t-\t4?\t" + proceed(litP4));
            Console.WriteLine("Узнал\tP\t-\t5?\t" + proceed(litP5));
            Console.WriteLine("Узнал\tP\t-\t6?\t" + proceed(litP6));
            Console.WriteLine("Узнал\tP\t-\t7?\t" + proceed(litP7));


            Console.ReadKey();
            #endregion
        }
    }
}
