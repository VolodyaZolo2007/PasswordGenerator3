using System;
using System.Collections.Generic;

namespace PasswordGenerator3.AppData
{
    public class PasswordGeneratorService
    {
        private readonly Random _random = new Random();
        private readonly string _number = "1234567890";
        private readonly string _symbols = "!@#$%^&*()-+_";
        private readonly string _lowerCharacters = "qwertyuiopasdfghjklzxcvbnm";
        private readonly string _uppaperCharacters = "QWERTYUIOPASDFGHJKLZXCVBNM";
        private readonly List<string> _patterns;

        public PasswordGeneratorService(bool useNumbers, bool useSymbols, bool useLower, bool useUpper, bool usewords)
        {

            _patterns = new List<string>();

            if (useNumbers) _patterns.Add(_number);
            if (useSymbols) _patterns.Add(_symbols);
            if (useLower) _patterns.Add(_lowerCharacters);
            if (useUpper) _patterns.Add(_uppaperCharacters);



        }

        public List<string> Start(int lenght, int passwordsCount)
        {
            var passwordSets = new List<string>();
            for (int i = 0; i < passwordsCount; i++)
            {
                string password = string.Empty;
                while (password.Length < lenght)
                {
                    int patternIndex = _random.Next(0, _patterns.Count);
                    int charIndexFromPattern = _random.Next(0, _patterns[patternIndex].Length);

                    password += _patterns[patternIndex][charIndexFromPattern];
                }
                passwordSets.Add(password);
            }

            return passwordSets;

        }

    }
}
