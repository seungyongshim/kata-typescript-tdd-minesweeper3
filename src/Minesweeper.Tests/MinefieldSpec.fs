module MinefieldSpec

open Xunit
open Minesweeper
open Minesweeper.Minefield
open FSharpPlus

[<Fact>]
let Should_be_Covered () =
    let sut = Setup (4, 3) |> start
    Assert.Equal(". . . .\n. . . .\n. . . .\n", sut |> string)

