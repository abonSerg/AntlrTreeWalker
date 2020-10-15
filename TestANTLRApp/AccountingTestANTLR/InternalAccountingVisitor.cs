using System;
using System.Collections.Generic;
using Antlr4.Runtime.Tree;

namespace AccountingTestANTLR
{
    public class InternalAccountingVisitor : AccountingBaseVisitor<object>
    {
        public override object VisitTerminal(ITerminalNode node)
        {
            var text = ((TerminalNodeImpl)node).Payload.Text;
            Console.WriteLine(text == "\n" ? "\\n" : text);
            
            return base.VisitTerminal(node);
        }
        
        public override object VisitChildren(IRuleNode node)
        {
            List<IParseTree> children = null;
            var ruleName = string.Empty;

            switch (node)
            {
                case AccountingParser.EmployeeContext empContext:
                    ruleName = AccountingParser.ruleNames[empContext.RuleIndex];
                    break;
                case AccountingParser.AmountContext amountContext:
                    ruleName = AccountingParser.ruleNames[amountContext.RuleIndex];
                    break;
                case AccountingParser.OperationContext operationContext:
                    ruleName = AccountingParser.ruleNames[operationContext.RuleIndex];
                    break;
                case AccountingParser.AccountingContext accountingContext:
                    ruleName = AccountingParser.ruleNames[accountingContext.RuleIndex];
                    break;
                case TerminalNodeImpl terminalNode:
                    ruleName = terminalNode.Payload.Text;
                    break;
            }

            Console.WriteLine(ruleName);
            
            return base.VisitChildren(node);
        }
    }
}