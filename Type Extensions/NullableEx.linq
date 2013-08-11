<Query Kind="FSharpProgram" />

open System

// Extension for Nullable type is a little bit tricky
type Nullable<'a when 'a: (new: unit -> 'a)
				 and 'a: struct
				 // WTF! Why we should specify this stuff as well?!?!?!?
				 and 'a :> ValueType> with
	
	member x.ToOption() =
		match x with
		| v when v.HasValue = true -> Some(v)
		| _ -> None
		
		
let n1 = Nullable<int>(42).ToOption()
n1 |> Option.isSome |> Dump // True

let n2 = Nullable<int>().ToOption()
n2 |> Option.isSome |> Dump // False
