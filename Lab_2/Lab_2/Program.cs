using System;

namespace Lab2
{
    class Program
    {
        // Глобальний масив, який буде використовуватися і змінюватися у завданнях 1-5
        static int[] mas;

        static void Main(string[] args)
        {
            // Налаштування кодування UTF-8 для коректного відображення українських символів (і, ї, є)
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            // Головний цикл програми для забезпечення роботи меню
            while (true)
            {
                Console.WriteLine("\n--- Лабораторна робота №2. Варіант 7 ---");
                Console.WriteLine("1. Завдання 1 (Генерація та сортування вставками)");
                Console.WriteLine("2. Завдання 2 (Прості числа на парних індексах)");
                Console.WriteLine("3. Завдання 3 (Перестановка елементів)");
                Console.WriteLine("4. Завдання 4 (Пошук квадратів цілих чисел)");
                Console.WriteLine("5. Завдання 5 (Бінарний пошук в діапазоні)");
                Console.WriteLine("6. Завдання 6 (Матриця: практика студентів)");
                Console.WriteLine("7. Завдання 7 (Сортування та перестановка рядків матриці)");
                Console.WriteLine("8. Завдання 8 (Рівняння методом бісекції)");
                Console.WriteLine("9. Завдання 9 (Обробка рядків)");
                Console.WriteLine("0. Вихід");
                Console.Write("Оберіть завдання: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": Task1(); break;
                    case "2": Task2(); break;
                    case "3": Task3(); break;
                    case "4": Task4(); break;
                    case "5": Task5(); break;
                    case "6": Task6(); break;
                    case "7": Task7(); break;
                    case "8": Task8(); break;
                    case "9": Task9(); break;
                    case "0": return;
                    default: Console.WriteLine("Невірний вибір. Спробуйте ще раз."); break;
                }
            }
        }

        // --- ЗАВДАННЯ 1 ---
        static void Task1()
        {
            Console.Write("Введіть кількість елементів масиву: ");
            int n = int.Parse(Console.ReadLine());
            mas = new int[n];

            Console.Write("Введіть мінімальне значення діапазону: ");
            int min = int.Parse(Console.ReadLine());
            Console.Write("Введіть максимальне значення діапазону: ");
            int max = int.Parse(Console.ReadLine());

            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                mas[i] = rnd.Next(min, max + 1);
            }

            Console.WriteLine("Масив до сортування:");
            PrintArray(mas);

            // Алгоритм сортування вставками (Insertion Sort).
            // Беремо кожен елемент і "проштовхуємо" його вліво, поки не знайдемо правильну позицію
            // серед уже відсортованої частини масиву.
            for (int i = 1; i < n; i++)
            {
                int key = mas[i];
                int j = i - 1;

                while (j >= 0 && mas[j] > key)
                {
                    mas[j + 1] = mas[j];
                    j--;
                }
                mas[j + 1] = key;
            }

            Console.WriteLine("Масив після сортування (за зростанням):");
            PrintArray(mas);
        }

        // Класичний алгоритм "Решето Ератосфена" для швидкого знаходження простих чисел.
        // Повертає масив логічних значень, де індекс - це число, а значення - чи є воно простим.
        static bool[] Sieve(int maxVal)
        {
            if (maxVal < 2) return new bool[0];
            bool[] isPrime = new bool[maxVal + 1];

            // Ініціалізація: припускаємо, що всі числа від 2 і вище є простими
            for (int i = 2; i <= maxVal; i++) isPrime[i] = true;

            // Викреслювання складених чисел (крок за кроком множимо прості числа)
            for (int p = 2; p * p <= maxVal; p++)
            {
                if (isPrime[p])
                {
                    for (int i = p * p; i <= maxVal; i += p)
                        isPrime[i] = false;
                }
            }
            return isPrime;
        }

