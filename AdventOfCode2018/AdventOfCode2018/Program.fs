open System
open Days

let startMessage =
    printfn "Advent of Code - 2018"
    printfn "Language(s): F#"
    printfn ""

let readInput =
    printf "Day to run: "
    Console.ReadLine

let getInput =
    Int32.Parse(readInput())

let runDay day =
    match day with
    |   1 -> runStep1
    |   _ -> failOver "Invalid day provided!"

[<EntryPoint>]
let main argv =
    startMessage

    let input = getInput
    runDay (input)

    0
