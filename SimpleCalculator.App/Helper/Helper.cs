﻿namespace SimpleCalculator.App.Helper
{
    public class Helper : IHelper
    {
        public string GetHelp()
        {
            return
                @"Текущая версия калькулятора работает только с целыми неотрицательными числами. Поддерживаются только операции сложения и вычитания.

Чтобы выполнить вычисления введите выражение (например 3+2-5) и нажмите = или клавишу Enter.
Во время ввода выражения можно редактировать вводимый в настоящий момент операнд при помощи удаления последних символов клавишей Backspace.
Только что введённый оператор можно заменить на другой, если вы ещё не начали вводить правый операнд. Достаточно просто ввести на клавиатуре другой оператор, и текущий оператор заменится на него.

Для выхода из приложения нажмите клавишу Esc.";
        }
    }
}