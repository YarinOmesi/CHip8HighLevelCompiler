grammar Chip8Assembly;

// Parser Rules
program: statement* EOF;
statement: command | label;

commandParams: 
    variableParam (' ' commandParams)? 
    | valueParam  (' ' commandParams)?
    | labelParam  (' ' commandParams)?
    ;
command: COMMAND_NAME (',' commandParams)?;
label: LABEL ':';

variableParam:IDENTIFIER;
valueParam:NUMBER;
labelParam: LABEL;


// Lexer Rules
LABEL: '_'[a-zA-Z]+[a-zA-Z0-9_]*;
COMMAND_NAME: [a-zA-Z]+;
IDENTIFIER: [a-zA-Z]+[a-zA-Z0-9_]*;
NUMBER:[0-9A-Za-z]+;

WHITESPACE: (' '|'\t')+ -> skip;
NEWLINE: ('\r'? '\n'|'\r')+ -> skip;