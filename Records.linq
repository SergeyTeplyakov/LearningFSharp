<Query Kind="FSharpProgram" />

// Good tutorial on records: http://fsharpforfunandprofit.com/posts/records/

//-----------------------------------------------------------------------
// Declarations
//-----------------------------------------------------------------------

// Simple declaration
type Person = {Id: int; Name: string}

// Record that requires full name
[<RequireQualifiedAccess>]
type AnotherPerson = {Id: int; Name: string}

//-----------------------------------------------------------------------
// Simple cases
//-----------------------------------------------------------------------
// Creating an instance
let p = {Id = 42; Name = "Foo"}

// Creating an instance specifying name explicitely
let exp = {Person.Id = 42; Name = "Explicitely Named"}

// Printing content (%O or p.ToString() will print full type name)
printfn "Person is %A" p
printfn "Person is %O" p

// Creating new instance from existing one
let p2 = {Id = p.Id + 1; Name = p.Name}

// Creating new instance based on existing one
let p3 = {p2 with Id = p2.Id + 1}

// Records are structural equal
let areEquals = {Id = 1; Name = "Foo"}.Equals({Id = 1; Name = "Foo"})

//-----------------------------------------------------------------------
// Pattern matching
//-----------------------------------------------------------------------

// "Deconstructing" record
let {Id = id; Name = name} = p

// Partial "deconstruction"
let {Id = id2} = p

// Pattern matching
match p with
| {Id = 1; Name = "42"} -> printfn "case 1"
| {Id = _; Name = "42"} -> printfn "case 2"
// Deconstruct during pattern matching
| {Id = id; Name = name} when id > 30 -> printfn "%d, %s" id name
// Partial deconstruction
| {Id = id} when id > 20 -> printfn "%d" id
| _ -> printfn "case 3"

//-----------------------------------------------------------------------
// Record with members (and with mutable fields)
//-----------------------------------------------------------------------
type MutablePerson = {Id: int; mutable Name: string; Age: int} with
	member public x.isPensioner() = x.Age > 60
	member public x.Rename(name) = x.Name <- name

let mp = {Id = 42; Name = "John Doe"; Age = 42}
mp.Rename("Annie") // mp.Name = "Annie"

//-----------------------------------------------------------------------
// Records and null check
//-----------------------------------------------------------------------
let seq : Person seq = Seq.empty

let res = seq.FirstOrDefault()

// We should add "box" to compile this stuff
match box res with
| null -> printf "result is null"
| _ -> printf "result is not null"

//-----------------------------------------------------------------------
// More complicated deconstruction
//-----------------------------------------------------------------------
type ComplexPerson = {Id: int; State: (int*string)}
let cp = {Id = 5; State = (42, "Foo")}

let {Id = i1; State = (n, f)} = cp
// No we can use i1, n and f!