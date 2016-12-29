using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decider
{
    public enum Token
    {
        Plus,
        Minus,
        Multiply,
        Divide,
        Open,
        Close,
        Num,
        Var,
        Eof
    };

    class Lexer
    {

        private List<Token> tokens;
        private int step = 0;

        public Lexer()
        {

        }

        /// <summary>
        /// Advances the character reading the source string by one position. 
        /// </summary>
        private void Advance()
        {
            step++;
        }

        /// <summary>
        /// Tokenizes and returns a list of tokens identified in the given expression. 
        /// </summary>
        /// <param name="expression">the source expression to tokenize</param> 
        /// <returns>the token stream of the given expression</returns> 
        public List<Token> Tokenize(string expression)
        {
            if (expression.Length == 0) return null;

            tokens = new List<Token>();

            while (step < expression.Length)
            {
                switch (expression[step])
                {
                    case ' ':
                        Advance();
                        continue;
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        tokens.Add(Token.Num);
                        Advance();
                        break;
                    case 'a':
                    case 'b':
                    case 'c':
                    case 'd':
                    case 'e':
                    case 'f':
                    case 'g':
                    case 'h':
                    case 'i':
                    case 'j':
                    case 'l':
                    case 'm':
                    case 'n':
                    case 'o':
                    case 'q':
                    case 'r':
                    case 't':
                    case 'u':
                    case 'v':
                    case 'w':
                    case 'x':
                    case 'y':
                    case 'z':
                        tokens.Add(Token.Var);
                        Advance();
                        break;
                    case '+':
                        tokens.Add(Token.Plus);
                        Advance();
                        break;
                    case '-':
                        tokens.Add(Token.Minus);
                        Advance();
                        break;
                    case '*':
                        tokens.Add(Token.Multiply);
                        Advance();
                        break;
                    case '/':
                        tokens.Add(Token.Divide);
                        Advance();
                        break;
                    case '(':
                        tokens.Add(Token.Open);
                        Advance();
                        break;
                    case ')':
                        tokens.Add(Token.Close);
                        Advance();
                        break;
                    default:
                        Console.WriteLine("No.");
                        Environment.Exit(1);
                        break; 
                }
            }
            tokens.Add(Token.Eof); 
            return tokens;
        }
    }
}