        // --- ЗАВДАННЯ 2 ---
        static void Task2()
        {
            if (mas == null) { Console.WriteLine("Помилка: масив порожній. Виконайте Завдання 1."); return; }

            // Знаходимо максимальне значення в масиві для оптимізації роботи Решета Ератосфена
            int maxVal = 0;
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i] > maxVal) maxVal = mas[i];
            }

            bool[] primes = Sieve(maxVal);
            bool found = false;

            Console.WriteLine("Прості числа на парних індексах:");
            // Перебираємо елементи з кроком 2, щоб перевіряти тільки парні індекси (0, 2, 4...)
            for (int i = 0; i < mas.Length; i += 2)
            {
                if (mas[i] >= 2 && primes[mas[i]])
                {
                    Console.Write(mas[i] + " ");
                    found = true;
                }
            }
            if (!found) Console.WriteLine("Числа, що задовольняють умову, відсутні.");
            Console.WriteLine();
        }

        // --- ЗАВДАННЯ 3 ---
        static void Task3()
        {
            if (mas == null) { Console.WriteLine("Помилка: масив порожній. Виконайте Завдання 1."); return; }

            int maxVal = 0;
            foreach (int x in mas) if (x > maxVal) maxVal = x;
            bool[] primes = Sieve(maxVal);

            // Створюємо буферний масив для збереження елементів у новому порядку
            int[] newMas = new int[mas.Length];
            int index = 0;

            // Логіка перестановки базується на послідовному заповненні нового масиву
            // Етап 1: Прості числа
            for (int i = 0; i < mas.Length; i++)
                if (mas[i] >= 2 && primes[mas[i]]) newMas[index++] = mas[i];

            // Етап 2: Складені числа, що діляться на 3, але не на 2
            for (int i = 0; i < mas.Length; i++)
                if ((mas[i] < 2 || !primes[mas[i]]) && mas[i] % 3 == 0 && mas[i] % 2 != 0) newMas[index++] = mas[i];

            // Етап 3: Складені числа, що діляться на 2 і на 3 (тобто кратні 6)
            for (int i = 0; i < mas.Length; i++)
                if ((mas[i] < 2 || !primes[mas[i]]) && mas[i] % 6 == 0) newMas[index++] = mas[i];

            // Етап 4: Усі інші числа, які не потрапили в попередні категорії
            for (int i = 0; i < mas.Length; i++)
            {
                bool isPrime = (mas[i] >= 2 && primes[mas[i]]);
                bool isMult3 = (mas[i] % 3 == 0 && mas[i] % 2 != 0);
                bool isMult2and3 = (mas[i] % 6 == 0);

                if (!isPrime && !isMult3 && !isMult2and3)
                    newMas[index++] = mas[i];
            }

            // Оновлюємо глобальний масив
            mas = newMas;
            Console.WriteLine("Масив після перестановки за заданими умовами:");
            PrintArray(mas);
        }

        // --- ЗАВДАННЯ 4 ---
        static void Task4()
        {
            if (mas == null) { Console.WriteLine("Помилка: масив порожній. Виконайте Завдання 1."); return; }

            bool found = false;
            Console.WriteLine("Елементи, що є квадратами цілих чисел:");

            // Використовуємо лінійний пошук для перевірки кожного елемента
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i] >= 0)
                {
                    // Добуваємо квадратний корінь. Якщо дробова частина відсутня - це повний квадрат.
                    double sqrt = Math.Sqrt(mas[i]);
                    if (sqrt == Math.Floor(sqrt))
                    {
                        Console.WriteLine($"Індекс: {i}, Значення: {mas[i]}");
                        found = true;
                    }
                }
            }
            if (!found) Console.WriteLine("Такі елементи в масиві відсутні.");
        }

        // --- ЗАВДАННЯ 5 ---
        static void Task5()
        {
            if (mas == null) { Console.WriteLine("Помилка: масив порожній. Виконайте Завдання 1."); return; }

            // Бінарний пошук працює виключно з відсортованими масивами. 
            // Сортуємо масив перед початком пошуку.
            Array.Sort(mas);

            Console.Write("Введіть нижню межу діапазону пошуку: ");
            int minRange = int.Parse(Console.ReadLine());
            Console.Write("Введіть верхню межу діапазону пошуку: ");
            int maxRange = int.Parse(Console.ReadLine());

            int count = 0;
            Console.WriteLine("Знайдені елементи:");

            // Шукаємо кожне число з діапазону за допомогою Array.BinarySearch
            for (int i = minRange; i <= maxRange; i++)
            {
                int index = Array.BinarySearch(mas, i);
                if (index >= 0)
                {
                    Console.Write(mas[index] + " ");
                    count++;
                }
            }
            Console.WriteLine($"\nЗагальна кількість знайдених елементів: {count}");
            if (count == 0) Console.WriteLine("Елементів в заданому діапазоні не знайдено.");
        }

        // --- ЗАВДАННЯ 6 ---
        // Глобальні змінні для роботи з двовимірним масивом у завданнях 6 та 7
        static int[,] matrix;
        static int rows, cols;

        static void Task6()
        {
            Console.Write("Введіть кількість компаній (рядки матриці): ");
            rows = int.Parse(Console.ReadLine());
            Console.Write("Введіть кількість місяців (стовпчики матриці): ");
            cols = int.Parse(Console.ReadLine());

            matrix = new int[rows, cols];
            Random rnd = new Random();

            // Ініціалізація матриці. Значення - кількість студентів-практикантів.
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    matrix[i, j] = rnd.Next(0, 20);

            Console.WriteLine("Згенерована матриця практики студентів:");
            PrintMatrix(matrix);

            Console.Write($"Введіть індекс місяця (від 0 до {cols - 1}): ");
            int month = int.Parse(Console.ReadLine());

            // Обчислення суми елементів в заданому стовпчику (місяці)
            int totalInMonth = 0;
            for (int i = 0; i < rows; i++) totalInMonth += matrix[i, month];
            Console.WriteLine($"Загалом студентів проходили практику у {month}-му місяці: {totalInMonth}");

            Console.Write("Введіть кількість студентів для пошуку: ");
            int targetStudents = int.Parse(Console.ReadLine());
            int companiesCount = 0;

            // Пошук заданого значення по всій матриці
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] == targetStudents)
                    {
                        companiesCount++;
                        break; // Достатньо одного збігу для компанії, переходимо до наступної
                    }
                }
            }
            Console.WriteLine($"Кількість компаній, що прийняли рівно {targetStudents} студентів: {companiesCount}");

            // Пошук рядка (компанії) з максимальною сумою елементів
            int maxTotal = -1;
            int bestCompanyIndex = -1;
            for (int i = 0; i < rows; i++)
            {
                int sum = 0;
                for (int j = 0; j < cols; j++) sum += matrix[i, j];

                if (sum > maxTotal)
                {
                    maxTotal = sum;
                    bestCompanyIndex = i;
                }
            }
            Console.WriteLine($"Компанія з найбільшим загальним обсягом практикантів: індекс {bestCompanyIndex} (кількість: {maxTotal})");
        }

        // --- ЗАВДАННЯ 7 ---
        static void Task7()
        {
            if (matrix == null) { Console.WriteLine("Помилка: матриця порожня. Виконайте Завдання 6."); return; }

            // 1. Сортування елементів всередині кожного рядка
            for (int i = 0; i < rows; i++)
            {
                int[] tempRow = new int[cols];
                for (int j = 0; j < cols; j++) tempRow[j] = matrix[i, j];
                Array.Sort(tempRow);
                for (int j = 0; j < cols; j++) matrix[i, j] = tempRow[j];
            }

            // 2. Обчислення сум рядків для подальшого їх сортування між собою
            int[] rowSums = new int[rows];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++) rowSums[i] += matrix[i, j];
            }

            // 3. Сортування рядків матриці методом "бульбашки" за спаданням їх сум
            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < rows - i - 1; j++)
                {
                    if (rowSums[j] < rowSums[j + 1])
                    {
                        // Перестановка значень сум
                        int tempSum = rowSums[j];
                        rowSums[j] = rowSums[j + 1];
                        rowSums[j + 1] = tempSum;

                        // Фізична перестановка цілих рядків у двовимірному масиві
                        for (int k = 0; k < cols; k++)
                        {
                            int temp = matrix[j, k];
                            matrix[j, k] = matrix[j + 1, k];
                            matrix[j + 1, k] = temp;
                        }
                    }
                }
            }

            Console.WriteLine("Матриця після сортування рядків та їх перестановки:");
            PrintMatrix(matrix);
        }

        // --- ЗАВДАННЯ 8 ---
        // Функція, що описує нелінійне рівняння варіанту 7: (3x^2 + 5x - 7)^2 - (x + 2) = 0
        static double f(double x)
        {
            return Math.Pow(3 * x * x + 5 * x - 7, 2) - (x + 2);
        }

        // Метод бісекції (половинного ділення) для знаходження кореня рівняння
        static double bisect(double left, double right)
        {
            double eps = 0.00001; // Задана точність обчислень
            double center = 0;

            // Ітеративний процес звуження відрізка пошуку
            while (right - left > eps * 2)
            {
                center = left + (right - left) / 2; // Знаходження середини

                // Перевірка знаку функції для вибору нової половини відрізка
                if (f(center) * f(left) > 0)
                    left = center;
                else
                    right = center;
            }
            return center;
        }

        // Метод для перевірки достовірності знайденого кореня
        static void verify(double root, double eps)
        {
            double res = f(root);
            Console.WriteLine($"Перевірка підстановкою: f({root:F5}) = {res:F5}");
            if (Math.Abs(res) < eps) Console.WriteLine("Корінь визначено з необхідною точністю.");
            else Console.WriteLine("Задана точність не досягнута.");
        }

        static void Task8()
        {
            Console.WriteLine("Рівняння: (3x^2 + 5x - 7)^2 - (x + 2) = 0");
            Console.Write("Введіть ліву межу відрізку [a]: ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("Введіть праву межу відрізку [b]: ");
            double b = double.Parse(Console.ReadLine());

            // Необхідна умова роботи методу бісекції: функція має приймати значення різних знаків на кінцях відрізку
            if (f(a) * f(b) > 0)
            {
                Console.WriteLine("Алгоритмічна помилка: На кінцях заданого відрізку функція має однакові знаки.");
                return;
            }

            double root = bisect(a, b);
            Console.WriteLine($"Розрахований корінь: {root:F5}");
            verify(root, 0.001);
        }

        // --- ЗАВДАННЯ 9 ---
        static void Task9()
        {
            Console.WriteLine("Введіть рядок (алфавітні символи, цифри та арифметичні знаки):");
            string input = Console.ReadLine();

            string filtered = "";
            // Етап 1: Фільтрація рядка (видалення всіх літер)
            for (int i = 0; i < input.Length; i++)
            {
                if (!char.IsLetter(input[i]) && input[i] != ' ')
                {
                    filtered += input[i];
                }
            }
            Console.WriteLine($"Відформатований рядок (без літер): {filtered}");

            // Етап 2: Синтаксичний розбір (парсинг) та обчислення виразу послідовно зліва направо
            string currentNum = "";
            double result = 0;
            char lastOp = '+';

            for (int i = 0; i < filtered.Length; i++)
            {
                char c = filtered[i];

                // Накопичення цифр у тимчасовий рядок для формування числа
                if (char.IsDigit(c) || c == '.' || c == ',')
                {
                    currentNum += c;
                }

                // Якщо зустріли знак операції або досягли кінця рядка - виконуємо обчислення
                if (!char.IsDigit(c) && c != '.' && c != ',' || i == filtered.Length - 1)
                {
                    if (currentNum.Length > 0)
                    {
                        // Приведення роздільника до формату системи (кома) для коректної конвертації
                        double num = Convert.ToDouble(currentNum.Replace('.', ','));

                        switch (lastOp)
                        {
                            case '+': result += num; break;
                            case '-': result -= num; break;
                            case '*': result *= num; break;
                            case '/': if (num != 0) result /= num; break;
                        }
                        currentNum = ""; // Скидання буфера після виконання операції
                    }
                    // Збереження поточної операції для застосування до наступного числа
                    if (i != filtered.Length - 1) lastOp = c;
                }
            }
            Console.WriteLine($"Підсумковий результат обчислень: {result}");
        }

        // --- Допоміжні методи для форматованого виведення структур даних у консоль ---
        static void PrintArray(int[] arr)
        {
            if (arr == null) return;
            foreach (int item in arr) Console.Write(item + "\t");
            Console.WriteLine();
        }

        static void PrintMatrix(int[,] mat)
        {
            if (mat == null) return;
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    Console.Write(mat[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}