<Query Kind="FSharpProgram" />

// WTF's

//-----------------------------------------------------------------------
// Why I can declare different values with the same name in method but can't in module?
//-----------------------------------------------------------------------
let x = 42

// Duplicate definition of value 'x'
// let x = 43

let foo() =
    // In method - no problem!
    let x = 42
    let x = 43
    ()