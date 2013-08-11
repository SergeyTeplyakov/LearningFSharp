<Query Kind="FSharpProgram" />

// Chris Smith says that %O will box the value, and %A - is the same specifier
// as %O but it will check StructuredFormatDisplay attribute first and than will
// call Object.ToString! WTF!!

// Creating an instance
type Person = {Id: int; Name: string} with
    override x.ToString() =
        printfn "Person.ToString()"
        "Id: " + x.Id.ToString() + ", Name: " + x.Name
        
let p = {Id = 42; Name = "Foo"}
printfn "%O" p
printfn "%A" p

let check = p.GetType().GetCustomAttribute(typeof<Microsoft.FSharp.Core.StructuredFormatDisplayAttribute>)
p.GetType.GetCustomAttributes().Dump()
check.Dump()
p.GetType().Dump()