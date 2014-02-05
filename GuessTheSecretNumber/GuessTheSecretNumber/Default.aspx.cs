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
        //Inkapslad session
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

                //Om gissningen är rätt eller om antal gissningar (7) är slut 
                if (outcome == Outcome.NoMoreGuesses || outcome == Outcome.Correct)
                {
                    //"Stänger av" knappen och textboxen till en gissning
                    GuessInput.Enabled = false;
                    SubmitGuess.Enabled = false;

                    //Om gissningar är slut
                    if (outcome == Outcome.NoMoreGuesses)
                    {
                        CurrentGuess.Text = String.Format("Du har inga gissningar kvar. Det hemliga talet var {0}.", SecretNumber.Number);
                        
                    }
                    //annars om gissning är rätt
                    else if (outcome == Outcome.Correct)
                    {
                        CurrentGuess.Text = String.Format("Grattis du klarade det på {0} försök!", SecretNumber.Count);
                        
                    }

                    //Visar knappen för att slumpa ett nytt nummer
                    NewNmbrPlaceHolder.Visible = true;
                }
                //För hög gissning
                else if (outcome == Outcome.High)
                {
                    CurrentGuess.Text = "Du gissade för högt!";
                }
                //För låg gissning
                else if (outcome == Outcome.Low)
                {
                    CurrentGuess.Text = "Du gissade för lågt!";
                }
                //Gissningen är identisk med tidigare gissning
                else if (outcome == Outcome.PreviousGuess)
                {
                    CurrentGuess.Text = "Du har redan gissat på talet!";
                }
                
                //Skriver ut föregående gissningar i listan med komma-separation
                PrevGuesses.Text = String.Join(", ", SecretNumber.PreviousGuesses);
            }
        }

        //Event på knapp som slumpar fram ett nytt nummer
        protected void SubmitNewNumber_Click(object sender, EventArgs e)
        {
            SecretNumber.Initialize();
        }
    }
}