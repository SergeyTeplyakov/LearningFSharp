<Query Kind="FSharpProgram" />

// We can extend and "overload" existing modules
// If we'll declare namespace as well, like Microsoft.FSharp.Core.Option (this is
// original namespace where Option module resides) than we still have to optn
// this namespace to use module extension.

module Option =

    let filter predicate op =
        match op with
        | Some(v) -> if predicate(v) then Some(v) else None
        | None -> None


let s = Some 42

s 
|> Option.filter(fun v -> v > 40) // Option.filter (from module extension)
|> Option.bind(fun v -> Some(v)) // Option.bind from Microsoft.FSharp.Core
|> Dump