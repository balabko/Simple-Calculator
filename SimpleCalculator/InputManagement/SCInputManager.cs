using System;
using System.Text;
using SimpleCalculator.Core;

namespace SimpleCalculator.InputManagement
{
    public class SCInputManager<T> : ISCInputManager where T: new()
    {
        private readonly StringBuilder _currentNumber = new StringBuilder();
        private readonly ISCProcessor<T> _scProcessor;
        private readonly ISCStringConverter<T> _stringConverter;

        public Exception Error { get; private set; }

        public SCInputManager(ISCProcessor<T> scProcessor, ISCStringConverter<T> stringConverter)
        {
            _scProcessor = scProcessor;
            _stringConverter = stringConverter;
        }

        public void AddDigitChar(char digitChar)
        {
            _currentNumber.Append(digitChar);
        }

        public void RemoveLastDigit()
        {
            if (_currentNumber.Length > 0)
            {
                _currentNumber.Remove(_currentNumber.Length - 1, 1);
            }  
        }

        public int GetNumberLength()
        {
            return _currentNumber.Length;
        }

        public int FinishNumber()
        {
            try
            {
                var currentNumber = _stringConverter.FromString(_currentNumber.ToString());

                if (_scProcessor.Operation == SCBinOperation.None)
                {
                    _scProcessor.LopRes = currentNumber;
                }
                else
                {
                    _scProcessor.Rop = currentNumber;
                    _scProcessor.ExecuteOperation();
                }

                ResetNumber();
            }
            catch(Exception e)
            {
                Error = e;
                return 1;
            }

            return 0;
        }

        public void SetOperation(SCBinOperation operation)
        {
            _scProcessor.Operation = operation;
        }

        public void ResetNumber()
        {
            _currentNumber.Clear();
        }

        public void ResetError()
        {
            Error = null;
        }

        public void Reset()
        {
            ResetNumber();
            ResetError();
            _scProcessor.Reset();
        }

        public string GetResult()
        {
            return _stringConverter.ToString(_scProcessor.LopRes);
        }
    }
}
