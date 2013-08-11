<Query Kind="FSharpProgram" />

open System

// Extending F# options
type Option<'T> with

	// Returns value or default value of the current type
	member this.ValueOrDefault =
		match this with
		| Some(v) -> v
		| None -> Unchecked.defaultof<'T>
		
		
let n: int option = None
n.ValueOrDefault.Dump() // print 0

let s: string option = None
s.ValueOrDefault.Dump() // print null

let d = Some(42.0)
d.ValueOrDefault.Dump() //print 42.0