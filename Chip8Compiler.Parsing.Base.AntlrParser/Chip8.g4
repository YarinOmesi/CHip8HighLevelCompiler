grammar Chip8;

// Parser Rules
program: declarationStatement* EOF;
declarationStatement:
    mainDecl 
    | methodDeclStatement ;
    
mainDecl: name='main' '{' statement* '}';
methodDeclStatement: name=IDENTIFIER '(' parameters ')'block;
 
block: '{' statementsInMethod* '}';

statementsInMethod: (statement | returnStatement);

parameters: 
    typeAndName 
    | typeAndName ',' parameters
    |
    ;

typeAndName: type name=IDENTIFIER;

// ==== primitive types ====
type : token='byte' # byteType
;
    
// ==== statements ====
statement: 
    whileStatement
    | ifStatement
    | callStetemnt
    | variableDeclarationStatement
    | assignmentStatement
    ; 

variableDeclarationStatement: typeAndName '=' value=term;  

assignmentStatement: reference '=' value=term; 
returnStatement: token='return';
callStetemnt: name=IDENTIFIER '(' arguments ')'; 

arguments:
    expression
    | expression ',' arguments
    |
    ;

// ==== flow ====
ifStatement: 'if' '(' expression ')' body=block ('else' elseBlock=block)?;
whileStatement: 'while' '(' expression ')' block;

// ==== expressions ====
expression: equality;
equality: left=comparision (EQUALITY_OPS right=comparision)?;
comparision: left=term (COMPARISION_OPS right=term)?;
term: left=factor (TERM_OPS right=factor)*;
factor: left=primary (FACTOR_OPS right=primary)*;

primary: number 
    | reference
    | grouping
    ;


reference: referenceIdentifier;    
    
referenceIdentifier: IDENTIFIER;

grouping: '(' term ')';
number: NUMBER;


// Lexer Rules
PRE_HEX:'0x';
TERM_OPS: '+'|'-' ;
FACTOR_OPS: '/' | '*' ;
COMPARISION_OPS: '>' | '>=' | '<' | '<=';
EQUALITY_OPS: '!='|'==';

IDENTIFIER: [a-zA-Z_]+[a-zA-Z0-9_]*;
NUMBER:[0-9A-Za-z]+;

WHITESPACE: (' '|'\t')+ -> skip;
NEWLINE: ('\r'? '\n'|'\r')+ -> skip;