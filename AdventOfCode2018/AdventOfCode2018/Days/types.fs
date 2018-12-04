namespace Days

[<AutoOpen>]
module Types =

    type Day = {
        runStep1: unit -> unit
        runStep2: unit -> unit
    }
