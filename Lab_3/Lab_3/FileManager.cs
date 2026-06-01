using System;
using System.IO;

namespace Lab3
{
    // Завдання 9: Статичний клас
    public static class FileManager
    {
        public static void ClearFile(string filePath)
        {
            File.WriteAllText(filePath, "--- Звіт Лабораторної роботи №3 ---\n\n");
            Console.WriteLine($"[Система] Файл {filePath} очищено та підготовлено для запису.");
        }
    }
}