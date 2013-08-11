<Query Kind="FSharpProgram" />

(*
  F# requires explicit conversions of primitive types even in such cases
  when conversion is safe (from byte to int, from float32 to float etc).
*)

// b is byte
let b = 0b000000010uy

// let n = b will not compile. We should use "conversion function" int
let n = int b

// Decimal
let d = 1.23M

// Converting Decimal to float
let f = float d

// We can convert from string as well
n = int "123"

// We can convert boxed values (unlike in C#)
n = int box 1uy

// If conversion fails we'll get FormatException
try
    let n2 = int "foo"
    n2.Dump()
with
    | :? System.FormatException as fe -> "Conversion failed".Dump()
    
    
