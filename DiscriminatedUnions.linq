<Query Kind="FSharpProgram" />


//-----------------------------------------------------------------------
// Basics
//-----------------------------------------------------------------------

// Unions are case sensitive, so following code won't compile
// type IntOrBool = i of int | bool of bool

type IntOrBool = Int of int | Bool of bool

// Int and Bool are "constructors" for specified values
let i1 = Int 4
let b1 = Bool(true) // Parens are optional

// Constructors for unions are simple fuctions
let ints = [1..10] |> List.map Int

//-----------------------------------------------------------------------
// Unions as a type safe wrappers
//-----------------------------------------------------------------------

type CustomerId = CustomerId of int
type OrderId = OrderId of int

// Using typ-safe customer id
let customerId = CustomerId 42
printfn "%A" customerId // CustomerId 42

// Extracting values from customerId using pattern matching
let (CustomerId id) = customerId
printfn "Id: %d" id // Id: 42

//-----------------------------------------------------------------------
// Defining methods
//-----------------------------------------------------------------------

type CustomUnion =
    | Int of int
    | String of string with
    
    member x.Print() =
        match x with
        | Int i -> printfn "Int: %d" i
        | String s -> printfn "String: %s" s
        
let n = Int 42
n.Print() // Int: 42

//-----------------------------------------------------------------------
// Naming conflicts (WTF)
//-----------------------------------------------------------------------

// Like records, discriminated unions brings "constructors" into the global scope
// and compiler will use latest union if constructor is not unique

type Union1 = I of int | B of bool
type Union2 = I of int | B of bool

let i = I 42 // we'll use Union2.I
let i2 = Union1.I 42 // we'll use Union1.I

// Solution: we can mark union with RequireQualifiedAccessAttribute

//-----------------------------------------------------------------------
// Printing
//-----------------------------------------------------------------------

type Pattern = Singleton of string | AmbientContext of string
let p = Singleton "Comparer.Default"

printfn "%A" p // Singleton "Comparer"
printfn "%O" p // UglyModuleName+Pattern+Singleton
printfn "%s" (p.ToString()) // UglyModuleName+Pattern+Singleton

// Override ToString method:
type Pattern2 = 
    | Singleton of string 
    | AmbientContext of string with
    
    override x.ToString() =
        match x with
        | Singleton s -> sprintf "Singleton: %s" s
        | AmbientContext ac -> sprintf "AmbientContext: %s" ac
        
let ac = AmbientContext "Thread.CurrentThread"

printfn "%A" ac // AmbientContext "Thread.CurrentThread"
printfn "%O" ac // AmbientContext: Thread.CurrentThread
printfn "%s" (ac.ToString()) //AmbientContext: Thread.CurrentThread