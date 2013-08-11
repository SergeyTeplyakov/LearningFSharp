<Query Kind="FSharpProgram" />

(*
  F# enables to use different literals for integral and floating point nunmbers.
  For example, we can use hexademical, octal and binary representations.
*)

let hex = 0xFAAC
hex.Dump() // 64172

let dec = 12345
dec.Dump() // 12345

let bin = 0b001010101y
bin.Dump() // 85

// IEEE 32 and IEEE 64 standarts
let f = 0x401E000000000000LF
f.Dump() // 7,5

let s = "Hello, world!"B
s.Dump() // s is a array of byte!