namespace Minesweeper

open System.Text
open FSharpPlus
open Cell

type Minefield =
    | Setup of width: int * height: int
    | Playing of width: int * height: int * Map<(int*int), Cell>

module Minefield = 
    let start v =
        match v with
        | Setup (w, h) ->
            let cells = Map.ofSeq <| seq {
                for y in {0..h - 1} do
                for x in {0..w - 1} do
                yield ((y, x), init)
            }
            Playing (w, h, cells)
        | _ -> v
    let string v =
        match v with
        | Playing (w, h, z) -> 
            (StringBuilder(), z |> Map.toSeq) ||> fold (fun s ((y, x), c) ->
                let _1 = s.Append (c |> char)
                match x with
                | _ when x = w - 1 -> _1.Append '\n'
                | _ -> _1.Append ' ') |> string


