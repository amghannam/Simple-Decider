using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Decider
{
    class Parser
    {
        private Token lookahead;
        private List<Token> tokens;

        public Parser()
        {
            tokens = new List<Token>();
        }

        public void Parse(List<Token> input)
        {
            tokens.AddRange(input);
            lookahead = tokens[0];

            Expression();

            if (!Predict(Token.Eof))
            {
                Console.WriteLine("No."); 
            } else
            {
                Console.WriteLine("Yes."); 
            }
        }

        // E  -> T E'
        private void Expression()
        {
            Term();
            ExpressionPrime(); 
        }

        // E' -> + T E' | -TE' |epsilon
        private void ExpressionPrime()
        {
            if (Predict(Token.Plus))
            {
                Match(Token.Plus);
                Term();
                ExpressionPrime();
            } else if (Predict(Token.Minus))
            {
                Match(Token.Minus);
                Term();
                ExpressionPrime();
            } 
        }

        // T  -> F T'
        private void Term()
        {
            Factor();
            TermPrime(); 
        }

        // T' -> * F T' | /FT' |epsilon
        private void TermPrime()
        {
            if (Predict(Token.Multiply))
            {
                Match(Token.Multiply);
                Factor();
                TermPrime(); 
            } else if (Predict(Token.Divide))
            {
                Match(Token.Divide);
                Factor();
                TermPrime(); 
            }
        }

        // F  -> (E) | int | var
        private void Factor()
        {
            if (Predict(Token.Open))
            {
                Match(Token.Open);
                Expression();
                Match(Token.Close);
            } else if (Predict(Token.Num))
            {
                Match(Token.Num);
            } else if (Predict(Token.Var)) {
                Match(Token.Var); 
            } else
            {
                Error(); 
            }
        }


        /*
         * Helper methods start here */ 
          
        private void Next()
        {
            tokens.RemoveAt(0);
            lookahead = tokens[0];
        }

        private bool Predict(Token token)
        {
            return lookahead == token;
        }

        private void Match(Token token)
        {
            Verify(token);
            Next();
        }

        private void Error()
        {
            Console.WriteLine("No.");
            Environment.Exit(1);
        }

        private void Verify(Token token)
        {
            if (!Predict(token))
            {
                Error(); 
            }
        }
    }
}
