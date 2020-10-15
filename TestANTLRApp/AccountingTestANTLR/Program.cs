using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using Antlr4.Runtime;

namespace AccountingTestANTLR
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = "Artem TOOK 5 USD \n Paul TOOK 3 USD \n Brian GAVE 2 USD \n Olga TOOK 1 USD \n";
            
            AntlrInputStream inputStream = new AntlrInputStream(text);
            var lexer = new AccountingLexer(inputStream);
            
            var commonTokenStream = new CommonTokenStream(lexer);
            var parser = new AccountingParser(commonTokenStream);
            var context = parser.accounting();
            
            // Version 1
            var visitor = new InternalAccountingVisitor();        
            
            //Version 2
            //var visitor = new CustomAccountingVisitor(); 
            
            visitor.Visit(context);
        }
    }
}