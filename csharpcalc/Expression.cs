using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace csharpcalc
{
    class Expression
    {
        public double ParseExpr(ref string expr)
        {
            double op , op1;
            op = ParseFactor(ref expr);
            if (expr.Length != 0 )
            {
                if (expr[0] == '+')
                {
                    expr = expr.Substring(1, expr.Length - 1);
                    op1 = ParseExpr(ref expr);
                    op += op1;
                }
                else if (expr[0] == '-')
                {
                    expr = expr.Substring(1, expr.Length - 1);
                    op1 = ParseExpr(ref expr);
                    op -= op1;
                }
            }
            return op;
        }
        public double ParseFactor(ref string expr)
        {
            double op, op1;
            op = ParseTerm(ref expr);
            if (expr.Length != 0)
            {
                if (expr[0] == '*')
                {
                    expr = expr.Substring(1, expr.Length - 1);
                    op1 = ParseFactor(ref expr);
                    op *= op1;
                }
                else if (expr[0] == '/')
                {
                    expr = expr.Substring(1, expr.Length - 1);
                    op1 = ParseFactor(ref expr);
                    op /= op1;
                }
            }
            return op;
         }
        public double ParseTerm(ref string expr)
        {
            double returnValue = 0;
            if (expr.Length != 0)
            {
                if (char.IsDigit(expr[0]))
                { 
                    returnValue = ParseNumber(ref expr);
                    return returnValue;
                }
                else if (expr[0] == '(')
                {
                    expr = expr.Substring(1, expr.Length - 1);
                    returnValue = ParseExpr(ref expr);
                    return returnValue;
                }
                else if (expr[0] == ')')
                    expr = expr.Substring(1, expr.Length - 1);
            }
            return returnValue;
        }
        public double ParseNumber(ref string expr)
        {
            string numberTemp = "";
            for (int i = 0; i < expr.Length && char.IsDigit(expr[i]); i++)
            {
                if (char.IsDigit(expr[0]))
                {
                    numberTemp += expr[0];
                    expr = expr.Substring(1, expr.Length - 1);
                }
            }
            return double.Parse(numberTemp);
        }
    }
}
