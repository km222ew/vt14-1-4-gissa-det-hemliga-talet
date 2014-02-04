using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GuessTheSecretNumber.Model;

namespace GuessTheSecretNumber
{
    public partial class Default : System.Web.UI.Page
    {
        private SecretNumber SecretNumber
        {
            get { return Session["SecretNmbr"] as SecretNumber; }
            set { Session["SecretNmbr"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (SecretNumber == null)
            {
                SecretNumber secretNumber = new SecretNumber();
                SecretNumber = secretNumber;
            }
        }

        protected void SubmitGuess_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                Outcome outcome = SecretNumber.MakeGuess(int.Parse(GuessInput.Text));

                PrevGuessPlaceHolder.Visible = true;
                CurrGuessPlaceHolder.Visible = true;

                if (outcome == Outcome.NoMoreGuesses || outcome == Outcome.Correct)
                {
                    GuessInput.Enabled = false;
                    SubmitGuess.Enabled = false;

                    if (outcome == Outcome.NoMoreGuesses)
                    {
                        CurrentGuess.Text = String.Format("Du har inga gissningar kvar. Det hemliga talet var {0}.", SecretNumber.Number);
                        
                    }
                    else if (outcome == Outcome.Correct)
                    {
                        CurrentGuess.Text = String.Format("Grattis du klarade det på {0} försök!", SecretNumber.Count);
                        
                    }

                    NewNmbrPlaceHolder.Visible = true;
                }
                else if (outcome == Outcome.High)
                {
                    CurrentGuess.Text = "Du gissade för högt!";
                }
                else if (outcome == Outcome.Low)
                {
                    CurrentGuess.Text = "Du gissade för lågt!";
                }
                else if (outcome == Outcome.PreviousGuess)
                {
                    CurrentGuess.Text = "Du har redan gissat på talet!";
                }
                

                PrevGuesses.Text = String.Join(", ", SecretNumber.PreviousGuesses);
            }
        }

        protected void SubmitNewNumber_Click(object sender, EventArgs e)
        {
            SecretNumber.Initialize();
        }
    }
}