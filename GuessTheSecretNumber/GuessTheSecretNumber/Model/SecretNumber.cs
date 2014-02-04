using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.ObjectModel;

namespace GuessTheSecretNumber.Model
{
    public enum Outcome { Indefinite, Low, High, Correct, NoMoreGuesses, PreviousGuess }

    public class SecretNumber
    {
        private int _number;
        private List<int> _previousGuesses;
        private const int MaxNumberOfGuesses = 7;

        public bool CanMakeGuess { get; set; }
        public int Count { get; set; }

        public int? Number
        {
            get
            {
                if (CanMakeGuess)
                {
                    return null;
                }
                return _number;
            }
        }

        public Outcome Outcome { get; set; }

        public ReadOnlyCollection<int> PreviousGuesses
        {
            get { return _previousGuesses.AsReadOnly(); }
        }

        public void Initialize() 
        {
            _number = new Random().Next(1, 101);

            _previousGuesses.Clear();

            Outcome = Outcome.Indefinite;           
        }

        public Outcome MakeGuess(int guess)
        {
            if (guess < 1 || guess > 100)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (PreviousGuesses.Contains(guess))
            {
                CanMakeGuess = true;
                return Outcome.PreviousGuess;
            }
            else
            {
                _previousGuesses.Add(guess);
                Count = PreviousGuesses.Count;

                if (guess == Number)
                {
                    CanMakeGuess = false;
                    return Outcome.Correct;
                }
                else if (Count >= MaxNumberOfGuesses)
                {
                    CanMakeGuess = false;
                    return Outcome.NoMoreGuesses;
                }
                else if (guess < Number)
                {
                    CanMakeGuess = true;
                    return Outcome.Low;
                }
                else if (guess > Number)
                {
                    CanMakeGuess = true;
                    return Outcome.High;
                }
                else
                {
                    return Outcome.Indefinite;
                }
            }            
        }

        public SecretNumber()
        {
            _previousGuesses = new List<int>(MaxNumberOfGuesses);
            Initialize();
        }
    }
}