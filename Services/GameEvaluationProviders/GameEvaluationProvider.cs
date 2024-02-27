﻿using theHangedManWpf.Models;

namespace theHangedManWpf.Services.GameEvaluationProviders
{
    public class GameEvaluationProvider : IGameEvaluationProvider
    {
        private readonly NavigationService _winService;
        private readonly NavigationService _lostService;
        private readonly GuessedWord _guessedWord;

        private readonly bool[] _holderBool;

        private string _getEditedGuessedWord = "";
        public int AttemptsLeft { get; set; } = 11;
        public string GetEditedGuessedWord
        {
            get => _getEditedGuessedWord;

            set
            {
                _getEditedGuessedWord = value;
            }
        }

        public GameEvaluationProvider(GameManager gameManager, NavigationService winService,
            NavigationService lostService)
        {
            _guessedWord = gameManager.CurrentGame.CurrentWord;
            _winService = winService;
            _lostService = lostService;
            _holderBool = new bool[_guessedWord.GuessWord.Length];
        }

        // Method to evaluate the guessed word and navigate to win or lost view
        public void DoEvaluationGuessedWord(char guessedChar)
        {
            // if the guessed letter is in the word
            if(_guessedWord.GuessWord.Contains(guessedChar))
            {
                for (int i = 0; i < _guessedWord.GuessWord.Length; i++)
                {
                    // if the letter is in the word
                    if (_guessedWord.GuessWord[i] == guessedChar)
                    {
                        _holderBool[i] = true;

                        // if all letters are guessed
                        if (_holderBool.All(x => x == true))
                        {

                            _winService.Navigate();
                        }
                    }
                }
            }
            else
            {
                // if the letter is not in the word

                AttemptsLeft =  --_guessedWord.AttemptsLeft;
                _guessedWord.CountOfMistakes++;

                if (AttemptsLeft == 0)
                {
                   _lostService.Navigate();
                }
            }

            EditedGuessedWord();
        }

        // Method to edit the _getEditedGuessedWord word
        // that is binding to display to view
        public void EditedGuessedWord()
        {
            // we can work with StringBuilder,
            // but we we always have one word for one game,
            // which does not contain that many letters 

            _getEditedGuessedWord = string.Empty;

            for (int i = 0; i < _holderBool.Length; i++)
            {
                if (_holderBool[i])
                {
                    _getEditedGuessedWord += _guessedWord.GuessWord[i];
                }
                else
                {
                    _getEditedGuessedWord += "_";
                }
                _getEditedGuessedWord += " ";
            }
        }
    }
}
