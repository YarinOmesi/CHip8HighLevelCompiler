using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Dfa;
using Antlr4.Runtime.Sharpen;
using Chip8Compiler.Parsing.Base.AntlrParser.Visitors;
using Chip8Compiler.Parsing.Core;
using Chip8Compiler.Parsing.Models;

namespace Chip8Compiler.Parsing.Base.AntlrParser;

public class AntlrParser : IChip8Parser
{
    private readonly ProgramVisitor _programVisitor = new();

    public class LexerErrorListener : IAntlrErrorListener<int>
    {
        public void SyntaxError(IRecognizer recognizer, int offendingSymbol, int line, int charPositionInLine,
            string msg,
            RecognitionException e)
        {
        }
    }

    public Program? Parse(string code)
    {
        var inputStream = new AntlrInputStream(code);
        var lexer = new Chip8Lexer(inputStream);
        lexer.AddErrorListener(new LexerErrorListener());

        var commonTokenStream = new CommonTokenStream(lexer);
        var parser = new Chip8Parser(commonTokenStream) {
            ErrorHandler = new DefaultErrorStrategy(),
        };
        var errorListener = new ErrorHandler();
        parser.AddErrorListener(errorListener);
        
        Program program = _programVisitor.VisitProgram(parser.program());
        if (parser.NumberOfSyntaxErrors == 0)
        {
            return program;
        }

        string[] lines = code.Split(Environment.NewLine);
        StringBuilder builder = new();
        int errorPointer = 0;
        List<ParseError> errors = errorListener.Errors;

        for (var i = 0; i < lines.Length; i++)
        {
            builder.AppendLine(lines[i]);
            if (errorPointer < errors.Count && errors[errorPointer].Line - 1 == i)
            {
                ParseError error = errors[errorPointer];
                builder.Append(' ', error.CharPositionInLine);
                builder.Append('^');
                builder.AppendLine($" Unexpected Character '{error.Text}'");
                errorPointer++;
            }
        }

        Console.Error.WriteLine(builder.ToString());
        return null;
    }
}

public record ParseError(int Line, int CharPositionInLine, string Text);

class ErrorHandler : BaseErrorListener
{
    public readonly List<ParseError> Errors = new();

    public override void SyntaxError(IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine,
        string msg,
        RecognitionException e)
    {
        Errors.Add(new ParseError(line, charPositionInLine, offendingSymbol.Text));
    }

    public override void ReportAmbiguity(Parser recognizer, DFA dfa, int startIndex, int stopIndex, bool exact,
        BitSet ambigAlts,
        ATNConfigSet configs)
    {
        base.ReportAmbiguity(recognizer, dfa, startIndex, stopIndex, exact, ambigAlts, configs);
    }

    public override void ReportAttemptingFullContext(Parser recognizer, DFA dfa, int startIndex, int stopIndex,
        BitSet conflictingAlts,
        SimulatorState conflictState)
    {
        base.ReportAttemptingFullContext(recognizer, dfa, startIndex, stopIndex, conflictingAlts, conflictState);
    }

    public override void ReportContextSensitivity(Parser recognizer, DFA dfa, int startIndex, int stopIndex,
        int prediction,
        SimulatorState acceptState)
    {
        base.ReportContextSensitivity(recognizer, dfa, startIndex, stopIndex, prediction, acceptState);
    }
}