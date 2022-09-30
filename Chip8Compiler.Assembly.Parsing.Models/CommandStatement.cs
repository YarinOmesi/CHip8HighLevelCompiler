namespace Chip8Compiler.Assembly.Parsing.Models;

public record CommandStatement(AssemblyToken Token, CommandParameter[] Parameters) : AssemblyStatement;