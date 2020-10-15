using System;
using System.Collections.Generic;
using System.Linq;
using Antlr4.Runtime.Tree;

namespace AccountingTestANTLR
{
    public class CustomAccountingVisitor : AccountingBaseVisitor<object>
    {
        private static void LoopNodes(IEnumerable<IParseTree> nodes)
        {
            foreach (var child in nodes)
            {
                VisitChildNode(child);
            }
        }

        private static void VisitChildNode(IParseTree tree)
        {
            if (tree.ChildCount > 0)
            {
                List<IParseTree> children = null;
                string ruleName = string.Empty;

                switch (tree)
                {
                    case AccountingParser.EmployeeContext empContext:
                        children = empContext.children.ToList();
                        ruleName = AccountingParser.ruleNames[empContext.RuleIndex];
                        break;
                    case AccountingParser.AmountContext amountContext:
                        children = amountContext.children.ToList();
                        ruleName = AccountingParser.ruleNames[amountContext.RuleIndex];
                        break;
                    case AccountingParser.OperationContext operationContext:
                        children = operationContext.children.ToList();
                        ruleName = AccountingParser.ruleNames[operationContext.RuleIndex];
                        break;
                    case AccountingParser.AccountingContext accountingContext:
                        children = accountingContext.children.ToList();
                        ruleName = AccountingParser.ruleNames[accountingContext.RuleIndex];
                        break;
                }
                
                Console.WriteLine(ruleName);

                if (children != null)
                {
                    LoopNodes(children);
                }

                return;
            }
            
            var text = ((TerminalNodeImpl)tree).Payload.Text;
            Console.WriteLine(text == "\n" ? "\\n" : text);
        }
        
        public override object VisitAccounting(AccountingParser.AccountingContext context)
        {
            VisitChildNode(context);
            return "";
        }
    }
}