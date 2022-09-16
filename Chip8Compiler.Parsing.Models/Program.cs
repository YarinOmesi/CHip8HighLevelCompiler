using Chip8Compiler.Parsing.Models.Statements;

namespace Chip8Compiler.Parsing.Models;

public record Program(MainMethodDeclarationStatement Main,MethodDeclarationStatement[] Methods);